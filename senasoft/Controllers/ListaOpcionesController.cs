using Microsoft.AspNetCore.Mvc;
using senasoft.Data;
using senasoft.Models;
using senasoft.Models.DTO;

[ApiController]
[Route("api/[controller]")]
public class ListaOpcionesController : ControllerBase
{
    private readonly IUnidadDeTrabajo _uow;

    public ListaOpcionesController(IUnidadDeTrabajo uow)
    {
        _uow = uow;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var datos = await _uow.GePListaopcion.ObtenerPorCondicion(opc => opc.Habilita == true);
        return Ok(datos);
    }

    [HttpGet("{categoria}")]
    public async Task<IActionResult> GetById(string categoria)
    {
        
        var datos = await _uow.GePListaopcion.ObtenerPorCondicion(opc => opc.Habilita == true && opc.Variable == categoria);
        if (!datos.Any())
        {
            return BadRequest("No se encontraron registros con esta categoria");
        }
        return Ok(datos);
    }

    [HttpPost("crear")]
    public async Task<IActionResult> crear([FromBody] GePListaopcionDTO nuevo)
    {
        if (nuevo == null)
        {
            return BadRequest("El cuerpo no puede ser nulo");
        }
        var nuevoRegistro = new GePListaopcion
        {
            Variable = nuevo.Variable,
            Descripcion = nuevo.Descripcion,
            Valor = nuevo.Valor,
            Nombre = nuevo.Nombre,
            Abreviacion = nuevo.Abreviacion
        };
        await _uow.GePListaopcion.Agregar(nuevoRegistro);
        await _uow.SaveChangesAsync();
        return Ok(nuevoRegistro);
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
