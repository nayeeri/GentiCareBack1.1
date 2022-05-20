using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GentilCareBack.Models.Entity
{
    public class Roles
    {
        public long RolesId { get; set; }

        [MaxLength(300)]
        public string role { get; set; }
    }
}
