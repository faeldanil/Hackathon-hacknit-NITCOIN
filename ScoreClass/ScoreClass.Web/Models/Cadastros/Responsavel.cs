using ScoreClass.Web.Models.Incentivos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ScoreClass.Web.Models.Cadastros
{
	public class Responsavel
    {
        [Key]
        public long Id { get;  set; }
        public string Nome { get;  set; }
        public Email Email { get;  set; }
        public string Telefone { get;  set; }
		public virtual List<Aluno> Alunos { get; set; } = new List<Aluno>();
		public virtual List<NitCoin> NitCoins { get; set; } = new List<NitCoin>();
		public virtual List<Voucher> Vouchers { get; set; } = new List<Voucher>();


		public void RegistrarAtividade(TipoAtividade tipoAtividade)
		{
			var politicaIncentivo = PoliticasIncentivo.Instance.Value.ObterAtivo(DateTime.Today);
			var quantidade = politicaIncentivo.ObterQuantidade(tipoAtividade);

			var nitCoin = new NitCoin { Responsavel = this, Quantidade = quantidade, Descricao = tipoAtividade.ToString(), Registro = DateTime.Now };

			NitCoins.Add(nitCoin);
		}


		
	}
}
