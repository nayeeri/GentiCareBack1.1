using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GentilCareBack.Dto
{

	public class ResponseVerColaboradores { 
		public List<UsersDto> doctores { get; set; }
		public bool status { get; set; }
	}

	public class ResponseVerFamiliares
	{
		public List<UsersDto> familiares { get; set; }
		public bool status { get; set; }
	}

	public class ResponseFamiliarOne { 
		public UsersDto familiar { get; set; }
		public bool status { get; set; }
	}

	public class ResponseUsuarioOne
	{
		public UsersDto usuario { get; set; }
		public bool status { get; set; }
		public string msg { get; set; }
	}

	public class requestUser { 
		public UsersDto data { get; set; }
		public AddressesDto address { get; set; }
		public ColaboradorsDto cola { get; set; }
		public List<Disponible> disponible { get; set; }
	}

	public class Disponible { 
		public List<string> Lunes { get; set; }
		public List<string> Martes { get; set; }
		public List<string> Miercoles { get; set; }
		public List<string> Jueves { get; set; }
		public List<string> Viernes { get; set; }
		public List<string> Sabado { get; set; }
		public List<string> Domingo { get; set; }

	}

	public class requestUserVerify
	{
		//public UsersDto usuario { get; set; }
		public string pin { get; set; }
		public string email { get; set; }
	}
	public class UsersDto
    {
		public long _id { get; set; }
		public long UsersId { get; set; }

		[MaxLength(350)]
		public string? email { get; set; }

		public string nombre { get; set; }

		public string A_P { get; set; }

		public string A_M { get; set; }

		public string surnames { get; set; }

		public string filename { get; set; }
		public DateTime? fecha_nac { get; set; }
		public string? sexo { get; set; }

		[MaxLength(20)]
		public string cellphone { get; set; }
		//public string especialidades { get; set; }
		public string customerID { get; set; }

		public string preguntaUno { get; set; }
		public string preguntaDos { get; set; }
		public string preguntaTres { get; set; }

		public bool status { get; set; }
        public string token { get; set; }
		public string pin { get; set; }

		public RolesDto role { get; set; }

		public AuthsDto auth { get; set; }
		public string  tipo { get; set; }

		public string name { get; set; }

		public string tel_part { get; set; }
		public bool colaborador { get; set; }

		public string password { get; set; }
		[MaxLength(50)]
		public string? parentezco { get; set; }

	}
}
