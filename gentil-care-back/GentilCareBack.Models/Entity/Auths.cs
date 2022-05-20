using System;
using System.Collections.Generic;
using System.Text;

namespace GentilCareBack.Models.Entity
{
    public class Auths
    {
		public long AuthsId { get; set; }


		public Roles? Roles { get; set; }
		public string username { get; set; }
		public string password { get; set; }
		public bool verified { get; set; }
		public DateTime? created_at { get; set; }
		public long? UsersId { get; set; }
	}
}
