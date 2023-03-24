using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Day13Lab1.Models;

namespace Day13Lab1.Controllers
{
    public class AnagraphicsController : Controller
    {
        private readonly MyDbContext _context;

        public AnagraphicsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Anagraphics
        public async Task<IActionResult> Index()
        {
              return _context.Anagraphics != null ? 
                          View(await _context.Anagraphics.ToListAsync()) :
                          Problem("Entity set 'MyDbContext.Anagraphics'  is null.");
        }

        // GET: Anagraphics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Anagraphics == null)
            {
                return NotFound();
            }

            var anagraphic = await _context.Anagraphics
                .FirstOrDefaultAsync(m => m.AnagraphicID == id);
            if (anagraphic == null)
            {
                return NotFound();
            }

            return View(anagraphic);
        }

        // GET: Anagraphics/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Anagraphics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AnagraphicID,CompanyName,VAT")] Anagraphic anagraphic)
        {
            if (ModelState.IsValid)
            {
                _context.Add(anagraphic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(anagraphic);
        }

        // GET: Anagraphics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Anagraphics == null)
            {
                return NotFound();
            }

            var anagraphic = await _context.Anagraphics.FindAsync(id);
            if (anagraphic == null)
            {
                return NotFound();
            }
            return View(anagraphic);
        }

        // POST: Anagraphics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AnagraphicID,CompanyName,VAT")] Anagraphic anagraphic)
        {
            if (id != anagraphic.AnagraphicID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anagraphic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnagraphicExists(anagraphic.AnagraphicID))
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
            return View(anagraphic);
        }

        // GET: Anagraphics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Anagraphics == null)
            {
                return NotFound();
            }

            var anagraphic = await _context.Anagraphics
                .FirstOrDefaultAsync(m => m.AnagraphicID == id);
            if (anagraphic == null)
            {
                return NotFound();
            }

            return View(anagraphic);
        }

        // POST: Anagraphics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Anagraphics == null)
            {
                return Problem("Entity set 'MyDbContext.Anagraphics'  is null.");
            }
            var anagraphic = await _context.Anagraphics.FindAsync(id);
            if (anagraphic != null)
            {
                _context.Anagraphics.Remove(anagraphic);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnagraphicExists(int id)
        {
          return (_context.Anagraphics?.Any(e => e.AnagraphicID == id)).GetValueOrDefault();
        }
    }
}
