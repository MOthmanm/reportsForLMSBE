using StartBack.Application.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StartBack.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PermissionsController : ControllerBase
{
    private readonly IPermissionService _perms;
    public PermissionsController(IPermissionService perms) { _perms = perms; }

    [HttpGet]
    [Authorize(Policy = "Permissions.Read")]
    public IActionResult GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 50,
        [FromQuery] string? search = null, [FromQuery] string? sortBy = null, [FromQuery] bool desc = false)
        => Ok(_perms.GetPaged(page, pageSize, search, sortBy, desc));

    [HttpGet("{id:guid}")]
    [Authorize(Policy = "Permissions.Read")]
    public IActionResult GetById(Guid id)
    {
        var p = _perms.GetById(id);
        return p is null ? NotFound() : Ok(p);
    }

    public record CreatePermissionRequest(string Code, string Name);
    [HttpPost]
    [Authorize(Policy = "Permissions.Create")]
    public IActionResult Create([FromBody] CreatePermissionRequest req)
    {
        var p = _perms.Create(req.Code, req.Name);
        return CreatedAtAction(nameof(GetById), new { id = p.Id }, p);
    }

    public record UpdatePermissionRequest(string Code, string Name);
    [HttpPut("{id:guid}")]
    [Authorize(Policy = "Permissions.Update")]
    public IActionResult Update(Guid id, [FromBody] UpdatePermissionRequest req)
    {
        var ok = _perms.Update(id, req.Code, req.Name);
        return ok ? NoContent() : NotFound();
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Policy = "Permissions.Delete")]
    public IActionResult Delete(Guid id)
    {
        var ok = _perms.Delete(id);
        return ok ? NoContent() : NotFound();
    }
}

