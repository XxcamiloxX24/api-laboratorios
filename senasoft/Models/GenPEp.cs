using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace senasoft.Models;

public partial class GenPEp
{
    public int Id { get; set; }

    public string? Codigo { get; set; }

    public string? Razonsocial { get; set; }

    public string? Nit { get; set; }
    [JsonIgnore]
    public bool? Habilita { get; set; }

    [JsonIgnore]
    public virtual ICollection<FacMTarjetero> FacMTarjeteros { get; set; } = new List<FacMTarjetero>();

    [JsonIgnore]
    public virtual ICollection<FacPNivel> FacPNivels { get; set; } = new List<FacPNivel>();
}
