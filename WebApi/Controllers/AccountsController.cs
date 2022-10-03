using Application.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("/v1/conta")]
public class AccountsController : ControllerBase
{
    
    private readonly IAccountService _service;

    public AccountsController(IAccountService service)
    {
        _service = service;
    }
    [HttpGet("{clientId:int}")]
    public async Task<IActionResult> GetAccountBalance([FromRoute]int clientId)
    {
        var accountBalance = await _service.GetAccountBalance(clientId);
        if (accountBalance is null) return BadRequest(new {message = "conta não encontrada"});
        return Ok(accountBalance);
    }

    [HttpGet("/extrato/{clientId:int}")]
    public async Task<IActionResult> AccountStatement([FromRoute] int clientId)
    {
        return Ok();
    }
}