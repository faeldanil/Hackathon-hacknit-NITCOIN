using System;

namespace ScoreClass.Web.Models.Incentivos
{
	public class PoliticaIncentivo
	{
		public Int64 Id { get; set; }
		public Int32 QuantidadePorAcesso { get; set; }
		public Int32 QuantidadePorAcompanhamentoOnLine { get; set; }
		public Int32 QuantidadePorAcompanhamentoPresencial { get; set; }
		public DateTime InicioVigeencia { get; set; }
	}
}