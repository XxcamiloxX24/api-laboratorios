using senasoft.Models;
using senasoft.Repositorios.Interfaces;

namespace senasoft.Repositorios.Implementacion
{
    public class LabPPruebasOpcionesRepository : RepositorioGenerico<LabPPruebasOpcione>, ILabPPruebasOpcionesRepository
    {
        public LabPPruebasOpcionesRepository(SenasoftDbcontext context) : base(context)
        {
        }
    }
}
