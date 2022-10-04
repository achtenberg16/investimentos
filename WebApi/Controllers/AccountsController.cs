using Application.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("/v1/conta")]
public class AccountsController : ControllerBase
{
    
    private readonly IAccountService _serviceApplication;

    public AccountsController(IAccountService service)
    {
        _serviceApplication = service;
    }
    [HttpGet("{clientId:int}")]
    [Authorize]
    public async Task<IActionResult> GetAccountBalance([FromRoute]int clientId)
    {   
        if (int.Parse(User.Claims.ToList()[0].Value) != clientId) return Unauthorized();
        var accountBalance = await _serviceApplication.GetAccountBalance(clientId);
        if (accountBalance is null) return BadRequest(new {message = "conta não encontrada"});
        return Ok(accountBalance);
    }

    [HttpGet("/v1/conta/extrato/{clientId:int}")]
    [Authorize]
    public async Task<IActionResult> AccountStatement([FromRoute] int clientId)
    {
        if (int.Parse(User.Claims.ToList()[0].Value) != clientId) return Unauthorized();
        var result = await _serviceApplication.GetAccountStatement(clientId);
        if (result is null) return NotFound(new {message = "conta não encontrada"});
        return Ok(result);
    }
}