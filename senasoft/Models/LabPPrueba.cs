using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace senasoft.Models;

public partial class LabPPrueba
{
    public int Id { get; set; }
    [JsonIgnore]
    public int? IdProcedimiento { get; set; }
    public virtual LabPProcedimiento? IdProcedimientoNavigation { get; set; }

    public string? CodigoPrueba { get; set; }

    public string? NombrePrueba { get; set; }
    [JsonIgnore]
    public int? IdTipoResultado { get; set; }
    public virtual GePListaopcion? IdTipoResultadoNavigation { get; set; }

    public string? Unidad { get; set; }
    [JsonIgnore]

    public bool? Habilita { get; set; }


    [JsonIgnore]

    public virtual ICollection<LabMOrdenResultado> LabMOrdenResultados { get; set; } = new List<LabMOrdenResultado>();
    [JsonIgnore]

    public virtual ICollection<LabPPruebasOpcione> LabPPruebasOpciones { get; set; } = new List<LabPPruebasOpcione>();
}
