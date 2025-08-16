using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace senasoft.Models;

public partial class LabPProcedimiento
{
    public int Id { get; set; }
    [JsonIgnore]
    public int? IdCups { get; set; }
    public virtual FacPCup? IdCupsNavigation { get; set; }
    [JsonIgnore]
    public int? IdGrupoLaboratorio { get; set; }
    public virtual LabPGrupo? IdGrupoLaboratorioNavigation { get; set; }

    public string? Metodo { get; set; }


    [JsonIgnore]

    public virtual ICollection<LabMOrdenResultado> LabMOrdenResultados { get; set; } = new List<LabMOrdenResultado>();
    [JsonIgnore]

    public virtual ICollection<LabPPrueba> LabPPruebas { get; set; } = new List<LabPPrueba>();
}
