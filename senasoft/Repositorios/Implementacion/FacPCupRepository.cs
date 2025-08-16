using senasoft.Models;
using senasoft.Repositorios.Interfaces;

namespace senasoft.Repositorios.Implementacion
{
    public class FacPCupRepository : RepositorioGenerico<FacPCup>, IFacPCupRepository
    {
        public FacPCupRepository(SenasoftDbcontext context) : base(context){}


    }
}
