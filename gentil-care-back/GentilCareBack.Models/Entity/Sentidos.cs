using System;
using System.Collections.Generic;
using System.Text;

namespace GentilCareBack.Models.Entity
{
    public class Sentidos
    {
        public long SentidosId { get; set; }

        public string name { get; set; }
	    public bool valor { get; set; }
        public long InterrogatoriosId { get; set; }
        public Interrogatorios Interrogatorios { get; set; }
    }
}
