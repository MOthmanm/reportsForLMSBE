namespace StartBack.Application.DTOs;

public record MenuItemDto(
    string Key,
    string Title,
    string? TitleEn,
    string? TitleAr,
    string? Url,
    string? ParentKey,
    string? IconKey,
    int Order,
    string[]? RequiredPermissionCodes,
    IReadOnlyList<MenuItemDto> Children
);

public record MenuItemAdminDto(
    Guid Id,
    string Key,
    string Title,
    string? TitleEn,
    string? TitleAr,
    string? Url,
    Guid? ParentId,
    Guid? IconId,
    string? IconKey,
    int Order,
    string[]? RequiredPermissionCodes,
    IReadOnlyList<MenuItemAdminDto> Children
);

