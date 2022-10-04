using Application.Dto;
using Application.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("/v1/ativos")]
public class ActivesController : ControllerBase
{
    private readonly IActivesService _serviceApplication;

    public ActivesController(IActivesService service)
    {
        _serviceApplication = service;
    }
    
    [HttpGet]
    [AllowAnonymous]
    public IActionResult GetActives()
    {
        var actives =  _serviceApplication.GetActives();
        return Ok(actives);
    }
    
    [HttpGet("{id:int}")]
    [AllowAnonymous]
    public IActionResult GetById([FromRoute] int id)
    {
        var active =  _serviceApplication.GetActivesById(id);
        if (active is null) return NotFound();
        return Ok(active);
    }
}