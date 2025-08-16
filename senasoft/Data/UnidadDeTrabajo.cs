using senasoft.Models;
using senasoft.Repositorios.Interfaces;

namespace senasoft.Data
{
    public class UnidadDeTrabajo : IUnidadDeTrabajo, IDisposable
    {
        private readonly SenasoftDbcontext _dbcontext;

        public IFacMTarjeteroRepository FacMTarjetero { get; }
        public IFacPCupRepository FacPCup { get; }
        public IFacPNivelRepository FacPNivel { get; }
        public IFacPProfesionalRepository FacPProfesional { get; }
        public IGenMPersonaRepository GenMPersona { get; }
        public IGenPDocumentoRepository GenPDocumento { get; }
        public IGenPEpRepository GenPEp { get; }
        public IGePListaopcionRepository GePListaopcion { get; }
        public ILabMOrdenRepository LabMOrden { get; }
        public ILabMOrdenResultadoRepository LabMOrdenResultado { get; }
        public ILabPGrupoRepository LabPGrupo { get; }
        public ILabPProcedimientoRepository LabPProcedimiento { get; }
        public ILabPPruebaRepository LabPPrueba { get; }
        public ILabPPruebasOpcionesRepository LabPPruebasOpcione { get; }

        public UnidadDeTrabajo(SenasoftDbcontext dbcontext,
                               IFacMTarjeteroRepository facMTarjetero,
                               IFacPCupRepository facPCup,
                               IFacPNivelRepository facPNivel,
                               IFacPProfesionalRepository facPProfesional,
                               IGenMPersonaRepository genMPersona,
                               IGenPDocumentoRepository genPDocumento,
                               IGenPEpRepository genPEp,
                               IGePListaopcionRepository gePListaopcion,
                               ILabMOrdenRepository labMOrden,
                               ILabMOrdenResultadoRepository labMOrdenResultado,
                               ILabPGrupoRepository labPGrupo,
                               ILabPProcedimientoRepository labPProcedimiento,
                               ILabPPruebaRepository labPPrueba,
                               ILabPPruebasOpcionesRepository labPPruebasOpcione)
        {
            _dbcontext = dbcontext;

            FacMTarjetero = facMTarjetero;
            FacPCup = facPCup;
            FacPNivel = facPNivel;
            FacPProfesional = facPProfesional;
            GenMPersona = genMPersona;
            GenPDocumento = genPDocumento;
            GenPEp = genPEp;
            GePListaopcion = gePListaopcion;
            LabMOrden = labMOrden;
            LabMOrdenResultado = labMOrdenResultado;
            LabPGrupo = labPGrupo;
            LabPProcedimiento = labPProcedimiento;
            LabPPrueba = labPPrueba;
            LabPPruebasOpcione = labPPruebasOpcione;
        }

        public void Dispose() => _dbcontext.Dispose();

        public SenasoftDbcontext ObtenerContexto() => _dbcontext;

        public async Task<int> SaveChangesAsync() => await _dbcontext.SaveChangesAsync();
    }
}
