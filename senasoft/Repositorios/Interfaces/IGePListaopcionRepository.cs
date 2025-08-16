using senasoft.Models;
using System.Linq.Expressions;

namespace senasoft.Repositorios.Interfaces
{
    public interface IGePListaopcionRepository : InterfaceGeneric<GePListaopcion>
    {
        Task<IEnumerable<GePListaopcion>> ObtenerPorCondicion(Expression<Func<GePListaopcion, bool>> condicion);
    }
}
