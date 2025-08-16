using senasoft.Models;
using senasoft.Repositorios.Interfaces;

namespace senasoft.Repositorios.Implementacion
{
    public class GenMPersonaRepository : RepositorioGenerico<GenMPersona>, IGenMPersonaRepository
    {
        public GenMPersonaRepository(SenasoftDbcontext context) : base(context)
        {
        }
    }
}
