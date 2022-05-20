using System;
using System.Collections.Generic;
using System.Text;

namespace GentilCareBack.Models.Entity
{
    public class Signosvitales
    {
		public long SignosvitalesId { get; set; }
		public ICollection<Servicios>? servicio { get; set; }
		public string? presionArterial { get; set; }
		public string? frecuenciaRespiratoria { get; set; }
		public string? frecuenciaCardiaca { get; set; }
		public string? temperatura { get; set; }
		public string? glucosa { get; set; }
		public string? saturacion { get; set; }
    }
}
