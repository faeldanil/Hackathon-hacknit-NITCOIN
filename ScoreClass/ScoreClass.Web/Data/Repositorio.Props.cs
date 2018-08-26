using ScoreClass.Web.Models.Cadastros;
using ScoreClass.Web.Models.Incentivos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ScoreClass.Web.Data
{
	public partial class Repositorio
	{
		public void SaveChanges() { }
		public IEnumerable<Aluno> Aluno { get => Obter<Aluno>(); }
		public IEnumerable<Disciplina> Disciplina { get => Obter<Disciplina>(); }
		public IEnumerable<Email> Email { get => Obter<Email>(); }
		public IEnumerable<Escola> Escola { get => Obter<Escola>(); }
		public IEnumerable<Frequencia> Frequencia { get => Obter<Frequencia>(); }
		public IEnumerable<Materia> Materia { get => Obter<Materia>(); }
		public IEnumerable<Matricula> Matricula { get => Obter<Matricula>(); }
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

		private readonly Random random = new Random();

		public string NotaAleatoria { get => (Convert.ToDecimal(random.Next(0, 100)) / 10M).ToString(); }

		public Repositorio() { Setup(); }
		private void Setup()
		{
			if (!Responsavel.Any())
			{
				var escola = new Escola { Nome = "ScoreClass" };
				Add(escola);
				var turma = new Turma { Nome = "7º Ano", Escola = escola };
				Add(turma);
				escola.Turmas.Add(turma);

				Add(new Disciplina { Nome = "matematica", Turma = turma });
				Add(new Disciplina { Nome = "portugues", Turma = turma });
				Add(new Disciplina { Nome = "Ciencias", Turma = turma });
				Add(new Disciplina { Nome = "geografia", Turma = turma });

				var responsavel = new Responsavel() { Nome = "Glautter", Email = new Email { Descricao = "glautterg@gmail.com" } };
				Add(responsavel);

				var aluno1 = new Aluno { Nome = "Aluno 1", Responsavel = responsavel, Email = new Email { Descricao = "aluno1@nitcoin.com.br" } };
				Add(aluno1);

				var aluno2 = new Aluno { Nome = "Aluno 2", Responsavel = responsavel, Email = new Email { Descricao = "aluno2@nitcoin.com.br" } };
				Add(aluno2);

				var matricula1 = new Matricula { Aluno = aluno1, Turma = turma, Codigo = "codigo 1", AnoLetivo = DateTime.Today.Year };
				Add(matricula1);
				aluno1.Matriculas.Add(matricula1);
				turma.Matriculas.Add(matricula1);

				var matricula2 = new Matricula { Aluno = aluno2, Turma = turma, Codigo = "codigo 2", AnoLetivo = DateTime.Today.Year };
				Add(matricula2);
				aluno2.Matriculas.Add(matricula2);
				turma.Matriculas.Add(matricula2);

				foreach (var disciplina in Disciplina)
				{
					turma.Disciplinas.Add(disciplina);
					var materia_A1 = new Materia { Aluno = aluno1, Nome = disciplina.Nome, Disciplina = disciplina };
					matricula1.Materias.Add(materia_A1);
					materia_A1.Notas.Add(new Nota { Bimestre = "1o", Descricao = NotaAleatoria, Materia = materia_A1 });
					materia_A1.Notas.Add(new Nota { Bimestre = "2o", Descricao = NotaAleatoria, Materia = materia_A1 });
					materia_A1.Notas.Add(new Nota { Bimestre = "3o", Descricao = NotaAleatoria, Materia = materia_A1 });
					materia_A1.Notas.Add(new Nota { Bimestre = "4o", Descricao = NotaAleatoria, Materia = materia_A1 });

					var materia_A2 = new Materia { Aluno = aluno2, Nome = disciplina.Nome, Disciplina = disciplina };
					matricula2.Materias.Add(materia_A2);
					materia_A2.Notas.Add(new Nota { Bimestre = "1o", Descricao = NotaAleatoria, Materia = materia_A2 });
					materia_A2.Notas.Add(new Nota { Bimestre = "2o", Descricao = NotaAleatoria, Materia = materia_A2 });
					materia_A2.Notas.Add(new Nota { Bimestre = "3o", Descricao = NotaAleatoria, Materia = materia_A2 });
					materia_A2.Notas.Add(new Nota { Bimestre = "4o", Descricao = NotaAleatoria, Materia = materia_A2 });
				}
			}
		}
	}
}