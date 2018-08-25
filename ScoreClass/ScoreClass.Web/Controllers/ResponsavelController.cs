using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ScoreClass.Web.Data;
using ScoreClass.Web.Models.Cadastros;

namespace ScoreClass.Web.Controllers
{
    public class ResponsavelController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ResponsavelController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Responsavel
        public async Task<IActionResult> Index()
        {
            return View(await _context.Responsavel.ToListAsync());
        }

        // GET: Responsavel/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var responsavel = await _context.Responsavel
                .SingleOrDefaultAsync(m => m.Id == id);
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
        public async Task<IActionResult> Create([Bind("Id,Nome,Telefone,Cpf")] Responsavel responsavel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(responsavel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(responsavel);
        }

        // GET: Responsavel/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var responsavel = await _context.Responsavel.SingleOrDefaultAsync(m => m.Id == id);
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
        public async Task<IActionResult> Edit(long id, [Bind("Id,Nome,Telefone,Cpf")] Responsavel responsavel)
        {
            if (id != responsavel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(responsavel);
                    await _context.SaveChangesAsync();
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
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var responsavel = await _context.Responsavel
                .SingleOrDefaultAsync(m => m.Id == id);
            if (responsavel == null)
            {
                return NotFound();
            }

            return View(responsavel);
        }

        // POST: Responsavel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var responsavel = await _context.Responsavel.SingleOrDefaultAsync(m => m.Id == id);
            _context.Responsavel.Remove(responsavel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResponsavelExists(long id)
        {
            return _context.Responsavel.Any(e => e.Id == id);
        }
    }
}
