using StartBack.Application.Abstractions;
using StartBack.Domain.Entities;

namespace StartBack.Infrastructure.InMemory;

public class InMemoryAuthService : IAuthService
{
    private readonly InMemoryDataStore _db;
    private readonly InMemoryUserService _users;
    public InMemoryAuthService(InMemoryDataStore db)
    {
        _db = db;
        _users = new InMemoryUserService(db);
    }

    public AuthResult Login(LoginRequest request)
    {
        var u = _db.Users.FirstOrDefault(x => x.Username.Equals(request.Username, StringComparison.OrdinalIgnoreCase)
                                              && x.PasswordHash == request.Password && x.IsActive);
        if (u == null) return new AuthResult(false, "Invalid username or password", null, null, null);
        var dto = _users.GetById(u.Id);
        var rt = new RefreshToken
        {
            UserId = u.Id,
            Token = Guid.NewGuid().ToString("N") + Guid.NewGuid().ToString("N"),
            ExpiresAt = DateTime.UtcNow.AddDays(7)
        };
        _db.RefreshTokens.Add(rt);
        return new AuthResult(true, null, dto, null, rt.Token);
    }

    public AuthResult Refresh(RefreshRequest request)
    {
        var rt = _db.RefreshTokens.FirstOrDefault(x => x.Token == request.RefreshToken && x.RevokedAt == null && x.ExpiresAt > DateTime.UtcNow);
        if (rt == null) return new AuthResult(false, "Invalid refresh token", null, null, null);
        var u = _db.Users.FirstOrDefault(x => x.Id == rt.UserId);
        if (u == null) return new AuthResult(false, "User not found", null, null, null);
        var dto = _users.GetById(u.Id);
        var newRt = new RefreshToken { UserId = u.Id, Token = Guid.NewGuid().ToString("N") + Guid.NewGuid().ToString("N"), ExpiresAt = DateTime.UtcNow.AddDays(7) };
        rt.RevokedAt = DateTime.UtcNow; rt.ReplacedByToken = newRt.Token;
        _db.RefreshTokens.Add(newRt);
        return new AuthResult(true, null, dto, null, newRt.Token);
    }

    public bool Revoke(RefreshRequest request)
    {
        var rt = _db.RefreshTokens.FirstOrDefault(x => x.Token == request.RefreshToken && x.RevokedAt == null);
        if (rt == null) return false;
        rt.RevokedAt = DateTime.UtcNow;
        return true;
    }
}

