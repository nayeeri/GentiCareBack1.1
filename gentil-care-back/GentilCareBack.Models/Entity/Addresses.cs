using System;
using System.Collections.Generic;
using System.Text;

namespace GentilCareBack.Models.Entity
{
	public class Addresses
	{
		public long AddressesId { get; set; }
		public Users Users { get; set; }
		public string? calle { get; set; }
		public string? exterior { get; set; }
		public string? interior { get; set; }
		public string? colonia { get; set; }
		public string municipio { get; set; }
		public string? ciudad {get; set;}
		public string? estado { get; set; }
		public string? cp { get; set; }
    }
}
