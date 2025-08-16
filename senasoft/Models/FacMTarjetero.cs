using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace senasoft.Models;

public partial class FacMTarjetero
{
    public int Id { get; set; }

    public string? Historia { get; set; }
    [JsonIgnore]
    public int? IdPersona { get; set; }
    public virtual GenMPersona? IdPersonaNavigation { get; set; }

    [JsonIgnore]
    public int? IdRegimen { get; set; }
    public virtual GePListaopcion? IdRegimenNavigation { get; set; }

    [JsonIgnore]
    public int? IdEps { get; set; }
    public virtual GenPEp? IdEpsNavigation { get; set; }

    [JsonIgnore]
    public int? IdNivel { get; set; }
    public virtual FacPNivel? IdNivelNavigation { get; set; }

    [JsonIgnore]
    public virtual ICollection<LabMOrden> LabMOrdens { get; set; } = new List<LabMOrden>();
}
