using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GentilCareBack.Dto
{
    public class PreguntasDto
    {
        public long PreguntasId { get; set; }

        public UsersDto Users { get; set; }

        [MaxLength(300)]
        public string respuestaUno { get; set; }

        [MaxLength(300)]
        public string respuestaDos { get; set; }

        [MaxLength(300)]
        public string respuestaTres { get; set; }
    }
}
