using ScoreClass.Web.Models.Cadastros;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ScoreClass.Web.Models.Incentivos
{
	public enum TipoAtividade
	{
		Acesso, AcompanhamentoOnLine, AcompanhamentoPresencial, RendimentoAluno
	}

	public class PoliticaIncentivo : Entidade
	{
		public Int32 QuantidadePorAcesso { get; set; }
		public Int32 QuantidadePorAcompanhamentoOnLine { get; set; }
		public Int32 QuantidadePorAcompanhamentoPresencial { get; set; }
		public DateTime InicioVigencia { get; set; }

		public Int32 ObterQuantidade(TipoAtividade tipoAtividade)
		{
			switch (tipoAtividade)
			{
				case TipoAtividade.Acesso:
					return QuantidadePorAcesso;
				case TipoAtividade.AcompanhamentoOnLine:
					return QuantidadePorAcompanhamentoOnLine;
				case TipoAtividade.AcompanhamentoPresencial:
					return QuantidadePorAcompanhamentoPresencial;
				default:
					return 0;
			}
		}
	}
}