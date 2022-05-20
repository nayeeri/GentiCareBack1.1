using System;
using System.Collections.Generic;
using System.Text;

namespace GentilCareBack.Dto
{
    public class CardioVascularDto
    {
        public long CardioVascularId { get; set; }

        public string name { get; set; }
        public bool valor { get; set; }
        public string? descripcion { get; set; }
        public long InterrogatoriosId { get; set; }
        public InterrogatoriosDto Interrogatorios { get; set; }
    }
}
