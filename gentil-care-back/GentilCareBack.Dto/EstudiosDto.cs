using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GentilCareBack.Dto
{

	public class ResponseEstudiosList {
		public List<EstudiosDto> lista { get; set; }
		public bool status { get; set; }
	}

	public class RequestEstudiosDto {
		public EstudiosDto data { get; set; }
	}

	public class ResponseEstudiosOne { 
		public EstudiosDto estudio { get; set; }
		public bool status { get; set; }
	}

	public class ResponseGeneralDto {
		public string msg { get; set; }
		public bool status { get; set; }
	}

    public class EstudiosDto
    {
		public long EstudiosId { get; set; }

		public long _id { get; set; }
		public string identificador { get; set; }
		public string? estudio { get; set; }
		public string? descripcion { get; set; }
		public bool status { get; set; }

		[MaxLength(250)]
		public string nombre { get; set; }

		public DateTime? created_at { get; set; }
	}
}
