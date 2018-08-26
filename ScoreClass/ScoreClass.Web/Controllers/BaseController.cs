using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ScoreClass.Web.Data;
using System.Linq;

namespace ScoreClass.Web.Controllers
{
	public class BaseController : Controller
	{
		protected readonly Repositorio _context = Repositorio.Ativo;

		public override void OnActionExecuted(ActionExecutedContext context)
		{
			base.OnActionExecuted(context);
			AtualizarSaldoNitCoins();
		}

		protected void AtualizarSaldoNitCoins()
		{
			var matricula = _context?.Matricula?.FirstOrDefault(x => x?.Aluno?.Responsavel?.Email?.Descricao == User?.Identity?.Name);
			var saldo = (matricula?.Aluno?.Responsavel?.ObterSaldo() ?? 0);
			ViewData["NitCoins"] = saldo + " NITCOIN";
		}
	}
}