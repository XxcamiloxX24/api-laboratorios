using Microsoft.EntityFrameworkCore;
using senasoft.Models;
using System.Linq.Expressions;

namespace senasoft.Repositorios.Interfaces
{
    public interface IFacPNivelRepository : InterfaceGeneric<FacPNivel>
    {
        public Task<IEnumerable<FacPNivel>> ObtenerConTodosInclude(params Expression<Func<FacPNivel, object>>[] includes);

        public Task<IEnumerable<FacPNivel>> ObtenerConIncludeAndCondition(
            Expression<Func<FacPNivel, bool>> condicion,
            params Expression<Func<FacPNivel, object>>[] includes
        );
    }
}
