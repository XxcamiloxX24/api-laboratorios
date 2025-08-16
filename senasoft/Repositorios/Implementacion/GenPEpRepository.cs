using Microsoft.EntityFrameworkCore;
using senasoft.Models;
using senasoft.Repositorios.Interfaces;
using System.Linq.Expressions;

namespace senasoft.Repositorios.Implementacion
{
    public class GenPEpRepository : RepositorioGenerico<GenPEp>, IGenPEpRepository
    {
        private readonly SenasoftDbcontext _context;
        public GenPEpRepository(SenasoftDbcontext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<GenPEp>> ObtenerPorCondicion(Expression<Func<GenPEp, bool>> condicion)
        {
            return await _context.GenPEps.Where(condicion).ToListAsync();
        }

        public async Task<GenPEp?> ObtenerPorCodigo(string codigo) => await _context.GenPEps.FirstOrDefaultAsync(e => e.Codigo == codigo);
    }
}
