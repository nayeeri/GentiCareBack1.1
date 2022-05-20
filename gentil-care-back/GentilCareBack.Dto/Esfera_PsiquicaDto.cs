using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GentilCareBack.Dto
{
    public class Esfera_PsiquicaDto
    {
        public long Esfera_PsiquicaId { get; set; }

        public string name { get; set; }
        public bool valor { get; set; }

        [MaxLength(350)]
        public string? descripcion { get; set; }
        public long InterrogatoriosId { get; set; }
        public InterrogatoriosDto Interrogatorios { get; set; }
    }
}
