using Microsoft.AspNetCore.Mvc;
using senasoft.Data;
using senasoft.Models.DTO;

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

    [HttpGet("{codigo}")]
    public async Task<IActionResult> GetById(string codigo)
    {
        
        var datos = await _uow.GenPEp.ObtenerPorCodigo(codigo);

        if (datos.Habilita == false || datos == null)
        {
            return BadRequest("No se encontro este codigo o fue eliminado");
        }
        return Ok(datos);
    }

    [HttpPut("editar/{id}")]
    public async Task<IActionResult> Editar(int id, [FromBody] GenPEpDTO actualizada)
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
        epsEncontrada.Codigo = actualizada.Codigo;
        epsEncontrada.Razonsocial = actualizada.Razonsocial;
        epsEncontrada.Nit = actualizada.Nit;
        _uow.GenPEp.Actualizar(epsEncontrada);
        await _uow.SaveChangesAsync();

        return Ok("Se ha eliminado correctamente");

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
