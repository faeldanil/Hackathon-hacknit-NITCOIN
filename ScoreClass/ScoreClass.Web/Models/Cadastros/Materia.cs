using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreClass.Web.Models.Cadastros
{
    public class Materia
    {
        [Key]
        public long Id { get; set; }
        public string Nome { get;  set; }
        public virtual Aluno Aluno { get;  set; }
        public virtual List<Nota> Notas { get; set; }
    }
}
