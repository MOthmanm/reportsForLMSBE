using StartBack.Application.DTOs;

namespace StartBack.Application.Abstractions;

public interface IRoleService
{
    IEnumerable<RoleDto> GetAll();
    PagedResult<RoleDto> GetPaged(int page, int pageSize, string? search = null, string? sortBy = null, bool desc = false);
    RoleDto? GetById(Guid id);
    RoleDto Create(string name, string? defaultPageUrl);
    bool Update(Guid id, string name, string? defaultPageUrl);
    bool Delete(Guid id);
    bool AssignPermission(Guid roleId, Guid permissionId);
    bool RemovePermission(Guid roleId, Guid permissionId);
}

