using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace senasoft.Models;

public partial class GenMPersona
{
    public int Id { get; set; }
    [JsonIgnore]
    public int? IdTipoid { get; set; }
    public virtual GePListaopcion? IdTipo { get; set; }

    public string? Numeroid { get; set; }

    public string? Apellido1 { get; set; }

    public string? Apellido2 { get; set; }

    public string? Nombre1 { get; set; }

    public string? Nombre2 { get; set; }

    public DateOnly? Fechanac { get; set; }
    [JsonIgnore]
    public int? IdSexobiologico { get; set; }
    public virtual GePListaopcion? IdSexobiologicoNavigation { get; set; }

    public string? Direccion { get; set; }

    public string? TelMovil { get; set; }

    public string? Email { get; set; }
    [JsonIgnore]
    public virtual ICollection<FacMTarjetero> FacMTarjeteros { get; set; } = new List<FacMTarjetero>();
    [JsonIgnore]
    public virtual ICollection<FacPProfesional> FacPProfesionals { get; set; } = new List<FacPProfesional>();


}
