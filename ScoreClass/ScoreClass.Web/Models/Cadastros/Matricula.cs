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
        public virtual Aluno Aluno { get; set; }
        public virtual IEnumerable<Pontualidade> Pontualidades { get; set; }
        public virtual IEnumerable<Materia> Materias { get; set; }
    }
}
