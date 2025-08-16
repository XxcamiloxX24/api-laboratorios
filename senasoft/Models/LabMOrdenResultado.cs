using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace senasoft.Models;

public partial class LabMOrdenResultado
{
    public int Id { get; set; }

    public DateOnly? Fecha { get; set; }
    [JsonIgnore]
    public int? IdOrden { get; set; }
    public virtual LabMOrden? IdOrdenNavigation { get; set; }
    [JsonIgnore]
    public int? IdProcedimiento { get; set; }
    public virtual LabPProcedimiento? IdProcedimientoNavigation { get; set; }
    [JsonIgnore]
    public int? IdPrueba { get; set; }
    public virtual LabPPrueba? IdPruebaNavigation { get; set; }
    [JsonIgnore]
    public int? IdPruebaopcion { get; set; }
    public virtual LabPPruebasOpcione? IdPruebaopcionNavigation { get; set; }

    public string? ResOpcion { get; set; }

    public int? ResNumerico { get; set; }

    public string? ResTexto { get; set; }

    public string? ResMemo { get; set; }

    public int? NumProcesamientos { get; set; }




}
