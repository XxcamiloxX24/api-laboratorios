using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace senasoft.Models;

public partial class GePListaopcion
{
    public int Id { get; set; }

    public string? Variable { get; set; }

    public string? Descripcion { get; set; }

    public int? Valor { get; set; }

    public string? Nombre { get; set; }

    public string? Abreviacion { get; set; }

    [JsonIgnore]
    public bool? Habilita { get; set; }
    [JsonIgnore]

    public virtual ICollection<FacMTarjetero> FacMTarjeteros { get; set; } = new List<FacMTarjetero>();
    [JsonIgnore]

    public virtual ICollection<FacPNivel> FacPNivels { get; set; } = new List<FacPNivel>();
    [JsonIgnore]

    public virtual ICollection<FacPProfesional> FacPProfesionals { get; set; } = new List<FacPProfesional>();
    [JsonIgnore]

    public virtual ICollection<GenMPersona> GenMPersonaIdSexobiologicoNavigations { get; set; } = new List<GenMPersona>();
    [JsonIgnore]

    public virtual ICollection<GenMPersona> GenMPersonaIdTipos { get; set; } = new List<GenMPersona>();
    [JsonIgnore]

    public virtual ICollection<LabPPrueba> LabPPruebas { get; set; } = new List<LabPPrueba>();
}
