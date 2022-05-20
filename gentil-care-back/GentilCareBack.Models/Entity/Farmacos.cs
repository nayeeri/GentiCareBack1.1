using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GentilCareBack.Models.Entity
{
    public class Farmacos
    {
		public long FarmacosId { get; set; }
		public ICollection<Servicios>? Servicios { get; set; }
		public string? farmaco { get; set; }
		public string? aplicacion { get; set; }
		public string? frecuencia { get; set; }

		[MaxLength(10)]
		public string? duracion { get; set; }

		public string? modoAplicacion { get; set; }
    }
}
