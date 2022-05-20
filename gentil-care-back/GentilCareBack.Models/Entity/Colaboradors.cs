using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GentilCareBack.Models.Entity
{
    public class Colaboradors
    {
		public long ColaboradorsId { get; set; }
		public Users Users { get; set; }
		public decimal costoConsulta { get; set; }
		public string cedula { get; set; }
		public string address_fiscal { get; set; }

		[MaxLength(20)]
		public string rfc { get; set; }

		[MaxLength(250)]
		public string especialidad { get; set; }

		[MaxLength(250)]
		public string plataforma { get; set; }

		[MaxLength(20)]
		public string tel_fijo { get; set; }

		[MaxLength(250)]
		public string pacientes { get; set; }

		public string observacion { get; set; }
    }
}
