using StartBack.Application.Abstractions;
using StartBack.Application.DTOs;
using StartBack.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace StartBack.Infrastructure.Ef;

public class EfMenuService : IMenuService
{
    private readonly IRepository<StartBack.Domain.Entities.MenuItem> _menu;
    private readonly IRepository<StartBack.Domain.Entities.User> _users;
    private readonly IRepository<StartBack.Domain.Entities.Role> _roles;
    public EfMenuService(IRepository<StartBack.Domain.Entities.MenuItem> menu, IRepository<StartBack.Domain.Entities.User> users, IRepository<StartBack.Domain.Entities.Role> roles)
    { _menu = menu; _users = users; _roles = roles; }

    public IEnumerable<MenuItemDto> GetMenuForUser(Guid userId)
    {
        var user = _users.Query().Include(u => u.Roles).ThenInclude(r => r.Permissions).FirstOrDefault(u => u.Id == userId);
        if (user == null) return Enumerable.Empty<MenuItemDto>();
        var userPerms = user.Roles.SelectMany(r => r.Permissions).Select(p => p.Code).ToHashSet();

        var items = _menu.Query()
            .Include(m => m.RequiredPermissions)
            .Include(m => m.Icon)
            .AsNoTracking()
            .OrderBy(m => m.Order)
            .ToList();

        var allowed = items.Where(m => m.RequiredPermissions.Count == 0 || m.RequiredPermissions.Any(p => userPerms.Contains(p.Code)))
                           .ToList();

        // Build lookup by Id and by ParentId
        var byId = allowed.ToDictionary(m => m.Id);
        var parentKeyLookup = allowed.ToDictionary(m => m.Id, m => m.ParentId.HasValue && byId.ContainsKey(m.ParentId.Value) ? byId[m.ParentId.Value].Key : null);
        // children lookup only for non-root items (avoid null key in dictionary)
        var childrenLookup = allowed
            .Where(m => m.ParentId.HasValue)
            .GroupBy(m => m.ParentId!.Value)
            .ToDictionary(g => g.Key, g => g.OrderBy(x => x.Order).ToList());

        MenuItemDto MapDto(StartBack.Domain.Entities.MenuItem m)
        {
            var children = childrenLookup.TryGetValue(m.Id, out var kids)
                ? kids.Select(MapDto).ToList()
                : new List<MenuItemDto>();
            var parentKey = parentKeyLookup[m.Id];
            var iconKey = m.Icon?.Key;
            var requiredCodes = m.RequiredPermissions.Select(p => p.Code).Distinct().ToArray();
            return new MenuItemDto(m.Key, m.Title, m.TitleEn, m.TitleAr, m.Url, parentKey, iconKey, m.Order, requiredCodes, children);
        }

        // roots are those with ParentId == null or parent not in allowed
        var roots = allowed.Where(m => m.ParentId == null || !byId.ContainsKey(m.ParentId.Value))
                           .OrderBy(m => m.Order)
                           .Select(MapDto)
                           .ToList();

        return roots;
    }
}

