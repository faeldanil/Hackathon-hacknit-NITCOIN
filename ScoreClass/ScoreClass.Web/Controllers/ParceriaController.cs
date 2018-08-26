using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace ScoreClass.Web.Controllers
{
	public class ParceriaController : BaseController
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Fidelidade(int id)
		{
			var parceria = repositorio?.Parceria?.FirstOrDefault(p => p.Id == id);
			return View(parceria?.Programas?.Where(p => p.Ativo));
		}

		[Route("[controller]/[action]/{parceriaId}/{fidelidadeId}")]
		public IActionResult Resgatar(int parceriaId, int fidelidadeId)
		{
			var parceria = repositorio?.Parceria?.FirstOrDefault(p => p.Id == parceriaId);
			var fidelidade = parceria.Programas.FirstOrDefault(p => p.Id == fidelidadeId);
			return View(fidelidade);
		}

		[HttpPost]
		public IActionResult Resgatar(FormCollection formCollection)
		{
			var parceriaId = Convert.ToInt64(formCollection["parceriaId"]);
			var fidelidadeId = Convert.ToInt64(formCollection["fidelidadeId"]);
			var parceria = repositorio?.Parceria?.FirstOrDefault(p => p.Id == parceriaId);
			var fidelidade = parceria.Programas.FirstOrDefault(p => p.Id == fidelidadeId);
			var voucher = ResponsavelLogado.GerarVoucher(fidelidade);
			repositorio.Add(voucher);
			return View("Voucher", voucher);
		}
	}
}