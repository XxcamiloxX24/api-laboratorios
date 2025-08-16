using senasoft.Models;
using senasoft.Repositorios.Interfaces;

namespace senasoft.Repositorios.Implementacion
{
    public class LabMOrdenRepository : RepositorioGenerico<LabMOrden>, ILabMOrdenRepository
    {
        public LabMOrdenRepository(SenasoftDbcontext context) : base(context)
        {
        }
    }
}
