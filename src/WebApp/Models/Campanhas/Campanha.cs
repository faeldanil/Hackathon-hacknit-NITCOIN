using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreClass.Web.Models.Campanhas
{
	public enum TipoCampanha
	{
		AulaReforco, GrupoEstudo, InclusaoSocial
	}

	public class Campanha : Entidade
	{
		public String Titulo { get; set; }
		public TipoCampanha TipoCampanha { get; set; }
		public String Descricao { get; set; }

		public DateTime Inicio { get; set; }
		public DateTime Termino { get; set; }
	}
}