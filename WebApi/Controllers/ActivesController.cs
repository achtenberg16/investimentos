using Application.Dto;
using Application.interfaces;
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
    public IActionResult GetActives()
    {
        var actives =  _serviceApplication.GetActives();
        return Ok(actives);
    }
}