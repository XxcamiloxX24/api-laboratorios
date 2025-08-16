using Microsoft.EntityFrameworkCore;
using senasoft.Models;
using senasoft.Repositorios.Interfaces;

namespace senasoft.Repositorios.Implementacion
{
    public class RepositorioGenerico<T> : InterfaceGeneric<T> where T : class
    {
        protected readonly SenasoftDbcontext _senasofDbContext;
        protected readonly DbSet<T> _dbset;

        public RepositorioGenerico(SenasoftDbcontext context)
        {
            _senasofDbContext = context;
            _dbset = context.Set<T>();
        }

        public async Task<IEnumerable<T>> ObtenerTodos() => await _dbset.ToListAsync();
        public async Task<T> ObtenerPorID(int id) => await _dbset.FindAsync(id);
        public async Task Agregar(T entity) => await _dbset.AddAsync(entity);
        public async void Actualizar(T entity) => _dbset.Update(entity);
        public async void Eliminar(T id) => _dbset.Remove(id);


    }
}
