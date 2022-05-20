using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GentilCareBack.Dto
{
    public class ResponsePlanesListDto
    {
        public List<PlanesDto> planes { get; set; }
        public bool status { get; set; }
    }

    public class ResponsePlanesOne
    {
        public PlanesDto plan { get; set; }
        public bool status { get; set; }
    }

    public class RequestAddPlanesDto
    {
        public PlanesDto data { get; set; }
    }

    public class PlanesDto
    {
        public long _id { get; set; }
        public long PlanesId { get; set; }
        public decimal costo { get; set; }

        [MaxLength(2000)]
        public string descripcion { get; set; }

        [MaxLength(2000)]
        public string nombre { get; set; }

        public List<ServiciosDto>? Servicios { get; set; }
    }
}
