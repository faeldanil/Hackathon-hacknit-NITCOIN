using System;

namespace ScoreClass.Web.Models.Cadastros
{
	public class Disciplina: Entidade
    {
		public String Nome { get; set; }
		public Turma Turma { get; internal set; }
	}
}
