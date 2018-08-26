using Microsoft.AspNetCore.Mvc;
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
			var parceria = _context?.Parceria?.FirstOrDefault(p => p.Id == id);
			return View(parceria?.Programas?.Where(p => p.Ativo));
		}

		public IActionResult Resgatar(int id)
		{
			var parceria = _context?.Parceria?.FirstOrDefault(p => p.Id == id);
			var fidelidade = parceria.Programas.FirstOrDefault(p => p.Id == id);
			return View(fidelidade);
		}
	}
}