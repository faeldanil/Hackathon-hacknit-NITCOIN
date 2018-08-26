using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScoreClass.Web.Data;
using ScoreClass.Web.Models.Cadastros;
using System.Linq;

namespace ScoreClass.Web.Controllers
{
	public class MatriculasController : BaseController
	{
		public MatriculasController(ApplicationDbContext context)
		{
		}

		// GET: Matriculas
		public IActionResult Index()
		{
			return View(_context.Matricula.ToList());
		}

		// GET: Matriculas/Details/5
		public IActionResult Details(long? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var matricula = _context.Matricula
				.SingleOrDefault(m => m.Id == id);
			if (matricula == null)
			{
				return NotFound();
			}

			return View(matricula);
		}

		// GET: Matriculas/Create
		public IActionResult Create()
		{
			ViewData["Codigo"] = new Matricula().GerarCodigo;
			return View();
		}

		// POST: Matriculas/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create([Bind("Id,Codigo")] Matricula matricula)
		{
			if (ModelState.IsValid)
			{
				_context.Add(matricula);
				_context.SaveChanges();
				return RedirectToAction(nameof(Index));
			}
			return View(matricula);
		}

		// GET: Matriculas/Edit/5
		public IActionResult Edit(long? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var matricula = _context.Matricula.SingleOrDefault(m => m.Id == id);
			if (matricula == null)
			{
				return NotFound();
			}
			return View(matricula);
		}

		// POST: Matriculas/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(long id, [Bind("Id,Codigo")] Matricula matricula)
		{
			if (id != matricula.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(matricula);
					_context.SaveChanges();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!MatriculaExists(matricula.Id))
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
			return View(matricula);
		}

		// GET: Matriculas/Delete/5
		public IActionResult Delete(long? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var matricula = _context.Matricula
				.SingleOrDefault(m => m.Id == id);
			if (matricula == null)
			{
				return NotFound();
			}

			return View(matricula);
		}

		// POST: Matriculas/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteConfirmed(long id)
		{
			var matricula = _context.Matricula.SingleOrDefault(m => m.Id == id);
			_context.Remove(matricula);
			_context.SaveChanges();
			return RedirectToAction(nameof(Index));
		}

		private bool MatriculaExists(long id)
		{
			return _context.Matricula.Any(e => e.Id == id);
		}
	}
}
