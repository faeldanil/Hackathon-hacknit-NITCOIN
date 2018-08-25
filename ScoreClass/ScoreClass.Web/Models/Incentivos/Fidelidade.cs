using System;
using System.ComponentModel.DataAnnotations;

namespace ScoreClass.Web.Models.Incentivos
{
	public class Fidelidade
	{
		[Key]
		public Int64 Id { get; set; }
		public virtual Parceria Parceria { get; set; }
		public DateTime InicioVigencia { get; set; }
		public DateTime FimVigencia { get; set; }
		public Decimal TaxaConversao { get; set; }
		public Int32 TempoVigenciaEmDias { get; set; }
	}
}