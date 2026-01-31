using StartBack.Application.Abstractions;
using StartBack.Infrastructure.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace StartBack.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _auth;
    private readonly IJwtTokenService _jwt;
    public AuthController(IAuthService auth, IJwtTokenService jwt) { _auth = auth; _jwt = jwt; }

    [HttpPost("login")]
    [AllowAnonymous]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        var result = _auth.Login(request);
        if (!result.Success || result.User is null) return Unauthorized(new { message = result.Message });
        // Create token with permissions from user dto
        var token = _jwt.CreateToken(new StartBack.Domain.Entities.User { Id = result.User.Id, Username = result.User.Username, DisplayName = result.User.DisplayName }, result.User, result.User.Permissions);
        return Ok(new { token, refreshToken = result.RefreshToken, user = result.User });
    }

    [HttpPost("refresh")]
    [AllowAnonymous]
    public IActionResult Refresh([FromBody] RefreshRequest request)
    {
        var result = _auth.Refresh(request);
        if (!result.Success || result.User is null) return Unauthorized(new { message = result.Message });
        var token = _jwt.CreateToken(new StartBack.Domain.Entities.User { Id = result.User.Id, Username = result.User.Username, DisplayName = result.User.DisplayName }, result.User, result.User.Permissions);
        return Ok(new { token, refreshToken = result.RefreshToken, user = result.User });
    }

    [HttpPost("logout")]
    [AllowAnonymous]
    public IActionResult Logout([FromBody] RefreshRequest request)
    {
        var ok = _auth.Revoke(request);
        return ok ? NoContent() : BadRequest(new { message = "Invalid refresh token" });
    }
}

