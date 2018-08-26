using System.Collections.Generic;

namespace ScoreClass.Web.Models.Cadastros
{
	public class Escola : Entidade
	{
		public string Nome { get; set; }
		public virtual List<Turma> Turmas { get; set; } = new List<Turma>();
	}
}