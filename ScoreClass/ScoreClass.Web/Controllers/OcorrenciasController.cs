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
    public class OcorrenciasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OcorrenciasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ocorrencias
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ocorrencia.ToListAsync());
        }

        // GET: Ocorrencias/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ocorrencia = await _context.Ocorrencia
                .SingleOrDefaultAsync(m => m.Id == id);
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
        public async Task<IActionResult> Create([Bind("Id,DataHora,Descricao,TipoComportamento")] Ocorrencia ocorrencia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ocorrencia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ocorrencia);
        }

        // GET: Ocorrencias/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ocorrencia = await _context.Ocorrencia.SingleOrDefaultAsync(m => m.Id == id);
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
        public async Task<IActionResult> Edit(long id, [Bind("Id,DataHora,Descricao,TipoComportamento")] Ocorrencia ocorrencia)
        {
            if (id != ocorrencia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ocorrencia);
                    await _context.SaveChangesAsync();
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
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ocorrencia = await _context.Ocorrencia
                .SingleOrDefaultAsync(m => m.Id == id);
            if (ocorrencia == null)
            {
                return NotFound();
            }

            return View(ocorrencia);
        }

        // POST: Ocorrencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var ocorrencia = await _context.Ocorrencia.SingleOrDefaultAsync(m => m.Id == id);
            _context.Ocorrencia.Remove(ocorrencia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OcorrenciaExists(long id)
        {
            return _context.Ocorrencia.Any(e => e.Id == id);
        }
    }
}
