using StartBack.Application.DTOs;

namespace StartBack.Application.Abstractions;

public interface IMenuAdminService
{
    IEnumerable<MenuItemDto> GetAllMenu(); // الحصول على جميع عناصر القائمة كشجرة للإدارة (بدون Id)
    IEnumerable<MenuItemAdminDto> GetAdminTree(); // شجرة الإدارة مع المعرفات
    MenuItemAdminDto? GetById(Guid id);
    MenuItemDto Create(string key, string title, string? url, Guid? parentId, int order, IEnumerable<string> requiredPermissionCodes, Guid? iconId, string? titleEn = null, string? titleAr = null);
    bool Update(Guid id, string title, string? url, Guid? parentId, int order, IEnumerable<string> requiredPermissionCodes, Guid? iconId, string? titleEn = null, string? titleAr = null);
    bool Delete(Guid id);
}

