using StartBack.Application.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StartBack.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MenuController : ControllerBase
{
    private readonly IMenuService _menu;
    public MenuController(IMenuService menu) { _menu = menu; }

    [HttpGet("{userId:guid}")]
    [Authorize]
    public IActionResult GetForUser(Guid userId) => Ok(_menu.GetMenuForUser(userId));
}

