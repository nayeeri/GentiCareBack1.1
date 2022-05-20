using System;
using System.Collections.Generic;
using System.Text;

namespace GentilCareBack.Dto
{

    public class ResponseServiciosDto { 
        public List<ServiciosDto> lista { get; set; }
        public bool status { get; set; }
    }

    public class ResponseServiciosOne {
        public ServiciosDto servicio { get; set; }
        public bool status { get; set; }
    }

    public class RequestAddServicios { 
        public ServiciosDto data { get; set; }
    }
    public class ServiciosDto
    {
        public long ServiciosId { get; set; }

        public string nombre { get; set; }
        public string costo { get; set; }
        public string? descripcion { get; set; }

        public long FarmacosId { get; set; }
        public FarmacosDto Farmacos { get; set; }

        public long SignosvitalesId { get; set; }
        public SignosvitalesDto Signosvitales { get; set; }
    }
}
