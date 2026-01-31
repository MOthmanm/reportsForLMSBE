namespace StartBack.Application.DTOs;

public record RoleDto(Guid Id, string Name, string? DefaultPageUrl, string[] Permissions);


