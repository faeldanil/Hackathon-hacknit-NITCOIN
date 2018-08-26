using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScoreClass.Web.Data;
using ScoreClass.Web.Models.Cadastros;
using System.Linq;

namespace ScoreClass.Web.Controllers
{
	public class EscolaController : BaseController
	{
		public EscolaController(ApplicationDbContext context)
        {
        }

        // GET: Escola
        public  IActionResult Index()
        {
            return View( repositorio.Escola.ToList());
        }

        // GET: Escola/Details/5
        public  IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escola =  repositorio.Escola
                .SingleOrDefault(m => m.Id == id);
            if (escola == null)
            {
                return NotFound();
            }

            return View(escola);
        }

        // GET: Escola/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Escola/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Create([Bind("Id,Nome")] Escola escola)
        {
            if (ModelState.IsValid)
            {
                repositorio.Add(escola);
                 repositorio.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(escola);
        }

        // GET: Escola/Edit/5
        public  IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escola =  repositorio.Escola.SingleOrDefault(m => m.Id == id);
            if (escola == null)
            {
                return NotFound();
            }
            return View(escola);
        }

        // POST: Escola/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Edit(long id, [Bind("Id,Nome")] Escola escola)
        {
            if (id != escola.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    repositorio.Update(escola);
                     repositorio.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EscolaExists(escola.Id))
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
            return View(escola);
        }

        // GET: Escola/Delete/5
        public  IActionResult Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escola =  repositorio.Escola
                .SingleOrDefault(m => m.Id == id);
            if (escola == null)
            {
                return NotFound();
            }

            return View(escola);
        }

        // POST: Escola/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public  IActionResult DeleteConfirmed(long id)
        {
            var escola =  repositorio.Escola.SingleOrDefault(m => m.Id == id);
            repositorio.Remove(escola);
             repositorio.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool EscolaExists(long id)
        {
            return repositorio.Escola.Any(e => e.Id == id);
        }
    }
}
