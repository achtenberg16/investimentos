using Application.Dto;
using Application.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("/v1/[controller]")]
public class LoginController : ControllerBase
{
    private readonly IUsersService _usersService;

    public LoginController(IUsersService usersService)
    {
        _usersService = usersService;
    }
    [HttpPost]
    [AllowAnonymous]
    public IActionResult Login([FromBody] LoginDto loginInfos)
    {
        var token = _usersService.Login(loginInfos);
        if (token is null) return Unauthorized();
        return Ok(new {token});
    }
}

