using StartBack.Application.Abstractions;
using StartBack.Application.DTOs;
using StartBack.Domain.Entities;
using StartBack.Infrastructure.Persistence.Repositories;
using StartBack.Infrastructure.Persistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace StartBack.Infrastructure.Ef;

public class EfRoleService : IRoleService
{
    private readonly IRepository<Role> _roles;
    private readonly IRepository<Permission> _perms;
    private readonly IUnitOfWork _uow;
    public EfRoleService(IRepository<Role> roles, IRepository<Permission> perms, IUnitOfWork uow)
    { _roles = roles; _perms = perms; _uow = uow; }

    public IEnumerable<RoleDto> GetAll() => _roles.Query()
        .Include(r => r.Permissions)
        .AsNoTracking()
        .Select(Map)
        .ToList();

    public PagedResult<RoleDto> GetPaged(int page, int pageSize, string? search = null, string? sortBy = null, bool desc = false)
    {
        if (page < 1) page = 1; if (pageSize < 1) pageSize = 10;
        var query = _roles.Query().Include(r => r.Permissions).AsNoTracking();
        if (!string.IsNullOrWhiteSpace(search))
        {
            var s = search.Trim();
            query = query.Where(r =>
                r.Name.Contains(s) ||
                r.Id.ToString().Contains(s) ||
                r.Permissions.Any(p => p.Code.Contains(s) || p.Name.Contains(s))
            );
        }
        var total = query.Count();
        IOrderedQueryable<Role> ordered = (sortBy?.ToLowerInvariant()) switch
        {
            _ => (desc ? query.OrderByDescending(r => r.Name) : query.OrderBy(r => r.Name))
        };
        var items = ordered
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(Map)
            .ToList();
        var totalPages = (int)Math.Ceiling(total / (double)pageSize);
        return new PagedResult<RoleDto>(items, total, page, pageSize, totalPages);
    }

    public RoleDto? GetById(Guid id) => _roles.Query()
        .Include(r => r.Permissions)
        .AsNoTracking()
        .Where(r => r.Id == id)
        .Select(Map).FirstOrDefault();

    public RoleDto Create(string name, string? defaultPageUrl)
    {
        var r = new Role { Name = name, DefaultPageUrl = defaultPageUrl };
        _roles.AddAsync(r).GetAwaiter().GetResult();
        _uow.SaveChangesAsync().GetAwaiter().GetResult();
        return Map(r);
    }

    public bool Update(Guid id, string name, string? defaultPageUrl)
    {
        var r = _roles.Query().FirstOrDefault(x => x.Id == id);
        if (r == null) return false;
        r.Name = name;
        r.DefaultPageUrl = defaultPageUrl;
        _uow.SaveChangesAsync().GetAwaiter().GetResult();
        return true;
    }

    public bool Delete(Guid id)
    {
        var r = _roles.Query().Include(x => x.Permissions).FirstOrDefault(x => x.Id == id);
        if (r == null) return false;
        _roles.Remove(r);
        _uow.SaveChangesAsync().GetAwaiter().GetResult();
        return true;
    }

    public bool AssignPermission(Guid roleId, Guid permissionId)
    {
        var r = _roles.Query().Include(x => x.Permissions).FirstOrDefault(x => x.Id == roleId);
        var p = _perms.Query().FirstOrDefault(x => x.Id == permissionId);
        if (r == null || p == null) return false;
        if (!r.Permissions.Any(x => x.Id == p.Id)) r.Permissions.Add(p);
        _uow.SaveChangesAsync().GetAwaiter().GetResult();
        return true;
    }

    public bool RemovePermission(Guid roleId, Guid permissionId)
    {
        var r = _roles.Query().Include(x => x.Permissions).FirstOrDefault(x => x.Id == roleId);
        if (r == null) return false;
        var p = r.Permissions.FirstOrDefault(x => x.Id == permissionId);
        if (p == null) return false;
        r.Permissions.Remove(p);
        _uow.SaveChangesAsync().GetAwaiter().GetResult();
        return true;
    }

    private static RoleDto Map(Role r) => new(
        r.Id,
        r.Name,
        r.DefaultPageUrl,
        r.Permissions.Select(p => p.Code).Distinct().ToArray()
    );
}

