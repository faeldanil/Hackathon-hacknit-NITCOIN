using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScoreClass.Web.Data;
using ScoreClass.Web.Models.Cadastros;
using System.Linq;

namespace ScoreClass.Web.Controllers
{
	public class OcorrenciasController : BaseController
	{

		public OcorrenciasController(ApplicationDbContext context)
		{
		}

		// GET: Ocorrencias
		public IActionResult Index()
		{
			return View(repositorio.Ocorrencia.ToList());
		}

		// GET: Ocorrencias/Details/5
		public IActionResult Details(long? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var ocorrencia = repositorio.Ocorrencia
				.SingleOrDefault(m => m.Id == id);
			if (ocorrencia == null)
			{
				return NotFound();
			}

			return View(ocorrencia);
		}

		// GET: Ocorrencias/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Ocorrencias/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create([Bind("Id,DataHora,Descricao,TipoComportamento")] Ocorrencia ocorrencia)
		{
			if (ModelState.IsValid)
			{
				repositorio.Add(ocorrencia);
				repositorio.SaveChanges();
				return RedirectToAction(nameof(Index));
			}
			return View(ocorrencia);
		}

		// GET: Ocorrencias/Edit/5
		public IActionResult Edit(long? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var ocorrencia = repositorio.Ocorrencia.SingleOrDefault(m => m.Id == id);
			if (ocorrencia == null)
			{
				return NotFound();
			}
			return View(ocorrencia);
		}

		// POST: Ocorrencias/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(long id, [Bind("Id,DataHora,Descricao,TipoComportamento")] Ocorrencia ocorrencia)
		{
			if (id != ocorrencia.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					repositorio.Update(ocorrencia);
					repositorio.SaveChanges();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!OcorrenciaExists(ocorrencia.Id))
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
			return View(ocorrencia);
		}

		// GET: Ocorrencias/Delete/5
		public IActionResult Delete(long? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var ocorrencia = repositorio.Ocorrencia
				.SingleOrDefault(m => m.Id == id);
			if (ocorrencia == null)
			{
				return NotFound();
			}

			return View(ocorrencia);
		}

		// POST: Ocorrencias/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteConfirmed(long id)
		{
			var ocorrencia = repositorio.Ocorrencia.SingleOrDefault(m => m.Id == id);
			repositorio.Remove(ocorrencia);
			repositorio.SaveChanges();
			return RedirectToAction(nameof(Index));
		}

		private bool OcorrenciaExists(long id)
		{
			return repositorio.Ocorrencia.Any(e => e.Id == id);
		}
	}
}
