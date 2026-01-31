using StartBack.Application.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace StartBack.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _users;
    public UsersController(IUserService users) { _users = users; }

    [HttpGet]
    [Authorize(Policy = "Users.Read")]
    public IActionResult GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 20,
        [FromQuery] string? search = null, [FromQuery] string? sortBy = null, [FromQuery] bool desc = false)
        => Ok(_users.GetPaged(page, pageSize, search, sortBy, desc));

    public record CreateUserRequest(string Username, string DisplayName, string? Password, bool IsActive, Guid[]? RoleIds);

    [HttpPost]
    [Authorize(Policy = "Users.Create")]
    public IActionResult Create([FromBody] CreateUserRequest req)
    {
        try
        {
            var defaultOrProvidedPassword = string.IsNullOrWhiteSpace(req.Password) ? "a12345" : req.Password;
            var user = _users.Create(req.Username, req.DisplayName, defaultOrProvidedPassword, req.IsActive, req.RoleIds);
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new { message = ex.Message });
        }
    }

    [HttpGet("{id:guid}")]
    [Authorize(Policy = "Users.Read")]
    public IActionResult GetById(Guid id)
    {
        var u = _users.GetById(id);
        return u is null ? NotFound() : Ok(u);
    }

    public record UpdateUserRequest(string Username, string DisplayName, bool IsActive, string? NewPassword);
    [HttpPut("{id:guid}")]
    [Authorize(Policy = "Users.Update")]
    public IActionResult Update(Guid id, [FromBody] UpdateUserRequest req)
    {
        try
        {
            var ok = _users.Update(id, req.Username, req.DisplayName, req.IsActive, req.NewPassword);
            return ok ? NoContent() : NotFound();
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new { message = ex.Message });
        }
    }

    [HttpPost("{id:guid}/reset-password")]
    [Authorize(Policy = "Users.Update")]
    public IActionResult ResetPassword(Guid id)
    {
        var ok = _users.ResetPassword(id, null);
        return ok ? NoContent() : NotFound();
    }

    public record ChangeMyPasswordRequest(string OldPassword, string NewPassword);
    [HttpPost("me/change-password")]
    [Authorize]
    public IActionResult ChangeMyPassword([FromBody] ChangeMyPasswordRequest req)
    {
        var userIdClaim = User.FindFirst("sub")?.Value ?? User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrWhiteSpace(userIdClaim) || !Guid.TryParse(userIdClaim, out var userId)) return Unauthorized();
        var ok = _users.ChangePassword(userId, req.OldPassword, req.NewPassword);
        if (!ok) return BadRequest(new { message = "Old password is incorrect or user not found" });
        return NoContent();
    }

    [HttpGet("{id:guid}/avatar")]
    [Authorize]
    public IActionResult GetAvatar(Guid id)
    {
        var dto = _users.GetById(id);
        if (dto is null) return NotFound();
        if (string.IsNullOrWhiteSpace(dto.ProfileImageUrl)) return NoContent();
        return Ok(new { url = dto.ProfileImageUrl });
    }

    [HttpPost("{id:guid}/avatar")] 
    [Authorize(Policy = "Users.Update")]
    [RequestSizeLimit(10_000_000)]
    public async Task<IActionResult> UploadAvatar(Guid id, IFormFile file)
    {
        if (file == null || file.Length == 0) return BadRequest(new { message = "No file uploaded" });
        var uploadsDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "avatars");
        Directory.CreateDirectory(uploadsDir);
        var ext = Path.GetExtension(file.FileName).ToLowerInvariant();
        var allowed = new[] { ".jpg", ".jpeg", ".png", ".gif", ".webp" };
        if (!allowed.Contains(ext)) return BadRequest(new { message = "Unsupported file type" });
        // Delete any existing avatar for this user (any extension)
        var existing = Directory.GetFiles(uploadsDir, $"{id}.*");
        foreach (var path in existing)
        {
            try { System.IO.File.Delete(path); } catch { /* ignore */ }
        }
        var fileName = $"{id}{ext}";
        var fullPath = Path.Combine(uploadsDir, fileName);
        using (var stream = new FileStream(fullPath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }
        var publicUrl = $"/avatars/{fileName}";
        var ok = _users.UpdateProfileImage(id, publicUrl);
        // Add cache-busting query to avoid browser caching the previous image
        var cacheBustedUrl = $"{publicUrl}?v={DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";
        return ok ? Ok(new { url = cacheBustedUrl }) : NotFound();
    }

    [HttpPost("{userId:guid}/roles/{roleId:guid}")]
    [Authorize(Policy = "Users.Delete")]
    public IActionResult AssignRole(Guid userId, Guid roleId)
    {
        var ok = _users.AssignRole(userId, roleId);
        return ok ? NoContent() : NotFound();
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Policy = "Users.Manage")]
    public IActionResult Delete(Guid id)
    {
        var ok = _users.Delete(id);
        return ok ? NoContent() : NotFound();
    }
}

