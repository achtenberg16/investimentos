using System.Linq;
using System.Threading.Tasks;
using Application.Dto;
using Application.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("/v1/contas")]
public class AccountsController : ControllerBase
{
    
    private readonly IAccountService _serviceApplication;

    public AccountsController(IAccountService service)
    {
        _serviceApplication = service;
    }
    [HttpGet("saldo")]
    [Authorize]
    public  IActionResult GetAccountBalance()
    {
        var accountId = int.Parse(User.Claims.ToList()[0].Value);
        var accountBalance =  _serviceApplication.GetAccountBalance(accountId);
        if (accountBalance is null) return BadRequest(new {message = "conta não encontrada"});
        return Ok(accountBalance);
    }

    [HttpGet("extrato")]
    [Authorize]
    public async Task<IActionResult> AccountStatement()
    {
        var accountId = int.Parse(User.Claims.ToList()[0].Value);
        var result = await _serviceApplication.GetAccountStatement(accountId);
        if (result is null) return NotFound(new { message = "conta não encontrada" });
        return Ok(result);
    }

    [HttpPost("deposito")]
    [Authorize]
    public IActionResult Deposit([FromBody] TransactionValueDto transactionInfos)
    {
        var accountId = int.Parse(User.Claims.ToList()[0].Value);
        var ErrorMessage = _serviceApplication.Deposit(accountId, transactionInfos);
        if (ErrorMessage is null)  return Ok();
        return BadRequest(new { message = ErrorMessage });
    }
    
    [HttpPost("retirada")]
    [Authorize]
    public IActionResult Withdrawal([FromBody] TransactionValueDto transactionInfos)
    {
        var accountId = int.Parse(User.Claims.ToList()[0].Value);
        var ErrorMessage = _serviceApplication.Withdrawal(accountId, transactionInfos);
        if (ErrorMessage is null)  return Ok();
        return BadRequest(new { message = ErrorMessage });
    }
}