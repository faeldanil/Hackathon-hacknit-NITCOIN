using ScoreClass.Web.Models.Cadastros;
using ScoreClass.Web.Models.Incentivos;
using System.Collections.Generic;

namespace ScoreClass.Web.Data
{
	public partial class Repositorio
	{
		public void SaveChanges() { }
		public IEnumerable<Aluno> Aluno { get => Obter<Aluno>(); }
		public IEnumerable<Email> Email { get => Obter<Email>(); }
		public IEnumerable<Escola> Escola { get => Obter<Escola>(); }
		public IEnumerable<Frequencia> Frequencia { get => Obter<Frequencia>(); }
		public IEnumerable<Materia> Materia { get => Obter<Materia>(); }
		public IEnumerable<Matricula> Matricula { get => Obter<Matricula>(); }
		public IEnumerable<Nota> Nota { get => Obter<Nota>(); }
		public IEnumerable<Ocorrencia> Ocorrencia { get => Obter<Ocorrencia>(); }
		public IEnumerable<Pontualidade> Pontualidade { get => Obter<Pontualidade>(); }
		public IEnumerable<Professor> Professor { get => Obter<Professor>(); }
		public IEnumerable<Responsavel> Responsavel { get => Obter<Responsavel>(); }
		public IEnumerable<Turma> Turma { get => Obter<Turma>(); }

		public IEnumerable<Fidelidade> Fidelidade { get => Obter<Fidelidade>(); }
		public IEnumerable<NitCoin> NitCoin { get => Obter<NitCoin>(); }
		public IEnumerable<Parceria> Parceria { get => Obter<Parceria>(); }
		public IEnumerable<PoliticaIncentivo> PoliticaIncentivo { get => Obter<PoliticaIncentivo>(); }
		public IEnumerable<Voucher> Voucher { get => Obter<Voucher>(); }

	}
}