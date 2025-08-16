using senasoft.Models;
using senasoft.Repositorios.Interfaces;

namespace senasoft.Repositorios.Implementacion
{
    public class FacPProfesionalRepository : RepositorioGenerico<FacPProfesional>, IFacPProfesionalRepository
    {
        public FacPProfesionalRepository(SenasoftDbcontext context) : base(context)
        {
        }
    }
}
