using StartBack.Application.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StartBack.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MenuAdminController : ControllerBase
{
    private readonly IMenuAdminService _menuAdmin;
    public MenuAdminController(IMenuAdminService menuAdmin) { _menuAdmin = menuAdmin; }

    public record UpsertMenuRequest(string Key, string Title, string? TitleEn, string? TitleAr, string? Url, Guid? ParentId, int Order, string[] RequiredPermissionCodes, Guid? IconId);

    [HttpGet("tree-with-ids")]
    [Authorize(Policy = "Menus.Read")]
    public IActionResult GetAdminTree()
    {
        var menu = _menuAdmin.GetAdminTree();
        return Ok(menu);
    }

    [HttpGet("{id:guid}")]
    [Authorize(Policy = "Menus.Read")]
    public IActionResult GetById(Guid id)
    {
        var m = _menuAdmin.GetById(id);
        return m is null ? NotFound() : Ok(m);
    }

    [HttpGet]
    [Authorize(Policy = "Menus.Read")]
    public IActionResult GetAllMenu()
    {
        var menu = _menuAdmin.GetAllMenu();
        return Ok(menu);
    }

    [HttpPost]
    [Authorize(Policy = "Menus.Create")]
    public IActionResult Create([FromBody] UpsertMenuRequest req)
    {
        var m = _menuAdmin.Create(req.Key, req.Title, req.Url, req.ParentId, req.Order, req.RequiredPermissionCodes, req.IconId, req.TitleEn, req.TitleAr);
        return CreatedAtAction(nameof(Create), new { key = m.Key }, m);
    }

    [HttpPut("{id:guid}")]
    [Authorize(Policy = "Menus.Update")]
    public IActionResult Update(Guid id, [FromBody] UpsertMenuRequest req)
    {
        var ok = _menuAdmin.Update(id, req.Title, req.Url, req.ParentId, req.Order, req.RequiredPermissionCodes, req.IconId, req.TitleEn, req.TitleAr);
        return ok ? NoContent() : NotFound();
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Policy = "Menus.Delete")]
    public IActionResult Delete(Guid id)
    {
        var ok = _menuAdmin.Delete(id);
        return ok ? NoContent() : NotFound();
    }
}

