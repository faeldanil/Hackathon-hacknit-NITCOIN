using ScoreClass.Web.Models.Incentivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreClass.Web.Models.Cadastros
{
    public class Responsavel
    {
        public long Id { get;  set; }
        public string Nome { get;  set; }
        public Email Email { get;  set; }
        public string Telefone { get;  set; }
		public List<NitCoin> NitCoins { get; set; } = new List<NitCoin>();


		public void RegistrarAtividade(TipoAtividade tipoAtividade)
		{
			var politicaIncentivo = PoliticasIncentivo.Instance.Value.ObterAtivo(DateTime.Today);
			var quantidade = politicaIncentivo.ObterQuantidade(tipoAtividade);

			var nitCoin = new NitCoin { Responsavel = this, Quantidade = quantidade, Descricao = tipoAtividade.ToString(), Registro = DateTime.Now };

			NitCoins.Add(nitCoin);
		}
	}
}
