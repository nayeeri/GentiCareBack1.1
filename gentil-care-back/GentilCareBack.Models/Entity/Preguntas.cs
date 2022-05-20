using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GentilCareBack.Models.Entity
{
    public class Preguntas
    {
        public long PreguntasId { get; set; }

        public Users Users { get; set; }

        [MaxLength(300)]
        public string respuestaUno { get; set; }

        [MaxLength(300)]
        public string respuestaDos { get; set; }

        [MaxLength(300)]
        public string respuestaTres { get; set; }
    }
}
