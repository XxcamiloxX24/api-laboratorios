using senasoft.Models;
using senasoft.Repositorios.Interfaces;

namespace senasoft.Repositorios.Implementacion
{
    public class FacPNivelRepository : RepositorioGenerico<FacPNivel>, IFacPNivelRepository
    {
        public FacPNivelRepository(SenasoftDbcontext context) : base(context){}
    }
}
