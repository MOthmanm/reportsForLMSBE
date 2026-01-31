namespace StartBack.Application.DTOs;

public record UserRoleDto(Guid Id, string Name, string? DefaultPageUrl);

public record UserDto(
    Guid Id,
    string Username,
    string DisplayName,
    bool IsActive,
    string? ProfileImageUrl,
    UserRoleDto[] Roles,
    string[] Permissions);


