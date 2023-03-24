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
    public class TemperaturesController : Controller
    {
        private readonly DataContext _context;

        public TemperaturesController(DataContext context)
        {
            _context = context;
        }

        // GET: Temperatures
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Temperatures.Include(t => t.Zene);
            return View(await dataContext.ToListAsync());
        }

        // GET: Temperatures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Temperatures == null)
            {
                return NotFound();
            }

            var temperature = await _context.Temperatures
                .Include(t => t.Zene)
                .FirstOrDefaultAsync(m => m.TemperatureID == id);
            if (temperature == null)
            {
                return NotFound();
            }

            return View(temperature);
        }

        // GET: Temperatures/Create
        public IActionResult Create()
        {
            ViewData["ZoneId"] = new SelectList(_context.Zones, "ZoneID", "ZoneID");
            return View();
        }

        // POST: Temperatures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TemperatureID,TemperatureDate,TemperatureValue,ZoneId")] Temperature temperature)
        {
            if (ModelState.IsValid)
            {
                _context.Add(temperature);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ZoneId"] = new SelectList(_context.Zones, "ZoneID", "ZoneID", temperature.ZoneId);
            return View(temperature);
        }

        // GET: Temperatures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Temperatures == null)
            {
                return NotFound();
            }

            var temperature = await _context.Temperatures.FindAsync(id);
            if (temperature == null)
            {
                return NotFound();
            }
            ViewData["ZoneId"] = new SelectList(_context.Zones, "ZoneID", "ZoneID", temperature.ZoneId);
            return View(temperature);
        }

        // POST: Temperatures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TemperatureID,TemperatureDate,TemperatureValue,ZoneId")] Temperature temperature)
        {
            if (id != temperature.TemperatureID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(temperature);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TemperatureExists(temperature.TemperatureID))
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
            ViewData["ZoneId"] = new SelectList(_context.Zones, "ZoneID", "ZoneID", temperature.ZoneId);
            return View(temperature);
        }

        // GET: Temperatures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Temperatures == null)
            {
                return NotFound();
            }

            var temperature = await _context.Temperatures
                .Include(t => t.Zene)
                .FirstOrDefaultAsync(m => m.TemperatureID == id);
            if (temperature == null)
            {
                return NotFound();
            }

            return View(temperature);
        }

        // POST: Temperatures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Temperatures == null)
            {
                return Problem("Entity set 'DataContext.Temperatures'  is null.");
            }
            var temperature = await _context.Temperatures.FindAsync(id);
            if (temperature != null)
            {
                _context.Temperatures.Remove(temperature);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TemperatureExists(int id)
        {
          return (_context.Temperatures?.Any(e => e.TemperatureID == id)).GetValueOrDefault();
        }
    }
}
