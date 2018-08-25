using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreClass.Web.Models.Cadastros
{
    public class Materia
    {
        public long Id { get; set; }
        public string Nome { get;  set; }
        public Aluno Aluno { get;  set; }
    }
}
