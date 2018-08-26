using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreClass.Web.Models.Cadastros
{
    public class Escola
    {
        [Key]
        public long Id { get;  set; }
        public string Nome { get;  set; }
		public virtual List<Turma> Turmas { get; set; } = new List<Turma>();
	}
}
