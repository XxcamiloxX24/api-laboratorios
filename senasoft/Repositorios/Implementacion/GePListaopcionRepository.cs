using Microsoft.EntityFrameworkCore;
using senasoft.Models;
using senasoft.Repositorios.Interfaces;
using System.Linq.Expressions;

namespace senasoft.Repositorios.Implementacion
{
    public class GePListaopcionRepository : RepositorioGenerico<GePListaopcion>, IGePListaopcionRepository
    {
        private readonly SenasoftDbcontext _context;
        public GePListaopcionRepository(SenasoftDbcontext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GePListaopcion>> ObtenerPorCondicion(Expression<Func<GePListaopcion, bool>> condicion)
        {
            return await _context.GePListaopcion.Where(condicion).ToListAsync();
        }
    }
}
