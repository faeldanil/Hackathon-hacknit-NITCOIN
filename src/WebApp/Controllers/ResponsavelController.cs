﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScoreClass.Web.Data;
using ScoreClass.Web.Models.Cadastros;
using System.Linq;

namespace ScoreClass.Web.Controllers
{
	public class ResponsavelController : BaseController
	{
		public ResponsavelController(ApplicationDbContext context)
		{
		}

		// GET: Responsavel
		public IActionResult Index()
		{
			return View(repositorio.Responsavel.ToList());
		}

		// GET: Responsavel/Details/5
		public IActionResult Details(long? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var responsavel = repositorio.Responsavel
				.SingleOrDefault(m => m.Id == id);
			if (responsavel == null)
			{
				return NotFound();
			}

			return View(responsavel);
		}

		// GET: Responsavel/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Responsavel/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create([Bind("Id,Nome,Telefone,Cpf")] Responsavel responsavel)
		{
			if (ModelState.IsValid)
			{
				repositorio.Add(responsavel);
				repositorio.SaveChanges();
				return RedirectToAction(nameof(Index));
			}
			return View(responsavel);
		}

		// GET: Responsavel/Edit/5
		public IActionResult Edit(long? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var responsavel = repositorio.Responsavel.SingleOrDefault(m => m.Id == id);
			if (responsavel == null)
			{
				return NotFound();
			}
			return View(responsavel);
		}

		// POST: Responsavel/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(long id, [Bind("Id,Nome,Telefone,Cpf")] Responsavel responsavel)
		{
			if (id != responsavel.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					repositorio.Update(responsavel);
					repositorio.SaveChanges();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!ResponsavelExists(responsavel.Id))
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
			return View(responsavel);
		}

		// GET: Responsavel/Delete/5
		public IActionResult Delete(long? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var responsavel = repositorio.Responsavel
				.SingleOrDefault(m => m.Id == id);
			if (responsavel == null)
			{
				return NotFound();
			}

			return View(responsavel);
		}

		// POST: Responsavel/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteConfirmed(long id)
		{
			var responsavel = repositorio.Responsavel.SingleOrDefault(m => m.Id == id);
			repositorio.Remove(responsavel);
			repositorio.SaveChanges();
			return RedirectToAction(nameof(Index));
		}

		private bool ResponsavelExists(long id)
		{
			return repositorio.Responsavel.Any(e => e.Id == id);
		}
	}
}
