using System.Collections.Generic;

namespace ScoreClass.Web.Models.Cadastros
{
	public class Professor : Entidade
	{
		public string Nome { get; set; }
		public IEnumerable<Materia> Materias { get; set; }
	}
}