using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScoreClass.Web.Data;
using System.Linq;

namespace ScoreClass.Web.Controllers
{
	public class PainelPaisController : Controller
    {
		private readonly Repositorio _context = Repositorio.Ativo;

		public PainelPaisController(ApplicationDbContext context)
        {
        }

        public ActionResult Index()
        {
            var matricula = _context.Matricula.First(x => x.Aluno.Reponsavel.Email.Descricao == User?.Identity?.Name);
            return View(matricula);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: PainelPais/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PainelPais/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PainelPais/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PainelPais/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PainelPais/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}