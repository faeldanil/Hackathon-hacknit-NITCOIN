using ScoreClass.Web.Models.Cadastros;
using System;
using System.Linq;

namespace ScoreClass.Web.Models.Incentivos
{

	public enum TipoAtividade
	{
		Acesso, AcompanhamentoOnLine, AcompanhamentoPresencial
	}

	public class PoliticaIncentivo
	{
		public Int64 Id { get; set; }
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

	public class PoliticasIncentivo
	{
		public static Lazy<PoliticasIncentivo> Instance = new Lazy<PoliticasIncentivo>();
		private static readonly PoliticaIncentivo[] _politicas = new[]
		{
			new PoliticaIncentivo{Id = 1, QuantidadePorAcesso = 1, QuantidadePorAcompanhamentoOnLine = 5, QuantidadePorAcompanhamentoPresencial = 100, InicioVigencia = new DateTime(2018, 08,01)},
			new PoliticaIncentivo{Id = 2, QuantidadePorAcesso = 1, QuantidadePorAcompanhamentoOnLine = 5, QuantidadePorAcompanhamentoPresencial = 100, InicioVigencia = new DateTime(2018, 08,01)},
		};

		public PoliticaIncentivo ObterAtivo(DateTime data)
		{
			return _politicas.Where(p => p.InicioVigencia <= data).OrderByDescending(p => p.InicioVigencia).FirstOrDefault();
		}

	}
}