using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreClass.Web.Models.Cadastros
{
    public class Matricula
    {
        public long Id { get; set; }
        public long Codigo { get; set; }
        public Aluno Aluno { get; set; }
        public IEnumerable<Pontualidade> Pontualidades { get; set; }
    }
}
