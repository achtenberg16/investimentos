using Application.Dto;
using Application.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("/v1/ativos")]
public class ActivesController : ControllerBase
{
    private readonly IActivesService _service;

    public ActivesController(IActivesService service)
    {
        _service = service;
    }
    
    [HttpGet]
    public IActionResult GetActives()
    {
        var actives =  _service.GetActives();
        return Ok(actives);
    }
}