using System.Collections.Generic;

namespace ScoreClass.Web.Models.Cadastros
{
	public class Turma : Entidade
	{
        public string Nome { get;  set; }
        public Escola Escola { get;  set; }
        public List<Matricula> Matriculas { get;  set; } = new List<Matricula>();

	}
}