using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ScoreClass.Web.Models;
using ScoreClass.Web.Models.Cadastros;
using ScoreClass.Web.Models.Incentivos;

namespace ScoreClass.Web.Data
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
			Seed();
		}

		private void Seed()
		{
			if (!Responsavel.Any())
			{
				var escola = new Escola { Nome = "ScoreClass", Turmas = new List<Turma>() };
				var turma = new Turma { Nome = "7º Ano", Escola = escola};
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

				Responsavel.Add(responsavel);
				Aluno.Add(aluno1);
				Aluno.Add(aluno2);
				Escola.Add(escola);
				SaveChanges();
			}
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
		}

		public virtual DbSet<Aluno> Aluno { get; set; }
		public virtual DbSet<Escola> Escola { get; set; }
		public virtual DbSet<Matricula> Matricula { get; set; }
		public virtual DbSet<Materia> Materia { get; set; }
		public virtual DbSet<Responsavel> Responsavel { get; set; }
		public virtual DbSet<Pontualidade> Pontualidade { get; set; }
		public virtual DbSet<Nota> Nota { get; set; }
		public virtual DbSet<NitCoin> NitCoin { get; set; }
		public virtual DbSet<Ocorrencia> Ocorrencia { get; set; }
		public virtual DbSet<Turma> Turma { get; set; }
		public virtual DbSet<Frequencia> Frequencia { get; set; }
		public virtual DbSet<Professor> Professor { get; set; }
		public virtual DbSet<Voucher> Voucher { get; set; }
	}
}
