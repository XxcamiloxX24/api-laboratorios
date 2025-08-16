using Microsoft.EntityFrameworkCore;
using senasoft.Models;
using senasoft.Repositorios.Interfaces;
using System.Linq;
using System.Linq.Expressions;

namespace senasoft.Repositorios.Implementacion
{
    public class FacPNivelRepository : RepositorioGenerico<FacPNivel>, IFacPNivelRepository
    {
        private readonly SenasoftDbcontext _context;
        private readonly DbSet<FacPNivel> _dbSet;
        public FacPNivelRepository(SenasoftDbcontext context) : base(context){
            _context = context;
            _dbSet = context.Set<FacPNivel>();
        }

        public async Task<IEnumerable<FacPNivel>> ObtenerConTodosInclude(params Expression<Func<FacPNivel, object>>[] includes)
        {
            IQueryable<FacPNivel> query = _dbSet;
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<FacPNivel>> ObtenerConIncludeAndCondition(Expression<Func<FacPNivel, bool>> condicion,params Expression<Func<FacPNivel, object>>[] includes)
        {
            IQueryable<FacPNivel> query = _dbSet.Where(condicion);
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return await query.ToListAsync();
        }
    }
}
