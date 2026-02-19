using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using StartBack.Application.DTOs;
using StartBack.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace StartBack.Infrastructure.Auth;

public interface IJwtTokenService
{
    string CreateToken(User user, UserDto dto, IEnumerable<string> permissionCodes);
}

public class JwtTokenService : IJwtTokenService
{
    private readonly JwtOptions _options;
    public JwtTokenService(IOptions<JwtOptions> options) { _options = options.Value; }

    public string CreateToken(User user, UserDto dto, IEnumerable<string> permissionCodes)
    {
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new(JwtRegisteredClaimNames.UniqueName, user.Username),
            new("display_name", dto.DisplayName),
            new("tenant_id", "default") // Required by InsightEngine
        };
        // roles
        claims.AddRange(dto.Roles.Select(r => new Claim(ClaimTypes.Role, r.Name)));
        // permissions
        claims.AddRange(permissionCodes.Select(p => new Claim("perm", p)));

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Key));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            issuer: _options.Issuer,
            audience: _options.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_options.ExpireMinutes),
            signingCredentials: creds
        );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}


