using senasoft.Models;
using senasoft.Repositorios.Interfaces;

namespace senasoft.Repositorios.Implementacion
{
    public class FacMTarjeteroRepository : RepositorioGenerico<FacMTarjetero>, IFacMTarjeteroRepository
    {
        public FacMTarjeteroRepository(SenasoftDbcontext context) : base(context) { }
    }


}
