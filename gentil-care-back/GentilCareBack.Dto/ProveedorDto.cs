using System;
using System.Collections.Generic;
using System.Text;

namespace GentilCareBack.Dto
{

    public class ResponseProveedorListDto
    {
        public List<ProveedorDto> lista { get; set; }
        public bool status { get; set; }
    }

    public class ResponseProveedorOne
    {
        public ProveedorDto provedor { get; set; }
        public bool status { get; set; }
    }

    public class RequestAddProveedorDto
    {
        public ProveedorDto data { get; set; }
    }

    public class ProveedorDto
    {
        public long _id { get; set; }
        public long ProveedorId { get; set; }
        public string? provedor { get; set; }
        public string? email { get; set; }
        public decimal? costo { get; set; }
        public string? cellphone { get; set; }
        public string? estudio { get; set; }
        public AddressesDto address { get; set; }
    }
}
