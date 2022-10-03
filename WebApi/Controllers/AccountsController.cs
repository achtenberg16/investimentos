using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("/v1/conta")]
public class AccountsController : ControllerBase
{
    [HttpGet("{clientId}")]
    public  IActionResult GetAccountBalance()
    {
        return Ok();
    }
}