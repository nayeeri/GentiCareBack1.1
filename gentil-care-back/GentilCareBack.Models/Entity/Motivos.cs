using System;
using System.Collections.Generic;
using System.Text;

namespace GentilCareBack.Models.Entity
{
    public class Motivos
    {
        public long MotivosId { get; set; }

        public long idServicio { get; set; }
	    public string? motivo { get; set; }
	    public string? tipo { get; set; }
    }
}
