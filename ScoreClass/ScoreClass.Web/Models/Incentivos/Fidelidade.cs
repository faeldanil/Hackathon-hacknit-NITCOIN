using System;
using System.ComponentModel.DataAnnotations;

namespace ScoreClass.Web.Models.Incentivos
{

	public enum TipoValor
	{
		Reais, Percentual
	}

	public class Fidelidade
	{
		[Key]
		public Int64 Id { get; set; }
		public virtual Parceria Parceria { get; set; }
		public DateTime InicioVigencia { get; set; }
		public DateTime FimVigencia { get; set; }
		public Decimal Valor { get; internal set; }
		public TipoValor TipoValor { get; internal set; }
		public Int32 TaxaConversao { get; set; }
		public Int32 TempoVigenciaEmDias { get; set; }
		public String Descricao { get; set; }
	}
}