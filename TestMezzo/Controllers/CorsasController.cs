using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestMezzo.Models;

namespace TestMezzo.Controllers
{
    public class CorsasController : Controller
    {
        private readonly DataContext _context;

        public CorsasController(DataContext context)
        {
            _context = context;
        }

        // GET: Corsas
        public async Task<IActionResult> Index()
        {
              return _context.Corse != null ? 
                          View(await _context.Corse
                          .Include(m=>m.Driver)
                          .ToListAsync()) :
                          Problem("Entity set 'DataContext.Corse'  is null.");
        }

        // GET: Corsas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Corse == null)
            {
                return NotFound();
            }

            var corsa = await _context.Corse
                .Include(m => m.Driver)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (corsa == null)
            {
                return NotFound();
            }

            return View(corsa);
        }

        // GET: Corsas/Create
        public IActionResult Create()
        {
            //Get Taxi
            var taxi = _context.Taxis
                .Include(m => m.Corse)
                .OrderBy(m => m.Corse.Count())
                .First();
            ViewData["Taxi"] = taxi;
            return View();
        }

        // POST: Corsas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int TaxiId,[Bind("Id,From,To")] Corsa corsa)
        {
            Taxi taxi = _context.Taxis.Find(TaxiId);
            corsa.Driver = taxi;
            if (true) //ModelState.IsValid)
            {
                
                _context.Add(corsa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(corsa);
        }

        // GET: Corsas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Corse == null)
            {
                return NotFound();
            }

            var corsa = await _context.Corse.FindAsync(id);
            if (corsa == null)
            {
                return NotFound();
            }
            return View(corsa);
        }

        // POST: Corsas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,From,To")] Corsa corsa)
        {
            if (id != corsa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(corsa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CorsaExists(corsa.Id))
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
            return View(corsa);
        }

        // GET: Corsas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Corse == null)
            {
                return NotFound();
            }

            var corsa = await _context.Corse
                .FirstOrDefaultAsync(m => m.Id == id);
            if (corsa == null)
            {
                return NotFound();
            }

            return View(corsa);
        }

        // POST: Corsas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Corse == null)
            {
                return Problem("Entity set 'DataContext.Corse'  is null.");
            }
            var corsa = await _context.Corse.FindAsync(id);
            if (corsa != null)
            {
                _context.Corse.Remove(corsa);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CorsaExists(int id)
        {
          return (_context.Corse?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
