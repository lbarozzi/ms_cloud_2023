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
    public class TaxisController : Controller
    {
        private readonly DataContext _context;

        public TaxisController(DataContext context)
        {
            _context = context;
            //
            if (_context.Taxis.Count()==0) {
                //Some random
                for(int i=0;i<10;i++) {
                    _context.Taxis.Add(new Taxi() { 
                        Plate=$"EB{i}FG"
                    });
                }
                _context.SaveChanges();
            }
        }

        // GET: Taxis
        public async Task<IActionResult> Index()
        {
              return _context.Taxis != null ? 
                          View(await _context.Taxis.ToListAsync()) :
                          Problem("Entity set 'DataContext.Taxis'  is null.");
        }

        // GET: Taxis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Taxis == null)
            {
                return NotFound();
            }

            var taxi = await _context.Taxis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taxi == null)
            {
                return NotFound();
            }

            return View(taxi);
        }

        // GET: Taxis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Taxis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Plate")] Taxi taxi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taxi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(taxi);
        }

        // GET: Taxis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Taxis == null)
            {
                return NotFound();
            }

            var taxi = await _context.Taxis.FindAsync(id);
            if (taxi == null)
            {
                return NotFound();
            }
            return View(taxi);
        }

        // POST: Taxis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Plate")] Taxi taxi)
        {
            if (id != taxi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taxi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaxiExists(taxi.Id))
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
            return View(taxi);
        }

        // GET: Taxis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Taxis == null)
            {
                return NotFound();
            }

            var taxi = await _context.Taxis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taxi == null)
            {
                return NotFound();
            }

            return View(taxi);
        }

        // POST: Taxis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Taxis == null)
            {
                return Problem("Entity set 'DataContext.Taxis'  is null.");
            }
            var taxi = await _context.Taxis.FindAsync(id);
            if (taxi != null)
            {
                _context.Taxis.Remove(taxi);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaxiExists(int id)
        {
          return (_context.Taxis?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
