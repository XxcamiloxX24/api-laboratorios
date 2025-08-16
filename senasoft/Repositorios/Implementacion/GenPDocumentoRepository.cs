using senasoft.Models;
using senasoft.Repositorios.Interfaces;

namespace senasoft.Repositorios.Implementacion
{
    public class GenPDocumentoRepository : RepositorioGenerico<GenPDocumento>, IGenPDocumentoRepository
    {
        public GenPDocumentoRepository(SenasoftDbcontext context) : base(context) { }
    }
}
