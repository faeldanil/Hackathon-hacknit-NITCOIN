using ScoreClass.Web.Models.Incentivos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreClass.Web.Models.Cadastros
{
    public class Aluno
    {
        [Key]
        public long Id { get; set; }
        public string Nome { get; set; }
        public Email Email { get; set; }
        public string Telefone { get; set; }
        public virtual Responsavel Reponsavel { get; set; }
    }
        public Responsavel Reponsavel { get; set; }

		public void RegistrarAtividade(TipoAtividade tipoAtividade)
		{
			Reponsavel.RegistrarAtividade(tipoAtividade);
		}
	}
}
