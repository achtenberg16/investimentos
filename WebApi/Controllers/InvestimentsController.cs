using Application.Dto;
using Application.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("/v1/investimentos")]
public class InvestimentsController : ControllerBase
{
    private readonly IInvestimentsService _serviceApplication;

    public InvestimentsController(IInvestimentsService service)
    {
        _serviceApplication = service;
    }
    [HttpPost("comprar")]
    [Authorize]
    public IActionResult Buy([FromBody] InvestimentTransactionDto infos)
    {
        var accountId = int.Parse(User.Claims.ToList()[0].Value);
        var errorMessage = _serviceApplication.Buy(accountId, infos);
        if(errorMessage is null) return Ok();
        return BadRequest(new { message = errorMessage });
    }
    
    [HttpPost("vender")]
    [Authorize]
    public IActionResult Sell([FromBody] InvestimentTransactionDto infos)
    {
        var accountId = int.Parse(User.Claims.ToList()[0].Value);
        var errorMessage = _serviceApplication.Sell(accountId, infos);
        if(errorMessage is null) return Ok();
        return BadRequest(new { message = errorMessage });
    }
}