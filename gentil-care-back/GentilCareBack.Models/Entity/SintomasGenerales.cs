using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GentilCareBack.Models.Entity
{
    public class SintomasGenerales
    {
        public long SintomasGeneralesId { get; set; }

        [MaxLength(250)]
        public string name { get; set; }
	    public bool valor { get; set; }
        public long InterrogatoriosId { get; set; }
        public Interrogatorios Interrogatorios { get; set; }
    }
}
