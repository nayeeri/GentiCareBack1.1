using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GentilCareBack.Models.Entity
{
    public class Users
    {
		public long UsersId { get; set; }

		[MaxLength(350)]
		public string? email { get; set; }


		public string name { get; set; }

		[MaxLength(35)]
		public string firsname { get; set; }

		[MaxLength(35)]
		public string lastname { get; set; }

		public string filename { get; set; }
		public DateTime? birthday { get; set; }
		public string? gender { get; set; }

		[MaxLength(20)]
		public string cellphone { get; set; }
		public string especialidades { get; set; }
		public string? customerID { get; set; }
		[MaxLength(50)]
		public string? parentezco { get; set; }
		public Auths? Auths { get; set; }
	}
}
