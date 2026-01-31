using StartBack.Application.DTOs;

namespace StartBack.Application.Abstractions;

public interface IIconService
{
    IEnumerable<IconDto> GetAll();
    IconDto? GetById(Guid id);
    IconDto Create(string key, string? displayName);
    bool Update(Guid id, string key, string? displayName);
    bool Delete(Guid id);
}


