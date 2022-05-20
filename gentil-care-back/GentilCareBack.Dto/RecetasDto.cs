using System;
using System.Collections.Generic;
using System.Text;

namespace GentilCareBack.Dto
{
    public class RecetasDto
    {
		public long RecetasId { get; set; }
		public List<ServiciosDto> Servicios { get; set; }
		public DateTime proxima_cita { get; set; }
		public string indicaciones { get; set; }
		public long estudio_banco { get; set; }
		public string observacion { get; set; }
		public List<EstudiosDto> Estudios { get; set; }
		public string codigo { get; set; }
	}
}
