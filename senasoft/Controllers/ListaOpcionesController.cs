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
        
        var datos = await _uow.GePListaopcion.ObtenerPorCondicion(
            opc => opc.Habilita == true && opc.Variable.ToLower() == categoria.ToLower()
            );
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
    public async Task<IActionResult> Editar(int id, [FromBody] GePListaopcionDTO actualizada)
    {
        if (actualizada == null)
        {
            return BadRequest("El cuerpo no puede ser nulo");
        }
        var epsEncontrada = await _uow.GePListaopcion.ObtenerPorID(id);
        if (epsEncontrada == null || epsEncontrada.Habilita == false)
        {
            return BadRequest("No se encontró este id");
        }
        epsEncontrada.Variable = actualizada.Variable;
        epsEncontrada.Descripcion = actualizada.Descripcion;
        epsEncontrada.Valor = actualizada.Valor;
        epsEncontrada.Nombre = actualizada.Nombre;
        epsEncontrada.Abreviacion = actualizada.Abreviacion;
        _uow.GePListaopcion.Actualizar(epsEncontrada);
        await _uow.SaveChangesAsync();

        return Ok(epsEncontrada);

    }

    [HttpPut("eliminar/{id}")]
    public async Task<IActionResult> Eliminar(int id)
    {
        var opcionEncontrada = await _uow.GePListaopcion.ObtenerPorID(id);
        if (opcionEncontrada == null || opcionEncontrada.Habilita == false)
        {
            return BadRequest("No se encontró este id");
        }
        opcionEncontrada.Habilita = false;
        _uow.GePListaopcion.Actualizar(opcionEncontrada);
        await _uow.SaveChangesAsync();

        return Ok("Se ha eliminado correctamente");

    }
}
