using System;
using System.Linq;

namespace ScoreClass.Web.Models.Incentivos
{
	public class Voucher : Entidade
	{
		private static readonly Random rand = new Random();

		public virtual Fidelidade Fidelidade { get; set; }
		public Int32 Quantidade { get; set; }
		public Decimal Valor { get; set; }
		public String Codigo { get; set; }
		public DateTime Validade { get; set; }
		public DateTime? Resgatado { get; set; }
		public TipoValor TipoValor { get; internal set; }
		public Boolean Ativo { get => (Validade >= DateTime.Now) && !Resgatado.HasValue; }
		public NitCoin NitCoin { get; internal set; }

		public Voucher()
		{
			Codigo = String.Join("", DateTime.Now.Ticks.ToString().Substring(1, 13).Select(Generate));
		}

		private Char Generate(char arg)
		{
			const string opcoes = "AB1CDEF3GH4J7KL8MN9PQRSTUVWXYZ";
			var index = (Convert.ToInt32(arg.ToString()) * 3) + (rand.Next(0, 100) % 3);
			return opcoes[index];
		}

		public void Resgatar()
		{
			Resgatado = DateTime.Now;
		}
	}
}