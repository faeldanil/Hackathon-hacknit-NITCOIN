using Microsoft.AspNetCore.Mvc;
using ScoreClass.Web.Data;
using ScoreClass.Web.Models.Cadastros;
using System.Linq;


namespace ScoreClass.Web.Controllers
{
	[Route("api/[controller]")]
	public class ReseedController : Controller
	{
		private readonly ApplicationDbContext _context;

		public ReseedController(ApplicationDbContext context)
		{
			_context = context;
		}

		[HttpGet("{id}")]
		public string Get(int id)
		{
			if (id == 10)
			{
				Drop(Repositorio.Ativo);
				Seed(Repositorio.Ativo);
			};

			return "Ok";
		}

		private void Drop(Repositorio r)
		{
			r.RemoveAll<Matricula>();
			r.RemoveAll<Aluno>();
			r.RemoveAll<Responsavel>();
			r.RemoveAll<Turma>();
			r.RemoveAll<Escola>();
		}

		private void Seed(Repositorio r)
		{
			if (!r.Obter<Responsavel>().Any())
			{
				var escola = new Escola { Nome = "ScoreClass" };
				var turma = new Turma { Nome = "7º Ano", Escola = escola };
				escola.Turmas.Add(turma);

				var responsavel = new Responsavel() { Nome = "Glautter", Email = new Email { Descricao = "glautterg@gmail.com" } };
				var aluno1 = new Aluno { Nome = "Aluno 1", Responsavel = responsavel, Email = new Email { Descricao = "aluno1@nitcoin.com.br" } };
				var aluno2 = new Aluno { Nome = "Aluno 2", Responsavel = responsavel, Email = new Email { Descricao = "aluno2@nitcoin.com.br" } };

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

				materia1a2.Notas.Add(new Nota { Bimestre = "1o", Descricao = "8,6", Materia = materia1a2 });
				materia2a2.Notas.Add(new Nota { Bimestre = "1o", Descricao = "6,7", Materia = materia2a2 });
				materia3a2.Notas.Add(new Nota { Bimestre = "1o", Descricao = "7,3", Materia = materia3a2 });
				materia4a2.Notas.Add(new Nota { Bimestre = "1o", Descricao = "8,7", Materia = materia4a2 });
				materia5a2.Notas.Add(new Nota { Bimestre = "1o", Descricao = "5,6", Materia = materia5a2 });
				materia6a2.Notas.Add(new Nota { Bimestre = "1o", Descricao = "6,8", Materia = materia6a2 });

				materia1a2.Notas.Add(new Nota { Bimestre = "2o", Descricao = "6,6", Materia = materia1a2 });
				materia2a2.Notas.Add(new Nota { Bimestre = "2o", Descricao = "7,5", Materia = materia2a2 });
				materia3a2.Notas.Add(new Nota { Bimestre = "2o", Descricao = "10,0", Materia = materia3a2 });
				materia4a2.Notas.Add(new Nota { Bimestre = "2o", Descricao = "9,4", Materia = materia4a2 });
				materia5a2.Notas.Add(new Nota { Bimestre = "2o", Descricao = "5,9", Materia = materia5a2 });
				materia6a2.Notas.Add(new Nota { Bimestre = "2o", Descricao = "8,8", Materia = materia6a2 });


				aluno1.Matriculas.Add(matricula1);
				aluno2.Matriculas.Add(matricula1);


				turma.Matriculas.Add(matricula1);
				turma.Matriculas.Add(matricula2);

				r.Add(responsavel);
				r.Add(aluno1);
				r.Add(aluno2);
				r.Add(escola);
			}
		}
	}
}