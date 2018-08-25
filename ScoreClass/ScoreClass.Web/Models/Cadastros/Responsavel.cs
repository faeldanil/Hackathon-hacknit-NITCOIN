using ScoreClass.Web.Extensions;
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
		public long Id { get; set; }
		public string Nome { get; set; }
		public Email Email { get; set; }
		public string Telefone { get; set; }
		public string Cpf { get; set; }
		public virtual List<NitCoin> NitCoins { get; set; } = new List<NitCoin>();
		public virtual IEnumerable<Voucher> Vouchers { get => NitCoins.Select(nc => nc.Voucher).Where(v => v != null); }
		public IEnumerable<Voucher> VouchersAtivos { get => Vouchers.Where(v => v.Ativo); }

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
			var saldoAtual = ObterSaldo();
			var quantidade = fidelidade.TaxaConversao;
			if ((saldoAtual <= 0) || (saldoAtual < quantidade))
				throw new NitCoinException($"Você não tem saldo suficiente para gerar este Voucher de {fidelidade.Descricao}");

			var dataHoraSolicitacao = DateTime.Now;

			var voucher = new Voucher()
			{
				Fidelidade = fidelidade,
				Quantidade = quantidade,
				Validade = dataHoraSolicitacao.AddDays(fidelidade.TempoVigenciaEmDias),
				Valor = fidelidade.Valor,
				TipoValor = fidelidade.TipoValor,
			};

			var nitCoin = new NitCoin
			{
				Responsavel = this,
				Voucher = voucher,
				Quantidade = -quantidade,
				Registro = dataHoraSolicitacao,
				Descricao = $"Resgate Voucher de {fidelidade.Descricao}",
			};

			NitCoins.Add(nitCoin);

			var novoSaldoAtual = ObterSaldo();
			if (novoSaldoAtual <= 0)
				throw new NitCoinException($"Você não tem saldo suficiente para gerar este Voucher de {fidelidade.Descricao}");

			return voucher;
		}
	}
}