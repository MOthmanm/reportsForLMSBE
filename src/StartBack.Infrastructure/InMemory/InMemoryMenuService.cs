using StartBack.Application.Abstractions;
using StartBack.Application.DTOs;

namespace StartBack.Infrastructure.InMemory;

public class InMemoryMenuService : IMenuService
{
    private readonly InMemoryDataStore _db;
    public InMemoryMenuService(InMemoryDataStore db) { _db = db; }

    public IEnumerable<MenuItemDto> GetMenuForUser(Guid userId)
    {
        var user = _db.Users.FirstOrDefault(u => u.Id == userId);
        if (user == null) return Enumerable.Empty<MenuItemDto>();
        var userPerms = user.Roles.SelectMany(r => r.Permissions).Select(p => p.Code).ToHashSet();

        var items = _db.Menu
            .Where(m => m.RequiredPermissions.Count == 0 || m.RequiredPermissions.Any(p => userPerms.Contains(p.Code)))
            .OrderBy(m => m.Order)
            .ToList();

        var byId = items.ToDictionary(m => m.Id);
        var parentKeyLookup = items.ToDictionary(m => m.Id, m => m.ParentId.HasValue && byId.ContainsKey(m.ParentId.Value) ? byId[m.ParentId.Value].Key : null);
        var childrenLookup = items
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

        var roots = items.Where(m => m.ParentId == null || !byId.ContainsKey(m.ParentId.Value))
                         .OrderBy(m => m.Order)
                         .Select(MapDto)
                         .ToList();
        return roots;
    }
}

