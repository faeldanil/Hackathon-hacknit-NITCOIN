using ScoreClass.Web.Models.Cadastros;
using System;

namespace ScoreClass.Web.Models.Incentivos
{
	public class NitCoin
	{
		public Int64 Id { get; set; }
		public Responsavel Responsavel { get; set; }
		public Int32 Quantidade { get; set; }
		public DateTime Registro { get; set; }
		public String Descricao { get; set; }
	}
}