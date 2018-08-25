using ScoreClass.Web.Models.Incentivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreClass.Web.Models.Cadastros
{
    public class Aluno
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public Email Email { get; set; }
        public string Telefone { get; set; }
        public Responsavel Reponsavel { get; set; }

		public void RegistrarAtividade(TipoAtividade tipoAtividade)
		{
			Reponsavel.RegistrarAtividade(tipoAtividade);
		}
	}
}
