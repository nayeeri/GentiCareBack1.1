using System;
using System.Collections.Generic;
using System.Text;

namespace GentilCareBack.Dto
{

	public class ResponseEspecialidadsList
	{
		public List<EspecialidadsDto> lista { get; set; }
		public bool status { get; set; }
	}

	public class RequestEspecialidadsDto
	{
		public EspecialidadsDto data { get; set; }
	}

	public class ResponseEspecialidadsOne
	{
		public EspecialidadsDto especialidad { get; set; }
		public bool status { get; set; }
	}

	
	public class EspecialidadsDto
    {
		public long _id { get; set; }

		public long EspecialidadsId { get; set; }

        public string especialidad { get; set; }
        public decimal costo { get; set; }
        public DateTime? created_at { get; set; }
    }
}
