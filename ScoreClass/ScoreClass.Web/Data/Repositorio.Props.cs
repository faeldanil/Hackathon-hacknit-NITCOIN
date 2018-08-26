using ScoreClass.Web.Models.Cadastros;
using ScoreClass.Web.Models.Incentivos;
using System.Collections.Generic;
using System.Linq;

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

		public Repositorio() { Setup(); }
		private void Setup()
		{
			if (!Responsavel.Any())
			{
				var escola = new Escola { Nome = "ScoreClass" };
				var turma = new Turma { Nome = "7º Ano", Escola = escola };
				escola.Turmas.Add(turma);

				var responsavel = new Responsavel() { Nome = "Glautter", Email = new Email { Descricao = "glautterg@gmail.com" } };
				var aluno1 = new Aluno { Nome = "Aluno 1", Reponsavel = responsavel, Email = new Email { Descricao = "aluno1@nitcoin.com.br" } };
				var aluno2 = new Aluno { Nome = "Aluno 2", Reponsavel = responsavel, Email = new Email { Descricao = "aluno2@nitcoin.com.br" } };

				var matricula1 = new Matricula { Aluno = aluno1, Turma = turma, Codigo = "codigo 1" };
				var matricula2 = new Matricula { Aluno = aluno2, Turma = turma, Codigo = "codigo 2" };

				var materia1a1 = new Materia { Aluno = aluno1, Nome = "matematica" };
				var materia2a1 = new Materia { Aluno = aluno1, Nome = "portugues" };
				var materia3a1 = new Materia { Aluno = aluno1, Nome = "ciencias sociais" };
				var materia4a1 = new Materia { Aluno = aluno1, Nome = "historia" };
				var materia5a1 = new Materia { Aluno = aluno1, Nome = "geografia" };
				var materia6a1 = new Materia { Aluno = aluno1, Nome = "educacao fisica" };

				var materia1a2 = new Materia { Aluno = aluno2, Nome = "matematica" };
				var materia2a2 = new Materia { Aluno = aluno2, Nome = "portugues" };
				var materia3a2 = new Materia { Aluno = aluno2, Nome = "ciencias sociais" };
				var materia4a2 = new Materia { Aluno = aluno2, Nome = "historia" };
				var materia5a2 = new Materia { Aluno = aluno2, Nome = "geografia" };
				var materia6a2 = new Materia { Aluno = aluno2, Nome = "educacao fisica" };

				matricula1.Materias.Add(materia1a1);
				matricula1.Materias.Add(materia2a1);
				matricula1.Materias.Add(materia3a1);
				matricula1.Materias.Add(materia4a1);
				matricula1.Materias.Add(materia5a1);
				matricula1.Materias.Add(materia6a1);

				matricula2.Materias.Add(materia1a2);
				matricula2.Materias.Add(materia2a2);
				matricula2.Materias.Add(materia3a2);
				matricula2.Materias.Add(materia4a2);
				matricula2.Materias.Add(materia5a2);
				matricula2.Materias.Add(materia6a2);

				materia1a1.Notas.Add(new Nota { Bimestre = "1o", Descricao = "10,0", Materia = materia1a1 });
				materia2a1.Notas.Add(new Nota { Bimestre = "1o", Descricao = " 9,5", Materia = materia2a1 });
				materia4a1.Notas.Add(new Nota { Bimestre = "1o", Descricao = "10,0", Materia = materia4a1 });
				materia5a1.Notas.Add(new Nota { Bimestre = "1o", Descricao = "10,0", Materia = materia5a1 });
				materia6a1.Notas.Add(new Nota { Bimestre = "1o", Descricao = "10,0", Materia = materia6a1 });

				materia1a1.Notas.Add(new Nota { Bimestre = "2o", Descricao = "8,7", Materia = materia1a1 });
				materia2a1.Notas.Add(new Nota { Bimestre = "2o", Descricao = "7,9", Materia = materia2a1 });
				materia3a1.Notas.Add(new Nota { Bimestre = "2o", Descricao = "9,5", Materia = materia3a1 });
				materia4a1.Notas.Add(new Nota { Bimestre = "2o", Descricao = "10,0", Materia = materia4a1 });
				materia5a1.Notas.Add(new Nota { Bimestre = "2o", Descricao = "6,5", Materia = materia5a1 });
				materia6a1.Notas.Add(new Nota { Bimestre = "2o", Descricao = "10,0", Materia = materia6a1 });

				//materia1a2.Notas.Add(new Nota { Bimestre = "1o", Descricao = "8,6", Materia = materia1a2 });
				//materia2a2.Notas.Add(new Nota { Bimestre = "1o", Descricao = "6,7", Materia = materia2a2 });
				//materia3a2.Notas.Add(new Nota { Bimestre = "1o", Descricao = "7,3", Materia = materia3a2 });
				//materia4a2.Notas.Add(new Nota { Bimestre = "1o", Descricao = "8,7", Materia = materia4a2 });
				//materia5a2.Notas.Add(new Nota { Bimestre = "1o", Descricao = "5,6", Materia = materia5a2 });
				//materia6a2.Notas.Add(new Nota { Bimestre = "1o", Descricao = "6,8", Materia = materia6a2 });

				//materia1a2.Notas.Add(new Nota { Bimestre = "2o", Descricao = "6,6", Materia = materia1a2 });
				//materia2a2.Notas.Add(new Nota { Bimestre = "2o", Descricao = "7,5", Materia = materia2a2 });
				//materia3a2.Notas.Add(new Nota { Bimestre = "2o", Descricao = "10,0", Materia = materia3a2 });
				//materia4a2.Notas.Add(new Nota { Bimestre = "2o", Descricao = "9,4", Materia = materia4a2 });
				//materia5a2.Notas.Add(new Nota { Bimestre = "2o", Descricao = "5,9", Materia = materia5a2 });
				//materia6a2.Notas.Add(new Nota { Bimestre = "2o", Descricao = "8,8", Materia = materia6a2 });


				aluno1.Matriculas.Add(matricula1);
				aluno2.Matriculas.Add(matricula1);


				turma.Matriculas.Add(matricula1);
				turma.Matriculas.Add(matricula2);

				Add(matricula1);
				Add(matricula2);

				Add(responsavel);
				Add(aluno1);
				Add(aluno2);
				Add(escola);
			}
		}


	}
}