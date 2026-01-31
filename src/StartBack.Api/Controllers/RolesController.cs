using StartBack.Application.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StartBack.Application.Abstractions;

namespace StartBack.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RolesController : ControllerBase
{
    private readonly IRoleService _roles;
    private readonly IUserService _users;
    public RolesController(IRoleService roles, IUserService users) { _roles = roles; _users = users; }

    [HttpGet]
    [Authorize(Policy = "Roles.Read")]
    public IActionResult GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 20,
        [FromQuery] string? search = null, [FromQuery] string? sortBy = null, [FromQuery] bool desc = false)
        => Ok(_roles.GetPaged(page, pageSize, search, sortBy, desc));

    [HttpGet("{id:guid}")]
    [Authorize(Policy = "Roles.Read")]
    public IActionResult GetById(Guid id)
    {
        var r = _roles.GetById(id);
        return r is null ? NotFound() : Ok(r);
    }

    public record CreateRoleRequest(string Name, string? DefaultPageUrl);
    [HttpPost]
    [Authorize(Policy = "Roles.Create")]
    public IActionResult Create([FromBody] CreateRoleRequest req)
    {
        var r = _roles.Create(req.Name, req.DefaultPageUrl);
        return CreatedAtAction(nameof(GetById), new { id = r.Id }, r);
    }

    public record UpdateRoleRequest(string Name, string? DefaultPageUrl);
    [HttpPut("{id:guid}")]
    [Authorize(Policy = "Roles.Update")]
    public IActionResult Update(Guid id, [FromBody] UpdateRoleRequest req)
    {
        var ok = _roles.Update(id, req.Name, req.DefaultPageUrl);
        return ok ? NoContent() : NotFound();
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Policy = "Roles.Delete")]
    public IActionResult Delete(Guid id)
    {
        var ok = _roles.Delete(id);
        return ok ? NoContent() : NotFound();
    }

    [HttpPost("{roleId:guid}/permissions/{permissionId:guid}")]
    [Authorize(Policy = "Roles.Update")]
    public IActionResult AssignPermission(Guid roleId, Guid permissionId)
    {
        var ok = _roles.AssignPermission(roleId, permissionId);
        return ok ? NoContent() : NotFound();
    }

    [HttpDelete("{roleId:guid}/permissions/{permissionId:guid}")]
    [Authorize(Policy = "Roles.Update")]
    public IActionResult RemovePermission(Guid roleId, Guid permissionId)
    {
        var ok = _roles.RemovePermission(roleId, permissionId);
        return ok ? NoContent() : NotFound();
    }

    [HttpGet("{roleId:guid}/users")]
    [Authorize(Policy = "Users.Read")]
    public IActionResult GetUsers(Guid roleId, [FromQuery] int page = 1, [FromQuery] int pageSize = 20,
        [FromQuery] string? search = null, [FromQuery] string? sortBy = null, [FromQuery] bool desc = false)
        => Ok(_users.GetByRole(roleId, page, pageSize, search, sortBy, desc));

    [HttpPost("{roleId:guid}/users/{userId:guid}")]
    [Authorize(Policy = "Users.Update")]
    public IActionResult AddUser(Guid roleId, Guid userId)
    {
        var ok = _users.AssignRole(userId, roleId);
        return ok ? NoContent() : NotFound();
    }
}

