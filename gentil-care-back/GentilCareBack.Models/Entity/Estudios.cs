using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GentilCareBack.Models.Entity
{
    public class Estudios
    {
		public long EstudiosId { get; set; }
		public string identificador { get; set; }
		public string? estudio { get; set; }
		public string? descripcion { get; set; }
		public bool status { get; set; }

		[MaxLength(250)]
		public string nombre { get; set; }

		public DateTime? created_at { get; set; }
    }
}
