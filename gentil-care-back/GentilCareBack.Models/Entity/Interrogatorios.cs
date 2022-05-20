using System;
using System.Collections.Generic;
using System.Text;

namespace GentilCareBack.Models.Entity
{
	public class Interrogatorios
	{
		public long InterrogatoriosId { get; set; }
		public Servicios Servicios { get; set; }
		public ICollection<PielTegumentos> PielTegumentos { get; set; }
		public ICollection<AparatoRespiratorio> AparatoRespiratorio { get; set; }
		public ICollection<CardioVascular> CardioVascular { get; set; }
		public ICollection<Esfera_Psiquica> Esfera_Psiquica { get; set; }
		public ICollection<Sentidos> Sentidos { get; set; }
		public ICollection<SintomasGenerales> SintomasGenerales { get; set; }
		public ICollection<SistemaDigestivo> SistemaDigestivo { get; set; }
		public ICollection<SistemaEndocrino> SistemaEndocrino { get; set; }
		public ICollection<SistemaEmatopoyetico> SistemaEmatopoyetico { get; set; }
		public ICollection<SistemaMusculoEsqueletico> SistemaMusculoEsqueletico { get; set; }
		public ICollection<SistemaNervioso> SistemaNervioso { get; set;}
	}
}
