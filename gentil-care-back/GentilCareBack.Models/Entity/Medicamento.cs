using System;
using System.Collections.Generic;
using System.Text;

namespace GentilCareBack.Models.Entity
{
    public class Medicamento
    {
        public long MedicamentoId { get; set; }
        public string? descripcion { get; set; }

        public string? farmaco { get; set; }
        public string? nombre_quimico { get; set; }
        public string? presentacion { get; set; }

        public decimal? costo { get; set; }
        public int? existencia { get; set; }

    }
}
