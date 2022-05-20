using System;
using System.Collections.Generic;
using System.Text;

namespace GentilCareBack.Dto
{
    public class AuthsDto
    {
		public long AuthsId { get; set; }
		public RolesDto Roles { get; set; }
		public string username { get; set; }
		public string password { get; set; }
		public bool verified { get; set; }
		public DateTime? created_at { get; set; }
		public string acceso { get; set; }
		public bool status { get; set; }
		public string token { get; set; }
		public long? UsersId { get; set; }

	}
}
