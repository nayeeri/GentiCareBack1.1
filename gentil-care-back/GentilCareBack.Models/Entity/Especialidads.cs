using System;
using System.Collections.Generic;
using System.Text;

namespace GentilCareBack.Models.Entity
{
    public class Especialidads
    {
        public long EspecialidadsId { get; set; }

        public string especialidad { get; set; }
	    public decimal costo { get; set; }
	    public DateTime? created_at { get; set; }
    }
}
