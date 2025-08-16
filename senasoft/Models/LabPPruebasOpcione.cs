using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace senasoft.Models;

public partial class LabPPruebasOpcione
{
    public int Id { get; set; }
    [JsonIgnore]
    public int? IdPrueba { get; set; }
    public virtual LabPPrueba? IdPruebaNavigation { get; set; }

    public string? Opcion { get; set; }

    public int? ValorRefMinF { get; set; }

    public int? ValorRefMaxF { get; set; }

    public int? ValorRefMinM { get; set; }

    public int? ValorRefMaxM { get; set; }


    [JsonIgnore]
    public virtual ICollection<LabMOrdenResultado> LabMOrdenResultados { get; set; } = new List<LabMOrdenResultado>();
}
