using senasoft.Models;
using senasoft.Repositorios.Interfaces;

namespace senasoft.Repositorios.Implementacion
{
    public class LabPPruebaRepository : RepositorioGenerico<LabPPrueba>, ILabPPruebaRepository
    {
        public LabPPruebaRepository(SenasoftDbcontext context) : base(context) { }
    }
}
