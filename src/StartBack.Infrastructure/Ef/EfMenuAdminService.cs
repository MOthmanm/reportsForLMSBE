using StartBack.Application.Abstractions;
using StartBack.Application.DTOs;
using StartBack.Domain.Entities;
using StartBack.Infrastructure.Persistence.Repositories;
using StartBack.Infrastructure.Persistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace StartBack.Infrastructure.Ef;

public class EfMenuAdminService : IMenuAdminService
{
    private readonly IRepository<MenuItem> _menu;
    private readonly IRepository<Permission> _perms;
    private readonly IUnitOfWork _uow;
    public EfMenuAdminService(IRepository<MenuItem> menu, IRepository<Permission> perms, IUnitOfWork uow)
    { _menu = menu; _perms = perms; _uow = uow; }

    public IEnumerable<MenuItemDto> GetAllMenu()
    {
        var items = _menu.Query()
            .Include(m => m.RequiredPermissions)
            .Include(m => m.Icon)
            .AsNoTracking()
            .OrderBy(m => m.Order)
            .ToList();

        // Build lookup by Id and by ParentId
        var byId = items.ToDictionary(m => m.Id);
        var parentKeyLookup = items.ToDictionary(m => m.Id, m => m.ParentId.HasValue && byId.ContainsKey(m.ParentId.Value) ? byId[m.ParentId.Value].Key : null);
        
        // children lookup only for non-root items (avoid null key in dictionary)
        var childrenLookup = items
            .Where(m => m.ParentId.HasValue)
            .GroupBy(m => m.ParentId!.Value)
            .ToDictionary(g => g.Key, g => g.OrderBy(x => x.Order).ToList());

        MenuItemDto MapDto(MenuItem m)
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
        var roots = items.Where(m => m.ParentId == null || !byId.ContainsKey(m.ParentId.Value))
                         .OrderBy(m => m.Order)
                         .Select(MapDto)
                         .ToList();

        return roots;
    }

    public IEnumerable<MenuItemAdminDto> GetAdminTree()
    {
        var items = _menu.Query()
            .Include(m => m.RequiredPermissions)
            .Include(m => m.Icon)
            .AsNoTracking()
            .OrderBy(m => m.Order)
            .ToList();

        var byId = items.ToDictionary(m => m.Id);
        var childrenLookup = items
            .Where(m => m.ParentId.HasValue)
            .GroupBy(m => m.ParentId!.Value)
            .ToDictionary(g => g.Key, g => g.OrderBy(x => x.Order).ToList());

        MenuItemAdminDto MapDto(MenuItem m)
        {
            var children = childrenLookup.TryGetValue(m.Id, out var kids)
                ? kids.Select(MapDto).ToList()
                : new List<MenuItemAdminDto>();
            var requiredCodes = m.RequiredPermissions.Select(p => p.Code).Distinct().ToArray();
            return new MenuItemAdminDto(m.Id, m.Key, m.Title, m.TitleEn, m.TitleAr, m.Url, m.ParentId, m.IconId, m.Icon?.Key, m.Order, requiredCodes, children);
        }

        var roots = items.Where(m => m.ParentId == null || !byId.ContainsKey(m.ParentId.Value))
                         .OrderBy(m => m.Order)
                         .Select(MapDto)
                         .ToList();

        return roots;
    }

    public MenuItemAdminDto? GetById(Guid id)
    {
        var m = _menu.Query()
            .Include(x => x.RequiredPermissions)
            .Include(x => x.Icon)
            .AsNoTracking()
            .FirstOrDefault(x => x.Id == id);
        if (m == null) return null;
        var codes = m.RequiredPermissions.Select(p => p.Code).Distinct().ToArray();
        return new MenuItemAdminDto(m.Id, m.Key, m.Title, m.TitleEn, m.TitleAr, m.Url, m.ParentId, m.IconId, m.Icon?.Key, m.Order, codes, Array.Empty<MenuItemAdminDto>());
    }

    public MenuItemDto Create(string key, string title, string? url, Guid? parentId, int order, IEnumerable<string> requiredPermissionCodes, Guid? iconId, string? titleEn = null, string? titleAr = null)
    {
        var permissions = _perms.Query().Where(p => requiredPermissionCodes.Contains(p.Code)).ToList();
        var item = new MenuItem { Key = key, Title = title, TitleEn = titleEn ?? title, TitleAr = titleAr ?? title, Url = url, ParentId = parentId, Order = order, RequiredPermissions = permissions, IconId = iconId };
        _menu.AddAsync(item).GetAwaiter().GetResult();
        _uow.SaveChangesAsync().GetAwaiter().GetResult();
        var codes = permissions.Select(p => p.Code).Distinct().ToArray();
        return new MenuItemDto(item.Key, item.Title, item.TitleEn, item.TitleAr, item.Url, null, null, item.Order, codes, Array.Empty<MenuItemDto>());
    }

    public bool Update(Guid id, string title, string? url, Guid? parentId, int order, IEnumerable<string> requiredPermissionCodes, Guid? iconId, string? titleEn = null, string? titleAr = null)
    {
        var item = _menu.Query().Include(m => m.RequiredPermissions).FirstOrDefault(m => m.Id == id);
        if (item == null) return false;
        item.Title = title; item.TitleEn = titleEn ?? item.TitleEn ?? title; item.TitleAr = titleAr ?? item.TitleAr ?? title; item.Url = url; item.ParentId = parentId; item.Order = order; item.IconId = iconId;
        var newPerms = _perms.Query().Where(p => requiredPermissionCodes.Contains(p.Code)).ToList();
        item.RequiredPermissions.Clear();
        foreach (var p in newPerms) item.RequiredPermissions.Add(p);
        _uow.SaveChangesAsync().GetAwaiter().GetResult();
        return true;
    }

    public bool Delete(Guid id)
    {
        var item = _menu.Query().FirstOrDefault(m => m.Id == id);
        if (item == null) return false;
        _menu.Remove(item);
        _uow.SaveChangesAsync().GetAwaiter().GetResult();
        return true;
    }
}

