using System.Collections.Generic;

namespace ScoreClass.Web.Models.Cadastros
{
	public class Professor : Entidade
	{
		public string Nome { get; set; }
		public List<Materia> Materias { get; set; } = new List<Materia>();
	}
}