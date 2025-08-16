using Microsoft.AspNetCore.Mvc;
using senasoft.Data;

[ApiController]
[Route("api/[controller]")]
public class TarjeteroController : ControllerBase
{
    private readonly IUnidadDeTrabajo _uow;

    public TarjeteroController(IUnidadDeTrabajo uow)
    {
        _uow = uow;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var datos = await _uow.FacMTarjetero.ObtenerTodos();
        return Ok(datos);
    }
}
