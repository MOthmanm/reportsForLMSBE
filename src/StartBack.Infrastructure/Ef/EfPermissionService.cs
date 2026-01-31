using StartBack.Application.Abstractions;
using StartBack.Application.DTOs;
using StartBack.Domain.Entities;
using StartBack.Infrastructure.Persistence.Repositories;
using StartBack.Infrastructure.Persistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace StartBack.Infrastructure.Ef;

public class EfPermissionService : IPermissionService
{
    private readonly IRepository<Permission> _perms;
    private readonly IUnitOfWork _uow;
    public EfPermissionService(IRepository<Permission> perms, IUnitOfWork uow)
    { _perms = perms; _uow = uow; }

    public IEnumerable<PermissionDto> GetAll() => _perms.Query()
        .AsNoTracking()
        .Select(Map).ToList();

    public PagedResult<PermissionDto> GetPaged(int page, int pageSize, string? search = null, string? sortBy = null, bool desc = false)
    {
        if (page < 1) page = 1; if (pageSize < 1) pageSize = 10;
        var query = _perms.Query().AsNoTracking();
        if (!string.IsNullOrWhiteSpace(search))
        {
            var s = search.Trim();
            query = query.Where(p =>
                p.Code.Contains(s) ||
                p.Name.Contains(s) ||
                p.Id.ToString().Contains(s)
            );
        }
        var total = query.Count();
        IOrderedQueryable<StartBack.Domain.Entities.Permission> ordered = (sortBy?.ToLowerInvariant()) switch
        {
            "name" => (desc ? query.OrderByDescending(p => p.Name) : query.OrderBy(p => p.Name)),
            _ => (desc ? query.OrderByDescending(p => p.Code) : query.OrderBy(p => p.Code))
        };
        var items = ordered
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(Map)
            .ToList();
        var totalPages = (int)Math.Ceiling(total / (double)pageSize);
        return new PagedResult<PermissionDto>(items, total, page, pageSize, totalPages);
    }

    public PermissionDto? GetById(Guid id) => _perms.Query()
        .AsNoTracking()
        .Where(p => p.Id == id)
        .Select(Map).FirstOrDefault();

    public PermissionDto Create(string code, string name)
    {
        var p = new Permission { Code = code, Name = name };
        _perms.AddAsync(p).GetAwaiter().GetResult();
        _uow.SaveChangesAsync().GetAwaiter().GetResult();
        return Map(p);
    }

    public bool Update(Guid id, string code, string name)
    {
        var p = _perms.Query().FirstOrDefault(x => x.Id == id);
        if (p == null) return false;
        p.Code = code; p.Name = name;
        _uow.SaveChangesAsync().GetAwaiter().GetResult();
        return true;
    }

    public bool Delete(Guid id)
    {
        var p = _perms.Query().FirstOrDefault(x => x.Id == id);
        if (p == null) return false;
        _perms.Remove(p);
        _uow.SaveChangesAsync().GetAwaiter().GetResult();
        return true;
    }

    private static PermissionDto Map(Permission p) => new(p.Id, p.Code, p.Name);
}

