using System;
using System.Collections.Generic;
using System.Text;

namespace GentilCareBack.Dto
{

    public class ResponseMedicamentoListDto
    {
        public List<MedicamentoDto> lista { get; set; }
        public bool status { get; set; }
    }

    public class ResponseMedicamentoOne
    {
        public MedicamentoDto medicamento { get; set; }
        public bool status { get; set; }
    }

    public class RequestAddMedicamentoDto
    {
        public MedicamentoDto data { get; set; }
    }
    public class MedicamentoDto
    {
        public long _id { get; set; }
        public long MedicamentoId { get; set; }
        public string? descripcion { get; set; }

        public string? farmaco { get; set; }
        public string? nombre_quimico { get; set; }
        public string? presentacion { get; set; }
        public decimal? costo { get; set; }
        public int? existencia { get; set; }
    }
}
