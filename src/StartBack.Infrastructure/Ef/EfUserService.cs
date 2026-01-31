using StartBack.Application.Abstractions;
using StartBack.Application.DTOs;
using StartBack.Domain.Entities;
using StartBack.Infrastructure.Persistence.Repositories;
using StartBack.Infrastructure.Persistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace StartBack.Infrastructure.Ef;

public class EfUserService : IUserService
{
    private readonly IRepository<User> _users;
    private readonly IRepository<Role> _roles;
    private readonly IUnitOfWork _uow;
    public EfUserService(IRepository<User> users, IRepository<Role> roles, IUnitOfWork uow)
    { _users = users; _roles = roles; _uow = uow; }

    public IEnumerable<UserDto> GetAll()
        => _users.Query()
            .Include(u => u.Roles).ThenInclude(r => r.Permissions)
            .AsNoTracking()
            .Select(Map)
            .ToList();

    public PagedResult<UserDto> GetPaged(int page, int pageSize, string? search = null, string? sortBy = null, bool desc = false)
    {
        if (page < 1) page = 1; if (pageSize < 1) pageSize = 10;
        var query = _users.Query()
            .Include(u => u.Roles).ThenInclude(r => r.Permissions)
            .AsNoTracking();
        if (!string.IsNullOrWhiteSpace(search))
        {
            var s = search.Trim();
            query = query.Where(u =>
                u.Username.Contains(s) ||
                u.DisplayName.Contains(s) ||
                u.Id.ToString().Contains(s) ||
                u.IsActive.ToString().Contains(s) ||
                u.Roles.Any(r => r.Name.Contains(s) || r.Permissions.Any(p => p.Code.Contains(s) || p.Name.Contains(s)))
            );
        }
        var total = query.Count();
        IOrderedQueryable<StartBack.Domain.Entities.User> ordered = (sortBy?.ToLowerInvariant()) switch
        {
            "displayname" => (desc ? query.OrderByDescending(u => u.DisplayName) : query.OrderBy(u => u.DisplayName)),
            "isactive" => (desc ? query.OrderByDescending(u => u.IsActive) : query.OrderBy(u => u.IsActive)),
            _ => (desc ? query.OrderByDescending(u => u.Username) : query.OrderBy(u => u.Username))
        };
        var items = ordered
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(Map)
            .ToList();
        var totalPages = (int)Math.Ceiling(total / (double)pageSize);
        return new PagedResult<UserDto>(items, total, page, pageSize, totalPages);
    }

    public UserDto? GetById(Guid id)
        => _users.Query()
            .Include(u => u.Roles).ThenInclude(r => r.Permissions)
            .AsNoTracking()
            .Where(u => u.Id == id)
            .Select(Map).FirstOrDefault();

    public UserDto Create(string username, string displayName, string password, bool isActive, Guid[]? roleIds = null)
    {
        // Enforce unique Username
        var exists = _users.Query().Any(x => x.Username == username);
        if (exists) throw new InvalidOperationException("Username already exists");
        var u = new User { Username = username, DisplayName = displayName, PasswordHash = string.IsNullOrWhiteSpace(password) ? "a12345" : password, IsActive = isActive };
        if (roleIds != null && roleIds.Length > 0)
        {
            var roles = _roles.Query().Where(r => roleIds.Contains(r.Id)).ToList();
            foreach (var r in roles)
            {
                if (!u.Roles.Any(x => x.Id == r.Id)) u.Roles.Add(r);
            }
        }
        _users.AddAsync(u).GetAwaiter().GetResult();
        _uow.SaveChangesAsync().GetAwaiter().GetResult();
        return Map(u);
    }

    public bool Update(Guid id, string username, string displayName, bool isActive, string? newPassword = null)
    {
        var u = _users.Query().FirstOrDefault(x => x.Id == id);
        if (u == null) return false;
        // Enforce unique Username excluding current user
        var exists = _users.Query().Any(x => x.Username == username && x.Id != id);
        if (exists) throw new InvalidOperationException("Username already exists");
        u.Username = username;
        u.DisplayName = displayName;
        u.IsActive = isActive;
        if (!string.IsNullOrWhiteSpace(newPassword))
            u.PasswordHash = newPassword;
        _uow.SaveChangesAsync().GetAwaiter().GetResult();
        return true;
    }

    public bool ResetPassword(Guid userId, string? newPassword = null)
    {
        var u = _users.Query().FirstOrDefault(x => x.Id == userId);
        if (u == null) return false;
        u.PasswordHash = string.IsNullOrWhiteSpace(newPassword) ? "a12345" : newPassword;
        _uow.SaveChangesAsync().GetAwaiter().GetResult();
        return true;
    }

    public bool ChangePassword(Guid userId, string oldPassword, string newPassword)
    {
        var u = _users.Query().FirstOrDefault(x => x.Id == userId);
        if (u == null) return false;
        if (u.PasswordHash != oldPassword) return false;
        u.PasswordHash = newPassword;
        _uow.SaveChangesAsync().GetAwaiter().GetResult();
        return true;
    }

    public bool AssignRole(Guid userId, Guid roleId)
    {
        var user = _users.Query().Include(x => x.Roles).FirstOrDefault(x => x.Id == userId);
        var role = _roles.Query().FirstOrDefault(x => x.Id == roleId);
        if (user == null || role == null) return false;
        if (!user.Roles.Any(r => r.Id == role.Id)) user.Roles.Add(role);
        _uow.SaveChangesAsync().GetAwaiter().GetResult();
        return true;
    }

    public PagedResult<UserDto> GetByRole(Guid roleId, int page, int pageSize, string? search = null, string? sortBy = null, bool desc = false)
    {
        if (page < 1) page = 1; if (pageSize < 1) pageSize = 10;
        var query = _users.Query()
            .Include(u => u.Roles).ThenInclude(r => r.Permissions)
            .Where(u => u.Roles.Any(r => r.Id == roleId))
            .AsNoTracking();
        if (!string.IsNullOrWhiteSpace(search))
        {
            var s = search.Trim();
            query = query.Where(u =>
                u.Username.Contains(s) ||
                u.DisplayName.Contains(s) ||
                u.Id.ToString().Contains(s)
            );
        }
        var total = query.Count();
        IOrderedQueryable<StartBack.Domain.Entities.User> ordered = (sortBy?.ToLowerInvariant()) switch
        {
            "displayname" => (desc ? query.OrderByDescending(u => u.DisplayName) : query.OrderBy(u => u.DisplayName)),
            "isactive" => (desc ? query.OrderByDescending(u => u.IsActive) : query.OrderBy(u => u.IsActive)),
            _ => (desc ? query.OrderByDescending(u => u.Username) : query.OrderBy(u => u.Username))
        };
        var items = ordered
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(Map)
            .ToList();
        var totalPages = (int)Math.Ceiling(total / (double)pageSize);
        return new PagedResult<UserDto>(items, total, page, pageSize, totalPages);
    }

    public bool Delete(Guid id)
    {
        var u = _users.Query()
            .Include(x => x.Roles)
            .FirstOrDefault(x => x.Id == id);
        if (u == null) return false;
        _users.Remove(u);
        _uow.SaveChangesAsync().GetAwaiter().GetResult();
        return true;
    }

    public bool UpdateProfileImage(Guid id, string? profileImageUrl)
    {
        var u = _users.Query().FirstOrDefault(x => x.Id == id);
        if (u == null) return false;
        u.ProfileImageUrl = profileImageUrl;
        _uow.SaveChangesAsync().GetAwaiter().GetResult();
        return true;
    }

    private static UserDto Map(User u)
        => new(
            u.Id,
            u.Username,
            u.DisplayName,
            u.IsActive,
            u.ProfileImageUrl,
            u.Roles.Select(r => new UserRoleDto(r.Id, r.Name, r.DefaultPageUrl)).ToArray(),
            u.Roles.SelectMany(r => r.Permissions).Select(p => p.Code).Distinct().ToArray()
        );
}

