using senasoft.Models;
using senasoft.Repositorios.Interfaces;

namespace senasoft.Data
{
    public interface IUnidadDeTrabajo : IDisposable
    {
        IFacMTarjeteroRepository FacMTarjetero { get; }
        IFacPCupRepository FacPCup { get; }
        IFacPNivelRepository FacPNivel { get; }
        IFacPProfesionalRepository FacPProfesional { get; }
        IGenMPersonaRepository GenMPersona { get; }
        IGenPDocumentoRepository GenPDocumento { get; }
        IGenPEpRepository GenPEp { get; }
        IGePListaopcionRepository GePListaopcion { get; }
        ILabMOrdenRepository LabMOrden { get; }
        ILabMOrdenResultadoRepository LabMOrdenResultado { get; }
        ILabPGrupoRepository LabPGrupo { get; }
        ILabPProcedimientoRepository LabPProcedimiento { get; }
        ILabPPruebaRepository LabPPrueba { get; }
        ILabPPruebasOpcionesRepository LabPPruebasOpcione { get; }

        SenasoftDbcontext ObtenerContexto();

        Task<int> SaveChangesAsync();
    }
}
