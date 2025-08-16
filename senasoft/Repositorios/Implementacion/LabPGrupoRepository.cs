using senasoft.Models;
using senasoft.Repositorios.Interfaces;

namespace senasoft.Repositorios.Implementacion
{
    public class LabPGrupoRepository : RepositorioGenerico<LabPGrupo>, ILabPGrupoRepository
    {
        public LabPGrupoRepository(SenasoftDbcontext context) : base(context)
        {
        }
    }
}
