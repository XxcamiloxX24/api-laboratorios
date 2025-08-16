using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace senasoft.Models;

public partial class LabMOrden
{
    public int Id { get; set; }

    public int? IdDocumento { get; set; }
    public virtual GenPDocumento? IdDocumentoNavigation { get; set; }

    public int? Orden { get; set; }

    public DateOnly? Fecha { get; set; }

    [JsonIgnore]
    public int? IdHistoria { get; set; }
    public virtual FacMTarjetero? IdHistoriaNavigation { get; set; }
    [JsonIgnore]
    public int? IdProfesionalOrdena { get; set; }
    public virtual FacPProfesional? IdProfesionalOrdenaNavigation { get; set; }
    public bool? ProfesionalEcterno { get; set; }
    [JsonIgnore]
    public virtual ICollection<LabMOrdenResultado> LabMOrdenResultados { get; set; } = new List<LabMOrdenResultado>();
}
