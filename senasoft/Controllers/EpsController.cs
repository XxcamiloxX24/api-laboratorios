using Microsoft.AspNetCore.Mvc;
using senasoft.Data;

[ApiController]
[Route("api/[controller]")]
public class EpsController : ControllerBase
{
    private readonly IUnidadDeTrabajo _uow;

    public EpsController(IUnidadDeTrabajo uow)
    {
        _uow = uow;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var datos = await _uow.GenPEp.ObtenerPorCondicion(eps => eps.Habilita == true);
        return Ok(datos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        
        var datos = await _uow.GenPEp.ObtenerPorID(id);

        if (datos.Habilita == false || datos == null)
        {
            return BadRequest("No se encontro este id o fue eliminado");
        }
        return Ok(datos);
    }


    [HttpPut("eliminar/{id}")]
    public async Task<IActionResult> Eliminar(int id)
    {
        if (id == null)
        {
            return BadRequest("El cuerpo no puede ser nulo");
        }
        var epsEncontrada = await _uow.GenPEp.ObtenerPorID(id);
        if (epsEncontrada == null || epsEncontrada.Habilita == false)
        {
            return BadRequest("No se encontró este id");
        }
        epsEncontrada.Habilita = false;
        _uow.GenPEp.Actualizar(epsEncontrada);
        await _uow.SaveChangesAsync();

        return Ok("Se ha eliminado correctamente");

    }
}
