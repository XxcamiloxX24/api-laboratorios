using senasoft.Models;
using senasoft.Repositorios.Interfaces;

namespace senasoft.Repositorios.Implementacion
{
    public class GePListaopcionRepository : RepositorioGenerico<GePListaopcion>, IGePListaopcionRepository
    {
        public GePListaopcionRepository(SenasoftDbcontext context) : base(context)
        {
        }
    }
}
