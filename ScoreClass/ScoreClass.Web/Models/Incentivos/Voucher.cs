using ScoreClass.Web.Models.Cadastros;
using System;
using System.ComponentModel.DataAnnotations;

namespace ScoreClass.Web.Models.Incentivos
{
	public class Voucher
	{
		[Key]
		public Int64 Id { get; set; }
		public virtual Responsavel Responsavel { get; set; }
		public virtual NitCoin NitCoinOrigem { get; set; }
		public virtual Fidelidade Fidelidade { get; set; }
		public Int32 Quantidade { get; set; }
		public Decimal Valor { get; set; }
		public String Codigo { get; set; }
		public DateTime Validade { get; set; }
		public Boolean Resgatado { get; set; }
		public TipoValor TipoValor { get; internal set; }

		public Voucher()
		{

		}
	}
}
