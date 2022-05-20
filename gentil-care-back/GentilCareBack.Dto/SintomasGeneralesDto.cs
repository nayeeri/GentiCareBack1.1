using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GentilCareBack.Dto
{
    public class SintomasGeneralesDto
    {
        public long SintomasGeneralesId { get; set; }

        [MaxLength(250)]
        public string name { get; set; }
        public bool valor { get; set; }
        public long InterrogatoriosId { get; set; }
        public InterrogatoriosDto Interrogatorios { get; set; }
    }
}
