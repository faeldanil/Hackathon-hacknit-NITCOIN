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
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<Voucher>().HasOne<Responsavel>();

/*			var responsavel = new Responsavel() { Nome = "Glautter" };
			Responsavel.Add(responsavel);
			Aluno.Add(new Aluno() { Nome = "Aluno 1", Reponsavel = responsavel });
			Aluno.Add(new Aluno() { Nome = "Aluno 1", Reponsavel = responsavel });
*/
		}

		public DbSet<Aluno> Aluno { get; set; }
		public DbSet<Escola> Escola { get; set; }
		public DbSet<Matricula> Matricula { get; set; }
		public DbSet<Materia> Materia { get; set; }
		public DbSet<Responsavel> Responsavel { get; set; }
		public DbSet<Pontualidade> Pontualidade { get; set; }
		public DbSet<Nota> Nota { get; set; }
		public DbSet<NitCoin> NitCoin { get; set; }
		public DbSet<Ocorrencia> Ocorrencia { get; set; }
		public DbSet<Turma> Turma { get; set; }
		public DbSet<Frequencia> Frequencia { get; set; }
		public DbSet<Professor> Professor { get; set; }
	}
}
