using System;
using System.Collections.Generic;
using System.Text;

namespace GentilCareBack.Dto
{
    public class SemanaDto
    {
        public long SemanaId { get; set; }
        public ColaboradorsDto Colaboradors { get; set; }
        public List<HorasDto> Horas { get; set; }
    }
}
