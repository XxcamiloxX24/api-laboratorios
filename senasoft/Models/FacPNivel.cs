using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace senasoft.Models;

public partial class FacPNivel
{
    public int Id { get; set; }
    [JsonIgnore]
    public int? IdEps { get; set; }
    public virtual GenPEp? IdEpsNavigation { get; set; }

    public string? Nivel { get; set; }

    public string? Nombre { get; set; }
    [JsonIgnore]
    public int? IdRegimen { get; set; }
    public virtual GePListaopcion? IdRegimenNavigation { get; set; }
    [JsonIgnore]
    public virtual ICollection<FacMTarjetero> FacMTarjeteros { get; set; } = new List<FacMTarjetero>();


}
