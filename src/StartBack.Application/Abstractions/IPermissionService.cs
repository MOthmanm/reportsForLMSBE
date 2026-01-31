using StartBack.Application.DTOs;

namespace StartBack.Application.Abstractions;

public interface IPermissionService
{
    IEnumerable<PermissionDto> GetAll();
    PagedResult<PermissionDto> GetPaged(int page, int pageSize, string? search = null, string? sortBy = null, bool desc = false);
    PermissionDto? GetById(Guid id);
    PermissionDto Create(string code, string name);
    bool Update(Guid id, string code, string name);
    bool Delete(Guid id);
}

