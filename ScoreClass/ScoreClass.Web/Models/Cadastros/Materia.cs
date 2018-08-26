using System.Collections.Generic;

namespace ScoreClass.Web.Models.Cadastros
{
	public class Materia : Entidade
	{
		public string Nome { get; set; }
		public virtual Aluno Aluno { get; set; }
		public virtual List<Nota> Notas { get; set; } = new List<Nota>();
		public Disciplina Disciplina { get; set; }
        public virtual List<Frequencia> Frequencias { get; set; } = new List<Frequencia>();
    }
}