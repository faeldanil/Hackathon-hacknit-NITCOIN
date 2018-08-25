using ScoreClass.Web.Models.Cadastros;
using System;
using System.ComponentModel.DataAnnotations;

namespace ScoreClass.Web.Models.Incentivos
{
	public class NitCoin
	{
		[Key]
		public Int64 Id { get; set; }
		public virtual Responsavel Responsavel { get; set; }
		public Int32 Quantidade { get; set; }
		public DateTime Registro { get; set; }
		public String Descricao { get; set; }
	}
}