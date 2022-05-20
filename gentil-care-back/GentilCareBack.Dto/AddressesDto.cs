using System;
using System.Collections.Generic;
using System.Text;

namespace GentilCareBack.Dto
{

	public class ResponseListAddress { 
		public List<AddressesDto> lista { get; set; }
		public bool status { get; set; }
	}

    public class AddressesDto
    {
		public long AddressesId { get; set; }

		public long _id { get; set; }
		public UsersDto Users { get; set; }
		public string? calle { get; set; }
		public string? exterior { get; set; }
		public string? interior { get; set; }
		public string? colonia { get; set; }
		public string municipio { get; set; }
		public string? ciudad { get; set; }
		public string? estado { get; set; }
		public string? cp { get; set; }
	}
}
