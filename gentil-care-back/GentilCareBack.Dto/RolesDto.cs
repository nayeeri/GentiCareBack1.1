using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GentilCareBack.Dto
{

    public class requestRoles { 
        public RolesDto data { get; set; }
    }

    public class RolesDto
    {
        public long RolesId { get; set; }

        [MaxLength(300)]
        public string role { get; set; }

        public string rol { get; set; }
    }
}
