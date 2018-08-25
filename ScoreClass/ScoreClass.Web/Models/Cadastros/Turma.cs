using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreClass.Web.Models.Cadastros
{
    public class Turma
    {
        [Key]
        public long Id { get;  set; }
        public string Nome { get;  set; }
        public Escola Escola { get;  set; }
        public List<Matricula> Matriculas { get;  set; } = new List<Matricula>();

	}
}
