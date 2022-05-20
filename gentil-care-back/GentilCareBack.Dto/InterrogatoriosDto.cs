using System;
using System.Collections.Generic;
using System.Text;

namespace GentilCareBack.Dto
{
    public class InterrogatoriosDto
    {
		public long InterrogatoriosId { get; set; }
		public ServiciosDto Servicios { get; set; }
		public ICollection<PielTegumentosDto> PielTegumentos { get; set; }
		public ICollection<AparatoRespiratorioDto> AparatoRespiratorio { get; set; }
		public ICollection<CardioVascularDto> CardioVascular { get; set; }
		public ICollection<Esfera_PsiquicaDto> Esfera_Psiquica { get; set; }
		public ICollection<SentidosDto> Sentidos { get; set; }
		public ICollection<SintomasGeneralesDto> SintomasGenerales { get; set; }
		public ICollection<SistemaDigestivoDto> SistemaDigestivo { get; set; }
		public ICollection<SistemaEndocrinoDto> SistemaEndocrino { get; set; }
		public ICollection<SistemaEmatopoyeticoDto> SistemaEmatopoyetico { get; set; }
		public ICollection<SistemaMusculoEsqueleticoDto> SistemaMusculoEsqueletico { get; set; }
		public ICollection<SistemaNerviosoDto> SistemaNervioso { get; set; }
	}
}
