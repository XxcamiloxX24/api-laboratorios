using senasoft.Models;
using senasoft.Repositorios.Interfaces;

namespace senasoft.Repositorios.Implementacion
{
    public class LabPProcedimientoRepository : RepositorioGenerico<LabPProcedimiento>, ILabPProcedimientoRepository
    {
        public LabPProcedimientoRepository(SenasoftDbcontext context) : base(context)
        {
        }
    }
}
