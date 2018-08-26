using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScoreClass.Web.Data;
using ScoreClass.Web.Models.Cadastros;
using System;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ScoreClass.Web
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
				Drop(_context);
				Seed(_context);
			};

			return "Ok";
		}

		private void Drop(ApplicationDbContext c)
		{
			c.RemoveAll(c.Matricula);
			c.RemoveAll(c.Aluno);
			c.RemoveAll(c.Responsavel);
			c.RemoveAll(c.Turma);
			c.RemoveAll(c.Escola);
		}

		private void Seed(ApplicationDbContext c)
		{

			if (!c.Responsavel.Any())
			{
				var escola = new Escola { Nome = "ScoreClass" };
				var turma = new Turma { Nome = "7º Ano", Escola = escola };
				escola.Turmas.Add(turma);

				var responsavel = new Responsavel() { Nome = "Glautter", Email = new Email { Descricao = "glautterg@gmail.com" } };
				var aluno1 = new Aluno { Nome = "Aluno 1", Reponsavel = responsavel, Email = new Email { Descricao = "aluno1@nitcoin.com.br" } };
				var aluno2 = new Aluno { Nome = "Aluno 2", Reponsavel = responsavel, Email = new Email { Descricao = "aluno2@nitcoin.com.br" } };

				var matricula1 = new Matricula { Aluno = aluno1, Turma = turma };
				var matricula2 = new Matricula { Aluno = aluno2, Turma = turma };

				aluno1.Matriculas.Add(matricula1);
				aluno2.Matriculas.Add(matricula1);

				turma.Matriculas.Add(matricula1);
				turma.Matriculas.Add(matricula2);

				c.Responsavel.Add(responsavel);
				c.Aluno.Add(aluno1);
				c.Aluno.Add(aluno2);
				c.Escola.Add(escola);
				c.SaveChanges();
			}
		}
	}

	public static class Extension
	{
		public static void RemoveAll<T>(this DbContext c, DbSet<T> dbSet) where T : class
		{
			var entities = dbSet.ToArray();
			foreach (var entity in entities)
				dbSet.Remove(entity);

			c.SaveChanges();
		}
	}
}