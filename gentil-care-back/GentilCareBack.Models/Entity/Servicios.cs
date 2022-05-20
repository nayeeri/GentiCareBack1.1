using System;
using System.Collections.Generic;
using System.Text;

namespace GentilCareBack.Models.Entity
{
    public class Servicios
    {
        public long ServiciosId { get; set; }

        public string nombre { get; set; }
	    public decimal costo { get; set; }
	    public string? descripcion { get; set; }

        public long? FarmacosId { get; set; }
        public Farmacos? Farmacos { get; set; }

        public long? SignosvitalesId { get; set; }
        public Signosvitales? Signosvitales { get; set; }

        public Planes? Planes { get; set; }
    }
}
