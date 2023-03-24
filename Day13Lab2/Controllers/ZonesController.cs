using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Day13Lab2.Models;

namespace Day13Lab2.Controllers
{
    public class ZonesController : Controller
    {
        private readonly DataContext _context;

        public ZonesController(DataContext context)
        {
            _context = context;
            //Popola il DB
            if (_context.Zones.Count() == 0) {
                Random rnd = new Random();
                for (int i = 0; i < 15; i++) {
                    Zone new_zone = new Zone() {
                        Description = $"Zone {i}",
                        IsActive = true,
                        TargetTemperarure = rnd.Next(18, 22)
                    };
                    for (int t = 0; t < rnd.Next(2, 15); t++) {
                        new_zone.Temperatures.Add(
                            new Temperature() {
                                TemperatureDate = DateTime.Now,
                                TemperatureValue = rnd.Next(14, 30)
                            });
                    }
                    _context.Zones.Add(new_zone);
                }
                _context.SaveChanges();     //Memento
            }
        }


        // GET: Zones
        public async Task<IActionResult> Index()
        {
              return _context.Zones != null ? 
                          View(await _context.Zones
                                        .Include(x => x.Temperatures)
                                        .ToListAsync()) :
                          Problem("Entity set 'DataContext.Zones'  is null.");
        }

        // GET: Zones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Zones == null)
            {
                return NotFound();
            }

            var zone = await _context.Zones
                .FirstOrDefaultAsync(m => m.ZoneID == id);
            if (zone == null)
            {
                return NotFound();
            }

            return View(zone);
        }

        // GET: Zones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ZoneID,Description,IsActive,TargetTemperarure")] Zone zone)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zone);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zone);
        }

        // GET: Zones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Zones == null)
            {
                return NotFound();
            }

            var zone = await _context.Zones.FindAsync(id);
            if (zone == null)
            {
                return NotFound();
            }
            return View(zone);
        }

        // POST: Zones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ZoneID,Description,IsActive,TargetTemperarure")] Zone zone)
        {
            if (id != zone.ZoneID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zone);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZoneExists(zone.ZoneID))
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
            return View(zone);
        }

        // GET: Zones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Zones == null)
            {
                return NotFound();
            }

            var zone = await _context.Zones
                .FirstOrDefaultAsync(m => m.ZoneID == id);
            if (zone == null)
            {
                return NotFound();
            }

            return View(zone);
        }

        // POST: Zones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Zones == null)
            {
                return Problem("Entity set 'DataContext.Zones'  is null.");
            }
            var zone = await _context.Zones.FindAsync(id);
            if (zone != null)
            {
                _context.Zones.Remove(zone);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZoneExists(int id)
        {
          return (_context.Zones?.Any(e => e.ZoneID == id)).GetValueOrDefault();
        }
    }
}
