using System;
using System.Collections.Generic;
using System.Text;

namespace GentilCareBack.Dto
{
    public class SignosvitalesDto
    {
		public long SignosvitalesId { get; set; }
		public ICollection<ServiciosDto> servicio { get; set; }
		public string? presionArterial { get; set; }
		public string? frecuenciaRespiratoria { get; set; }
		public string? frecuenciaCardiaca { get; set; }
		public string? temperatura { get; set; }
		public string? glucosa { get; set; }
		public string? saturacion { get; set; }
	}
}
