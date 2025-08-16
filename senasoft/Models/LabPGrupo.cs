using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace senasoft.Models;

public partial class LabPGrupo
{
    public int Id { get; set; }

    public string? Codigo { get; set; }

    public string? Nombre { get; set; }
    [JsonIgnore]
    public bool? Habilita { get; set; }
    [JsonIgnore]
    public virtual ICollection<LabPProcedimiento> LabPProcedimientos { get; set; } = new List<LabPProcedimiento>();
}
