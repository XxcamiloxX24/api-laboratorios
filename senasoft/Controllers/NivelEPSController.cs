using Microsoft.AspNetCore.Mvc;
using senasoft.Data;
using senasoft.Models;
using senasoft.Models.DTO;

[ApiController]
[Route("api/[controller]")]
public class NivelEPSController : ControllerBase
{
    private readonly IUnidadDeTrabajo _uow;

    public NivelEPSController(IUnidadDeTrabajo uow)
    {
        _uow = uow;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var datos = await _uow.FacPNivel.ObtenerConTodosInclude(opc => opc.IdEpsNavigation, opc => opc.IdRegimenNavigation);
        return Ok(datos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        
        var datos = await _uow.FacPNivel.ObtenerConIncludeAndCondition(opc => opc.Id == id,opc => opc.IdEpsNavigation, opc => opc.IdRegimenNavigation);
        if (!datos.Any())
        {
            return BadRequest("No se encontro este registro");
        }
        return Ok(datos);
    }

    [HttpPost("crear")]
    public async Task<IActionResult> crear([FromBody] FacPNivelDTO nuevo)
    {
        if (nuevo == null)
        {
            return BadRequest("El cuerpo no puede ser nulo");
        }
        var nuevoRegistro = new FacPNivel
        {
            IdEps = nuevo.IdEps,
            Nivel = nuevo.Nivel,
            Nombre = nuevo.Nombre,
            IdRegimen = nuevo.IdRegimen
        };
        await _uow.FacPNivel.Agregar(nuevoRegistro);
        await _uow.SaveChangesAsync();

        var datos = await _uow.FacPNivel.ObtenerConIncludeAndCondition(
            opc => opc.Id == nuevoRegistro.Id, opc => opc.IdEpsNavigation, 
            opc => opc.IdRegimenNavigation);
        if (!datos.Any())
        {
            return BadRequest("No se encontro el id");
        }
        return Ok(datos);
    }

    [HttpPut("editar/{id}")]
    public async Task<IActionResult> Editar(int id, [FromBody] FacPNivelDTO actualizada)
    {
        if (actualizada == null)
        {
            return BadRequest("El cuerpo no puede ser nulo");
        }
        var nvlEncontrada = await _uow.FacPNivel.ObtenerPorID(id);
        if (nvlEncontrada == null )
        {
            return BadRequest("No se encontró este id");
        }
        nvlEncontrada.IdEps = actualizada.IdEps;
        nvlEncontrada.Nivel = actualizada.Nivel;
        nvlEncontrada.Nombre = actualizada.Nombre;
        nvlEncontrada.IdRegimen = actualizada.IdRegimen;
        _uow.FacPNivel.Actualizar(nvlEncontrada);
        await _uow.SaveChangesAsync();

        return Ok(nvlEncontrada);

    }

    [HttpDelete("eliminar/{id}")]
    public async Task<IActionResult> Eliminar(int id)
    {
        var opcionEncontrada = await _uow.FacPNivel.ObtenerPorID(id);
        if (opcionEncontrada == null)
        {
            return BadRequest("No se encontró este id");
        }
        _uow.FacPNivel.Eliminar(opcionEncontrada);
        await _uow.SaveChangesAsync();

        return Ok("Se ha eliminado correctamente");

    }
}
