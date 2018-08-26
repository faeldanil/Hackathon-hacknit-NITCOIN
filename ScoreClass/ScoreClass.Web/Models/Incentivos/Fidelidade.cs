using System;

namespace ScoreClass.Web.Models.Incentivos
{

	public enum TipoValor
	{
		Valor, Percentual
	}

	public class Fidelidade : Entidade
	{
		public virtual Parceria Parceria { get; set; }
		public DateTime InicioVigencia { get; set; }
		public DateTime FimVigencia { get; set; }
		public Decimal Valor { get; internal set; }
		public TipoValor TipoValor { get; internal set; }
		public Int32 TaxaConversao { get; set; }
		public Int32 TempoVigenciaEmDias { get; set; }
		public String Descricao { get; set; }
		public Boolean Ativo
		{
			get {
				var hoje = DateTime.Today;

				return (InicioVigencia <= hoje) && (FimVigencia >= hoje);
			}
		}
	}
}