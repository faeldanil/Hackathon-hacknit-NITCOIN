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
