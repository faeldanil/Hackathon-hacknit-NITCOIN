using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScoreClass.Web.Data;
using ScoreClass.Web.Models.Cadastros;
using System.Linq;

namespace ScoreClass.Web.Controllers
{
	public class AlunoController : Controller
	{
		private readonly Repositorio _context = Repositorio.Ativo;

		public AlunoController(ApplicationDbContext context) { }

		// GET: Aluno
		public IActionResult Index()
		{
			return View(_context.Aluno.ToList());
		}

		// GET: Aluno/Details/5
		public IActionResult Details(long? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var aluno = _context.Aluno
				.SingleOrDefault(m => m.Id == id);
			if (aluno == null)
			{
				return NotFound();
			}

			return View(aluno);
		}

		// GET: Aluno/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Aluno/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create([Bind("Id,Nome,Telefone")] Aluno aluno)
		{
			if (ModelState.IsValid)
			{
				_context.Add(aluno);
				_context.SaveChanges();
				return RedirectToAction(nameof(Index));
			}
			return View(aluno);
		}

		// GET: Aluno/Edit/5
		public IActionResult Edit(long? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var aluno = _context.Aluno.SingleOrDefault(m => m.Id == id);
			if (aluno == null)
			{
				return NotFound();
			}
			return View(aluno);
		}

		// POST: Aluno/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(long id, [Bind("Id,Nome,Telefone")] Aluno aluno)
		{
			if (id != aluno.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(aluno);
					_context.SaveChanges();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!AlunoExists(aluno.Id))
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
			return View(aluno);
		}

		// GET: Aluno/Delete/5
		public IActionResult Delete(long? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var aluno = _context.Aluno
				.SingleOrDefault(m => m.Id == id);
			if (aluno == null)
			{
				return NotFound();
			}

			return View(aluno);
		}

		// POST: Aluno/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteConfirmed(long id)
		{
			var aluno = _context.Aluno.SingleOrDefault(m => m.Id == id);
			_context.Remove(aluno);
			_context.SaveChanges();
			return RedirectToAction(nameof(Index));
		}

		private bool AlunoExists(long id)
		{
			return _context.Aluno.Any(e => e.Id == id);
		}
	}
}
