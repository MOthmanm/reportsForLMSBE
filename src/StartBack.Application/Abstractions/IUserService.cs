using StartBack.Application.DTOs;

namespace StartBack.Application.Abstractions;

public interface IUserService
{
    IEnumerable<UserDto> GetAll();
    PagedResult<UserDto> GetPaged(int page, int pageSize, string? search = null, string? sortBy = null, bool desc = false);
    UserDto? GetById(Guid id);
    UserDto Create(string username, string displayName, string password, bool isActive, Guid[]? roleIds = null);
    bool Update(Guid id, string username, string displayName, bool isActive, string? newPassword = null);
    bool UpdateProfileImage(Guid id, string? profileImageUrl);
    bool AssignRole(Guid userId, Guid roleId);
    PagedResult<UserDto> GetByRole(Guid roleId, int page, int pageSize, string? search = null, string? sortBy = null, bool desc = false);
    bool Delete(Guid id);
    bool ResetPassword(Guid userId, string? newPassword = null);
    bool ChangePassword(Guid userId, string oldPassword, string newPassword);
}

