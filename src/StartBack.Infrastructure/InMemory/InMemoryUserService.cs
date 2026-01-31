using StartBack.Application.Abstractions;
using StartBack.Application.DTOs;
using StartBack.Domain.Entities;

namespace StartBack.Infrastructure.InMemory;

public class InMemoryUserService : IUserService
{
    private readonly InMemoryDataStore _db;
    public InMemoryUserService(InMemoryDataStore db) { _db = db; }

    public IEnumerable<UserDto> GetAll() => _db.Users.Select(Map);

    public PagedResult<UserDto> GetPaged(int page, int pageSize, string? search = null, string? sortBy = null, bool desc = false)
    {
        if (page < 1) page = 1; if (pageSize < 1) pageSize = 10;
        IEnumerable<Domain.Entities.User> query = _db.Users;
        if (!string.IsNullOrWhiteSpace(search))
        {
            var s = search.Trim();
            query = query.Where(u => (u.Username?.Contains(s, StringComparison.OrdinalIgnoreCase) ?? false)
                                   || (u.DisplayName?.Contains(s, StringComparison.OrdinalIgnoreCase) ?? false));
        }
        var total = query.Count();
        Func<Domain.Entities.User, object> keySel = (sortBy?.ToLowerInvariant()) switch
        {
            "displayname" => u => u.DisplayName ?? string.Empty,
            "isactive" => u => u.IsActive,
            _ => u => u.Username ?? string.Empty
        };
        query = desc ? query.OrderByDescending(keySel) : query.OrderBy(keySel);
        var items = query.Skip((page - 1) * pageSize).Take(pageSize).Select(Map).ToList();
        var totalPages = (int)Math.Ceiling(total / (double)pageSize);
        return new PagedResult<UserDto>(items, total, page, pageSize, totalPages);
    }

    public UserDto? GetById(Guid id)
        => _db.Users.Where(u => u.Id == id).Select(Map).FirstOrDefault();

    public UserDto Create(string username, string displayName, string password, bool isActive, Guid[]? roleIds = null)
    {
        // Enforce unique Username (case-insensitive)
        if (_db.Users.Any(x => string.Equals(x.Username, username, StringComparison.OrdinalIgnoreCase)))
            throw new InvalidOperationException("Username already exists");
        var user = new User
        {
            Username = username,
            DisplayName = displayName,
            PasswordHash = string.IsNullOrWhiteSpace(password) ? "a12345" : password,
            IsActive = isActive
        };
        if (roleIds != null && roleIds.Length > 0)
        {
            var roles = _db.Roles.Where(r => roleIds.Contains(r.Id)).ToList();
            foreach (var r in roles)
            {
                if (!user.Roles.Any(x => x.Id == r.Id)) user.Roles.Add(r);
            }
        }
        _db.Users.Add(user);
        return Map(user);
    }

    public bool Update(Guid id, string username, string displayName, bool isActive, string? newPassword = null)
    {
        var u = _db.Users.FirstOrDefault(x => x.Id == id);
        if (u == null) return false;
        // Enforce unique Username excluding current (case-insensitive)
        if (_db.Users.Any(x => x.Id != id && string.Equals(x.Username, username, StringComparison.OrdinalIgnoreCase)))
            throw new InvalidOperationException("Username already exists");
        u.Username = username;
        u.DisplayName = displayName;
        u.IsActive = isActive;
        if (!string.IsNullOrWhiteSpace(newPassword))
            u.PasswordHash = newPassword;
        return true;
    }

    public bool ResetPassword(Guid userId, string? newPassword = null)
    {
        var u = _db.Users.FirstOrDefault(x => x.Id == userId);
        if (u == null) return false;
        u.PasswordHash = string.IsNullOrWhiteSpace(newPassword) ? "a12345" : newPassword;
        return true;
    }

    public bool ChangePassword(Guid userId, string oldPassword, string newPassword)
    {
        var u = _db.Users.FirstOrDefault(x => x.Id == userId);
        if (u == null) return false;
        if (u.PasswordHash != oldPassword) return false;
        u.PasswordHash = newPassword;
        return true;
    }

    public bool AssignRole(Guid userId, Guid roleId)
    {
        var user = _db.Users.FirstOrDefault(u => u.Id == userId);
        var role = _db.Roles.FirstOrDefault(r => r.Id == roleId);
        if (user == null || role == null) return false;
        if (!user.Roles.Any(r => r.Id == role.Id)) user.Roles.Add(role);
        return true;
    }

    public bool Delete(Guid id)
    {
        var user = _db.Users.FirstOrDefault(u => u.Id == id);
        if (user == null) return false;
        _db.Users.Remove(user);
        return true;
    }

    public bool UpdateProfileImage(Guid id, string? profileImageUrl)
    {
        var u = _db.Users.FirstOrDefault(x => x.Id == id);
        if (u == null) return false;
        u.ProfileImageUrl = profileImageUrl;
        return true;
    }

    public PagedResult<UserDto> GetByRole(Guid roleId, int page, int pageSize, string? search = null, string? sortBy = null, bool desc = false)
    {
        if (page < 1) page = 1; if (pageSize < 1) pageSize = 10;
        IEnumerable<Domain.Entities.User> query = _db.Users.Where(u => u.Roles.Any(r => r.Id == roleId));
        if (!string.IsNullOrWhiteSpace(search))
        {
            var s = search.Trim();
            query = query.Where(u => (u.Username?.Contains(s, StringComparison.OrdinalIgnoreCase) ?? false)
                                   || (u.DisplayName?.Contains(s, StringComparison.OrdinalIgnoreCase) ?? false)
                                   || u.Id.ToString().Contains(s, StringComparison.OrdinalIgnoreCase));
        }
        var total = query.Count();
        Func<Domain.Entities.User, object> keySel = (sortBy?.ToLowerInvariant()) switch
        {
            "displayname" => u => u.DisplayName ?? string.Empty,
            "isactive" => u => u.IsActive,
            _ => u => u.Username ?? string.Empty
        };
        query = desc ? query.OrderByDescending(keySel) : query.OrderBy(keySel);
        var items = query.Skip((page - 1) * pageSize).Take(pageSize).Select(Map).ToList();
        var totalPages = (int)Math.Ceiling(total / (double)pageSize);
        return new PagedResult<UserDto>(items, total, page, pageSize, totalPages);
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

