using StartBack.Application.DTOs;

namespace StartBack.Application.Abstractions;

public record LoginRequest(string Username, string Password);
public record RefreshRequest(string RefreshToken);
public record AuthResult(bool Success, string? Message, UserDto? User, string? Token, string? RefreshToken);

public interface IAuthService
{
    AuthResult Login(LoginRequest request);
    AuthResult Refresh(RefreshRequest request);
    bool Revoke(RefreshRequest request);
}

