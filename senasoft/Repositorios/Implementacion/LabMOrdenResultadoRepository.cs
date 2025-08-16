using senasoft.Models;
using senasoft.Repositorios.Interfaces;

namespace senasoft.Repositorios.Implementacion
{
    public class LabMOrdenResultadoRepository : RepositorioGenerico<LabMOrdenResultado>, ILabMOrdenResultadoRepository
    {
        public LabMOrdenResultadoRepository(SenasoftDbcontext context) : base(context) { }
    }
}
