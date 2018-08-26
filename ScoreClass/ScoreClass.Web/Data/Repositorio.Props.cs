using ScoreClass.Web.Models.Cadastros;
using ScoreClass.Web.Models.Campanhas;
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
		public IEnumerable<Professor> Professor { get => Obter<Professor>(); }
		public IEnumerable<Responsavel> Responsavel { get => Obter<Responsavel>(); }

		public IEnumerable<Parceria> Parceria { get => Obter<Parceria>(); }
		public IEnumerable<Voucher> Voucher { get => Obter<Voucher>(); }
		public IEnumerable<NitCoin> NitCoin { get => Obter<NitCoin>(); }
		public IEnumerable<PoliticaIncentivo> PoliticaIncentivo { get => Obter<PoliticaIncentivo>(); }
		public IEnumerable<Campanha> Campanha { get => Obter<Campanha>(); }




		private readonly Random random = new Random();

		public string NotaAleatoria { get => (Convert.ToDecimal(random.Next(0, 100)) / 10M).ToString(); }

		public Repositorio() { Setup(); }

		private void Setup()
		{
			SetupAlunos();
			SetupParceiros();
			SetupCampanhas();
		}

		private void SetupCampanhas()
		{
			if (!Campanha.Any())
			{
				Add(new Campanha { Titulo = "Aulão de Matematica", Descricao = "Grande Aulao", Inicio = DateTime.Today.AddHours(14), Termino = DateTime.Today.AddHours(17), TipoCampanha = TipoCampanha.AulaReforco });
				Add(new Campanha { Titulo = "Grupo de Estudos", Descricao = "Gupo de estudos", Inicio = DateTime.Today.AddDays(1).AddHours(15), Termino = DateTime.Today.AddDays(1).AddHours(17), TipoCampanha = TipoCampanha.GrupoEstudo });
				Add(new Campanha { Titulo = "Passeio no Bosque", Descricao = "Gupo de estudos", Inicio = DateTime.Today.AddDays(3).AddHours(13), Termino = DateTime.Today.AddDays(3).AddHours(16), TipoCampanha = TipoCampanha.InclusaoSocial });
			}
		}

		private void SetupParceiros()
		{
			if (!Parceria.Any())
			{
				Add(new PoliticaIncentivo { Id = 1, QuantidadePorAcesso = 1, QuantidadePorAcompanhamentoOnLine = 5, QuantidadePorAcompanhamentoPresencial = 100, InicioVigencia = new DateTime(2018, 08, 01) });
				Add(new PoliticaIncentivo { Id = 2, QuantidadePorAcesso = 1, QuantidadePorAcompanhamentoOnLine = 5, QuantidadePorAcompanhamentoPresencial = 100, InicioVigencia = new DateTime(2018, 08, 01) });

				var parceria1 = Add(new Parceria { Nome = "Farmacia nikit" });
				parceria1.Programas.Add(Add(new Fidelidade { Parceria = parceria1, Descricao = "5% de desconto em produtos de beleza por 2 nitCoins", InicioVigencia = DateTime.Today.AddDays(-3), FimVigencia = DateTime.Today.AddMonths(1), TaxaConversao = 2, TempoVigenciaEmDias = 7, Valor = 5, TipoValor = TipoValor.Percentual }));
				parceria1.Programas.Add(Add(new Fidelidade { Parceria = parceria1, Descricao = "R$ 1,00 de desconto em compras acima de 10 reais por apenas 1 nitCoin", InicioVigencia = DateTime.Today.AddDays(-3), FimVigencia = DateTime.Today.AddMonths(2), TaxaConversao = 1, TempoVigenciaEmDias = 7, Valor = 1, TipoValor = TipoValor.Valor }));

				var parceria2 = Add(new Parceria { Nome = "Horti-Fuit nikit" });
				parceria2.Programas.Add(Add(new Fidelidade { Parceria = parceria2, Descricao = "10% de desconto em verduras hidroponicas", InicioVigencia = DateTime.Today.AddDays(-3), FimVigencia = DateTime.Today.AddMonths(1), TaxaConversao = 3, TempoVigenciaEmDias = 7, Valor = 5, TipoValor = TipoValor.Percentual }));
				parceria2.Programas.Add(Add(new Fidelidade { Parceria = parceria2, Descricao = "5% de desconto em compras acima de 50 reais", InicioVigencia = DateTime.Today.AddDays(-3), FimVigencia = DateTime.Today.AddMonths(2), TaxaConversao = 1, TempoVigenciaEmDias = 7, Valor = 1, TipoValor = TipoValor.Percentual }));
				parceria2.Programas.Add(Add(new Fidelidade { Parceria = parceria2, Descricao = "R$ 5,00 de desconto em compras acima de 50 reais", InicioVigencia = DateTime.Today.AddDays(-3), FimVigencia = DateTime.Today.AddMonths(2), TaxaConversao = 1, TempoVigenciaEmDias = 7, Valor = 1, TipoValor = TipoValor.Valor }));

				var parceria3 = Add(new Parceria { Nome = "Cinema" });
				parceria3.Programas.Add(Add(new Fidelidade { Parceria = parceria3, Descricao = "10% de desconto em Compos de pipocas", InicioVigencia = DateTime.Today.AddDays(-3), FimVigencia = DateTime.Today.AddMonths(1), TaxaConversao = 3, TempoVigenciaEmDias = 7, Valor = 5, TipoValor = TipoValor.Percentual }));
				parceria3.Programas.Add(Add(new Fidelidade { Parceria = parceria3, Descricao = "5% de desconto em Filmes", InicioVigencia = DateTime.Today.AddDays(-3), FimVigencia = DateTime.Today.AddMonths(2), TaxaConversao = 1, TempoVigenciaEmDias = 7, Valor = 1, TipoValor = TipoValor.Percentual }));
			}
		}

		private void SetupAlunos()
		{
			if (!Responsavel.Any())
			{
				var escola = Add(new Escola { Nome = "ScoreClass" });
				var turma = Add(new Turma { Nome = "7º Ano", Escola = escola });
				escola.Turmas.Add(turma);

				Add(new Disciplina { Nome = "matematica", Turma = turma });
				Add(new Disciplina { Nome = "portugues", Turma = turma });
				Add(new Disciplina { Nome = "Ciencias", Turma = turma });
				Add(new Disciplina { Nome = "geografia", Turma = turma });

				var responsavel = Add(new Responsavel() { Nome = "Glautter", Email = new Email { Descricao = "glautterg@gmail.com" } });
				var aluno1 = Add(new Aluno { Nome = "Aluno 1", Responsavel = responsavel, Email = new Email { Descricao = "aluno1@nitcoin.com.br" } });
				var matricula1 = Add(new Matricula { Aluno = aluno1, Turma = turma, Codigo = "codigo 1", AnoLetivo = DateTime.Today.Year });
				aluno1.Matriculas.Add(matricula1);
				turma.Matriculas.Add(matricula1);

				var aluno2 = Add(new Aluno { Nome = "Aluno 2", Responsavel = responsavel, Email = new Email { Descricao = "aluno2@nitcoin.com.br" } });
				var matricula2 = Add(new Matricula { Aluno = aluno2, Turma = turma, Codigo = "codigo 2", AnoLetivo = DateTime.Today.Year });
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

					for (int i = 0; i < 20; i++)
					{
						materia_A1.Frequencias.Add(new Frequencia { Bimestre = "1o", Compareceu = random.Next() % 2 == 0, Materia = materia_A1, DataHora = DateTime.Now });
						materia_A1.Frequencias.Add(new Frequencia { Bimestre = "2o", Compareceu = random.Next() % 2 == 0, Materia = materia_A1, DataHora = DateTime.Now });
						materia_A1.Frequencias.Add(new Frequencia { Bimestre = "3o", Compareceu = random.Next() % 2 == 0, Materia = materia_A1, DataHora = DateTime.Now });
						materia_A1.Frequencias.Add(new Frequencia { Bimestre = "4o", Compareceu = random.Next() % 2 == 0, Materia = materia_A1, DataHora = DateTime.Now });
					}

					materia_A1.Ocorrencias.Add(new Ocorrencia { Materia = materia_A1, DataHora = DateTime.Now, Descricao = "Passou mal em aula", TipoComportamento = StatusAvaliacao.Neutra });
					materia_A1.Ocorrencias.Add(new Ocorrencia { Materia = materia_A1, DataHora = DateTime.Now, Descricao = "Apesenta sinais de cansaço", TipoComportamento = StatusAvaliacao.Negativa });
					materia_A1.Ocorrencias.Add(new Ocorrencia { Materia = materia_A1, DataHora = DateTime.Now, Descricao = "Aluno se destacou dos demais pela pesquisa muito bem laborada", TipoComportamento = StatusAvaliacao.Positiva });


					var materia_A2 = new Materia { Aluno = aluno2, Nome = disciplina.Nome, Disciplina = disciplina };
					matricula2.Materias.Add(materia_A2);
					materia_A2.Notas.Add(new Nota { Bimestre = "1o", Descricao = NotaAleatoria, Materia = materia_A2 });
					materia_A2.Notas.Add(new Nota { Bimestre = "2o", Descricao = NotaAleatoria, Materia = materia_A2 });
					materia_A2.Notas.Add(new Nota { Bimestre = "3o", Descricao = NotaAleatoria, Materia = materia_A2 });
					materia_A2.Notas.Add(new Nota { Bimestre = "4o", Descricao = NotaAleatoria, Materia = materia_A2 });

					for (int i = 0; i < 20; i++)
					{
						materia_A2.Frequencias.Add(new Frequencia { Bimestre = "1o", Compareceu = random.Next() % 2 == 0, Materia = materia_A2, DataHora = DateTime.Now });
						materia_A2.Frequencias.Add(new Frequencia { Bimestre = "2o", Compareceu = random.Next() % 2 == 0, Materia = materia_A2, DataHora = DateTime.Now });
						materia_A2.Frequencias.Add(new Frequencia { Bimestre = "3o", Compareceu = random.Next() % 2 == 0, Materia = materia_A2, DataHora = DateTime.Now });
						materia_A2.Frequencias.Add(new Frequencia { Bimestre = "4o", Compareceu = random.Next() % 2 == 0, Materia = materia_A2, DataHora = DateTime.Now });
					}

					materia_A2.Ocorrencias.Add(new Ocorrencia { Materia = materia_A2, DataHora = DateTime.Now, Descricao = "Passou mal em aula", TipoComportamento = StatusAvaliacao.Neutra });
					materia_A2.Ocorrencias.Add(new Ocorrencia { Materia = materia_A2, DataHora = DateTime.Now, Descricao = "Apesenta sinais de cansaço", TipoComportamento = StatusAvaliacao.Negativa });
					materia_A2.Ocorrencias.Add(new Ocorrencia { Materia = materia_A2, DataHora = DateTime.Now, Descricao = "Aluno se destacou dos demais pela pesquisa muito bem laborada", TipoComportamento = StatusAvaliacao.Positiva });

				}
			}
		}
	}

	public static class PoliticaIncentivoExtension
	{
		public static PoliticaIncentivo ObterAtivo(this IEnumerable<PoliticaIncentivo> politicas, DateTime data)
		{
			return politicas.Where(p => p.InicioVigencia <= data).OrderByDescending(p => p.InicioVigencia).FirstOrDefault();
		}
	}
}