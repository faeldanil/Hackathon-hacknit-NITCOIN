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
