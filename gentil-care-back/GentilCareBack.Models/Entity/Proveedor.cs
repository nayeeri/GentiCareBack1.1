using System;
using System.Collections.Generic;
using System.Text;

namespace GentilCareBack.Models.Entity
{
    public class Proveedor
    {
        public long ProveedorId { get; set; }
        public string? provedor { get; set; }
        public string? email { get; set; }
        public decimal? costo { get; set; }
        public string? cellphone { get; set; }
        public string? estudio { get; set; }
        public Addresses? Addresses { get; set; }
    }
}
