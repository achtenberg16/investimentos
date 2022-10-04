using infrastructure.Context;
using infrastructure.JWT;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("/v1/[controller]")]
public class LoginController : ControllerBase
{
    private readonly JwtToken _jwt;
    private readonly Context _context;
    public LoginController(JwtToken jwt, Context context)
    {
        _jwt = jwt;
        _context = context;
    }

    [HttpPost]
    public IActionResult Login([FromBody] LoginDto loginInfos)
    {
        var user = _context.Users.First(u => u.Email == loginInfos.email && u.Password == loginInfos.password);
        if (user is null) return Unauthorized();
        var token = _jwt.Create(user.Id);
        return Ok(token);
    }
}

public class LoginDto
{
    public string email { get; set; }
    public string password { get; set; }
}