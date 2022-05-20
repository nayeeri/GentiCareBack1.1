using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GentilCareBack.Models.Entity
{
    public class Planes
    {
        public long PlanesId { get; set; }
        public decimal costo { get; set; }

        [MaxLength(2000)]
        public string descripcion { get; set; }

        [MaxLength(2000)]
        public string nombre { get; set; }

        public List<Servicios>? Servicios { get; set; }
    }
}
