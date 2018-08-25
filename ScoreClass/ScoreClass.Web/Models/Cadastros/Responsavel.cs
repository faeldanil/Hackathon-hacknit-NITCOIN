using ScoreClass.Web.Models.Incentivos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ScoreClass.Web.Models.Cadastros
{
	public class Responsavel
    {
        [Key]
        public long Id { get;  set; }
        public string Nome { get;  set; }
        public Email Email { get;  set; }
        public string Telefone { get;  set; }
        public string Cpf { get; set; }
		public virtual List<NitCoin> NitCoins { get; set; } = new List<NitCoin>();
		public virtual List<Voucher> Vouchers { get; set; } = new List<Voucher>();

		public int ObterSaldo()
		{
			return NitCoins.Sum(nc => nc.Quantidade);
		}


		public void RegistrarAtividade(TipoAtividade tipoAtividade)
		{
			var politicaIncentivo = PoliticasIncentivo.Instance.Value.ObterAtivo(DateTime.Today);
			var quantidade = politicaIncentivo.ObterQuantidade(tipoAtividade);

			var nitCoin = new NitCoin { Responsavel = this, Quantidade = quantidade, Descricao = tipoAtividade.ToString(), Registro = DateTime.Now };

			NitCoins.Add(nitCoin);
		}


		public Voucher GerarVoucher(Fidelidade fidelidade)
		{
			var voucher = new Voucher { Fidelidade = fidelidade, Responsavel = this };

			return voucher;
		}

		
	}
}
