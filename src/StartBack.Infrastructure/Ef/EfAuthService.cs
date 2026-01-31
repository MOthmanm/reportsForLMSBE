using StartBack.Application.Abstractions;
using StartBack.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using StartBack.Domain.Entities;
using StartBack.Infrastructure.Auth;
using StartBack.Infrastructure.Persistence.UnitOfWork;

namespace StartBack.Infrastructure.Ef;

public class EfAuthService : IAuthService
{
    private readonly EfUserService _usersService;
    private readonly IRepository<StartBack.Domain.Entities.User> _users;
    private readonly IRepository<RefreshToken> _refreshTokens;
    private readonly IUnitOfWork _uow;
    private readonly JwtOptions _jwtOptions;
    public EfAuthService(EfUserService usersService,
                         IRepository<StartBack.Domain.Entities.User> users,
                         IRepository<RefreshToken> refreshTokens,
                         IUnitOfWork uow,
                         Microsoft.Extensions.Options.IOptions<JwtOptions> jwt)
    { _usersService = usersService; _users = users; _refreshTokens = refreshTokens; _uow = uow; _jwtOptions = jwt.Value; }

    public AuthResult Login(LoginRequest request)
    {
        var u = _users.Query().Where(x => x.IsActive && x.Username == request.Username && x.PasswordHash == request.Password)
            .FirstOrDefault();
        if (u == null) return new AuthResult(false, "Invalid username or password", null, null, null);
        var dto = _usersService.GetById(u.Id);
        // Access token is generated at API layer using JwtTokenService to avoid coupling
        // Generate refresh token and persist
        var rt = new RefreshToken
        {
            UserId = u.Id,
            Token = Convert.ToBase64String(Guid.NewGuid().ToByteArray()) + Convert.ToBase64String(Guid.NewGuid().ToByteArray()),
            ExpiresAt = DateTime.UtcNow.AddDays(_jwtOptions.RefreshTokenExpireDays)
        };
        _refreshTokens.AddAsync(rt).GetAwaiter().GetResult();
        _uow.SaveChangesAsync().GetAwaiter().GetResult();
        return new AuthResult(true, null, dto, null, rt.Token);
    }

    public AuthResult Refresh(RefreshRequest request)
    {
        var rt = _refreshTokens.Query().FirstOrDefault(x => x.Token == request.RefreshToken);
        if (rt == null || rt.RevokedAt != null || rt.ExpiresAt < DateTime.UtcNow)
            return new AuthResult(false, "Invalid refresh token", null, null, null);
        var u = _users.Query().FirstOrDefault(x => x.Id == rt.UserId);
        if (u == null) return new AuthResult(false, "User not found", null, null, null);
        var dto = _usersService.GetById(u.Id);
        // rotate refresh token
        var newRt = new RefreshToken
        {
            UserId = u.Id,
            Token = Convert.ToBase64String(Guid.NewGuid().ToByteArray()) + Convert.ToBase64String(Guid.NewGuid().ToByteArray()),
            ExpiresAt = DateTime.UtcNow.AddDays(_jwtOptions.RefreshTokenExpireDays)
        };
        rt.RevokedAt = DateTime.UtcNow;
        rt.ReplacedByToken = newRt.Token;
        _refreshTokens.AddAsync(newRt).GetAwaiter().GetResult();
        _uow.SaveChangesAsync().GetAwaiter().GetResult();
        return new AuthResult(true, null, dto, null, newRt.Token);
    }

    public bool Revoke(RefreshRequest request)
    {
        var rt = _refreshTokens.Query().FirstOrDefault(x => x.Token == request.RefreshToken);
        if (rt == null || rt.RevokedAt != null) return false;
        rt.RevokedAt = DateTime.UtcNow;
        _uow.SaveChangesAsync().GetAwaiter().GetResult();
        return true;
    }
}

