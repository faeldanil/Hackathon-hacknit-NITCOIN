using ScoreClass.Web.Models.Incentivos;
using System.Collections.Generic;

namespace ScoreClass.Web.Models.Cadastros
{
	public class Aluno : Entidade
	{
		public string Nome { get; set; }
		public virtual Email Email { get; set; }
		public string Telefone { get; set; }
		public virtual Responsavel Reponsavel { get; set; }
		public virtual List<Matricula> Matriculas { get; set; } = new List<Matricula>();


		public void RegistrarAtividade(TipoAtividade tipoAtividade)
		{
			Reponsavel.RegistrarAtividade(tipoAtividade);
		}
	}
}