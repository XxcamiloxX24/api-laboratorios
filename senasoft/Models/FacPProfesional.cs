using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace senasoft.Models;

public partial class FacPProfesional
{
    public int Id { get; set; }

    public string? Codigo { get; set; }
    
    [JsonIgnore]
    public int? IdPersona { get; set; }
    public virtual GenMPersona? IdPersonaNavigation { get; set; }

    public string? RegistroMedico { get; set; }

    [JsonIgnore]
    public int? IdTipoProf { get; set; }
    public virtual GePListaopcion? IdTipoProfNavigation { get; set; }

    [JsonIgnore]
    public virtual ICollection<LabMOrden> LabMOrdens { get; set; } = new List<LabMOrden>();
}
