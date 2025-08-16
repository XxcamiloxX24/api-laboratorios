using senasoft.Models;
using System.Linq.Expressions;

namespace senasoft.Repositorios.Interfaces
{
    public interface IGenPEpRepository : InterfaceGeneric<GenPEp>
    {
        Task<IEnumerable<GenPEp>> ObtenerPorCondicion(Expression<Func<GenPEp, bool>> condicion);
        Task<GenPEp> ObtenerPorCodigo(string codigo);
    }
}
