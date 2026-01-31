using StartBack.Application.DTOs;

namespace StartBack.Application.Abstractions;

public interface IMenuService
{
    IEnumerable<MenuItemDto> GetMenuForUser(Guid userId);
}


