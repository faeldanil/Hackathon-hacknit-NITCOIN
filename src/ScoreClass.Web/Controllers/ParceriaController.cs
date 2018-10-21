using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScoreClass.Web.Extensions;
using System;
using System.Linq;

namespace ScoreClass.Web.Controllers
{
	public class ParceriaController : BaseController
	{
		public IActionResult Index()
		{
			return View(repositorio?.Parceria);
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
		public IActionResult ResgatarBeneficio(IFormCollection formCollection)
		{
			var parceriaId = Convert.ToInt64(formCollection["parceriaId"]);
			var fidelidadeId = Convert.ToInt64(formCollection["fidelidadeId"]);
			var voucherId = Convert.ToInt64(formCollection["voucherId"]);
			var codigoVoucher = Convert.ToString(formCollection["codigoVoucher"]);

			var parceria = repositorio?.Parceria?.FirstOrDefault(p => p.Id == parceriaId);
			var fidelidade = parceria.Programas.FirstOrDefault(p => p.Id == fidelidadeId);
			var voucher = repositorio.Voucher.FirstOrDefault(v => v.Codigo == codigoVoucher);

			if ((voucher.Id != voucherId) || (voucher.Codigo != codigoVoucher) || (voucher.Fidelidade.Id != fidelidadeId) || (voucher.Fidelidade.Parceria.Id != parceriaId) || voucher.Resgatado.HasValue)
				throw new Exception("Voucher Inválido");

			voucher.Resgatado = DateTime.Now;

			return View("Voucher", voucher);
		}

		[HttpPost]
		public IActionResult Resgatar(IFormCollection formCollection)
		{
			var parceriaId = Convert.ToInt64(formCollection["parceriaId"]);
			var fidelidadeId = Convert.ToInt64(formCollection["fidelidadeId"]);
			try
			{
				var parceria = repositorio?.Parceria?.FirstOrDefault(p => p.Id == parceriaId);
				var fidelidade = parceria.Programas.FirstOrDefault(p => p.Id == fidelidadeId);
				var voucher = ResponsavelLogado.GerarVoucher(fidelidade);
				repositorio.Add(voucher.NitCoin);
				repositorio.Add(voucher);
				return View("Voucher", voucher);
			}
			catch (Exception)
			{
				return this.RedirectToAction("Resgatar", "Parceria", new { parceriaId, fidelidadeId });
			}
		}

		public IActionResult Voucher(int id)
		{
			var voucher = ResponsavelLogado.Vouchers.FirstOrDefault(v => v.Id == id);
			return View(voucher);
		}

		[Route("[controller]/[action]/{codigo}")]
		public IActionResult Validar(String codigo)
		{
			var voucher = repositorio.Voucher.FirstOrDefault(v => v.Codigo == codigo);
			if (voucher == null)
				ViewData["Status"] = $"Este Voucher ({codigo}) não existe";
			else if (voucher.Resgatado.HasValue)
				ViewData["Status"] = $"Este Voucher ({codigo}) já foi resgatado";

			return View(voucher);
		}
	}
}