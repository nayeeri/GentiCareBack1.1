using System;
using System.Collections.Generic;
using System.Text;

namespace GentilCareBack.Models.Entity
{
    public class Recetas
    {
		public long RecetasId { get; set; }
		public List<Servicios> Servicios { get; set; }
		public DateTime proxima_cita { get; set; }
		public string indicaciones { get; set; }
		public long estudio_banco { get; set; }
		public string observacion { get; set; }
		public List<Estudios> Estudios { get; set; }
		public string codigo { get; set; }
    }
}
