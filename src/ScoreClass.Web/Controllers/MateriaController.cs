using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScoreClass.Web.Data;
using ScoreClass.Web.Models.Cadastros;
using System.Linq;

namespace ScoreClass.Web.Controllers
{
	public class MateriaController : BaseController
	{
		public MateriaController(ApplicationDbContext context)
		{
		}

		// GET: Materia
		public IActionResult Index()
		{
			return View(repositorio.Materia.ToList());
		}

		// GET: Materia/Details/5
		public IActionResult Details(long? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var materia = repositorio.Materia
				.SingleOrDefault(m => m.Id == id);
			if (materia == null)
			{
				return NotFound();
			}

			return View(materia);
		}

		// GET: Materia/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Materia/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create([Bind("Id,Nome")] Materia materia)
		{
			if (ModelState.IsValid)
			{
				repositorio.Add(materia);
				repositorio.SaveChanges();
				return RedirectToAction(nameof(Index));
			}
			return View(materia);
		}

		// GET: Materia/Edit/5
		public IActionResult Edit(long? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var materia = repositorio.Materia.SingleOrDefault(m => m.Id == id);
			if (materia == null)
			{
				return NotFound();
			}
			return View(materia);
		}

		// POST: Materia/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(long id, [Bind("Id,Nome")] Materia materia)
		{
			if (id != materia.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					repositorio.Update(materia);
					repositorio.SaveChanges();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!MateriaExists(materia.Id))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}
			return View(materia);
		}

		// GET: Materia/Delete/5
		public IActionResult Delete(long? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var materia = repositorio.Materia
				.SingleOrDefault(m => m.Id == id);
			if (materia == null)
			{
				return NotFound();
			}

			return View(materia);
		}

		// POST: Materia/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteConfirmed(long id)
		{
			var materia = repositorio.Materia.SingleOrDefault(m => m.Id == id);
			repositorio.Remove(materia);
			repositorio.SaveChanges();
			return RedirectToAction(nameof(Index));
		}

		private bool MateriaExists(long id)
		{
			return repositorio.Materia.Any(e => e.Id == id);
		}
	}
}
