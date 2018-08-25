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

        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<Aluno> Escola { get; set; }
        public DbSet<Matricula> Matricula { get; set; }
        public DbSet<Materia> Materia { get; set; }
        public DbSet<Responsavel> Responsavel { get; set; }
        public DbSet<Pontualidade> Pontualidade { get; set; }
        public DbSet<Nota> Nota { get; set; }
        public DbSet<NitCoin> NitCoin { get; set; }
    }
}
