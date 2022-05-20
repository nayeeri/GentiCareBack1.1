using System;
using System.Collections.Generic;
using System.Text;

namespace GentilCareBack.Models.Entity
{
    public class Semana
    {
        public long SemanaId { get; set; }
        public Colaboradors Colaboradors { get; set; }
        public List<Horas> Horas { get; set; }
    }
}
