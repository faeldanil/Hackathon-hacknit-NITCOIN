using ScoreClass.Web.Models.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreClass.Web.Models.Incentivos
{
	public class NitCoin
	{
		public Int64 Id { get; set; }
		public Responsavel Responsavel { get; set; }
		public Int32 Quantidade { get; set; }
		public String Descricao { get; set; }
	}

	public class Voucher
	{
		public Int64 Id { get; set; }
		public NitCoin NitCoinOrigem { get; set; }
		public Fidelidade Fidelidade { get; set; }
		public Int32 Quantidade { get; set; }
		public Int32 Valor { get; set; }
		public String Codigo { get; set; }
		public DateTime Validade { get; set; }
		public Boolean Resgatado { get; set; }
	}

	public class Fidelidade
	{
		public Int64 Id { get; set; }
		public Parceria Parceria { get; set; }
		public DateTime InicioVigencia { get; set; }
		public DateTime FimVigencia { get; set; }
		public Decimal TaxaConversao { get; set; }
		public Int32 TempoVigenciaEmDias { get; set; }
	}

	public class Parceria
	{
		public Int64 Id { get; set; }
		public List<Fidelidade> Programas { get; set; }
	}

}
