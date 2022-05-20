using System;
using System.Collections.Generic;
using System.Text;

namespace GentilCareBack.Models.Entity
{
    public class SistemaEndocrino
    {
        public long SistemaEndocrinoId { get; set; }

        public string name { get; set; }
	    public bool valor { get; set; }
        public long InterrogatoriosId { get; set; }
        public Interrogatorios Interrogatorios { get; set; }
    }
}
