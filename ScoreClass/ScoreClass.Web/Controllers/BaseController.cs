using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ScoreClass.Web.Data;
using ScoreClass.Web.Models.Cadastros;
using System.Linq;

namespace ScoreClass.Web.Controllers
{
	public class BaseController : Controller
	{
		protected readonly Repositorio repositorio = Repositorio.Ativo;

		public override void OnActionExecuted(ActionExecutedContext context)
		{
			base.OnActionExecuted(context);
			AtualizarSaldoNitCoins();
		}

		protected void AtualizarSaldoNitCoins()
		{
			var saldo = (ResponsavelLogado?.ObterSaldo() ?? 0);
			ViewData["NitCoins"] = saldo + " NITCOIN";
		}

		protected Responsavel ResponsavelLogado
		{
			get => repositorio?.Responsavel?.FirstOrDefault(r => r.Email.Descricao == User?.Identity?.Name);
		}
	}
}