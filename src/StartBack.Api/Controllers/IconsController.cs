using StartBack.Application.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StartBack.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IconsController : ControllerBase
{
    private readonly IIconService _icons;
    public IconsController(IIconService icons) { _icons = icons; }

    [HttpGet]
    [Authorize(Policy = "Menus.Read")]
    public IActionResult GetAll() => Ok(_icons.GetAll());

    [HttpGet("{id:guid}")]
    [Authorize(Policy = "Menus.Read")]
    public IActionResult GetById(Guid id)
    {
        var i = _icons.GetById(id);
        return i is null ? NotFound() : Ok(i);
    }

    public record UpsertIconRequest(string Key, string? DisplayName);

    [HttpPost]
    [Authorize(Policy = "Menus.Create")]
    public IActionResult Create([FromBody] UpsertIconRequest req)
    {
        try
        {
            var i = _icons.Create(req.Key, req.DisplayName);
            return CreatedAtAction(nameof(GetById), new { id = i.Id }, i);
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new { message = ex.Message });
        }
    }

    [HttpPut("{id:guid}")]
    [Authorize(Policy = "Menus.Update")]
    public IActionResult Update(Guid id, [FromBody] UpsertIconRequest req)
    {
        try
        {
            var ok = _icons.Update(id, req.Key, req.DisplayName);
            return ok ? NoContent() : NotFound();
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new { message = ex.Message });
        }
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Policy = "Menus.Delete")]
    public IActionResult Delete(Guid id)
    {
        var ok = _icons.Delete(id);
        return ok ? NoContent() : NotFound();
    }
}

