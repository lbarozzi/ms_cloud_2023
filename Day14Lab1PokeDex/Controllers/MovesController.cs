using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Day14Lab1PokeDex.Models;
using System.Text.Json.Nodes;

namespace Day14Lab1PokeDex.Controllers
{
    public class MovesController : Controller
    {
        private readonly DataContext _context;

        public MovesController(DataContext context)
        {
            _context = context;
            /*
               {
                    "ID": 0,
                    "Name": "Botta",
                    "Type": "Normale",
                    "Power": 40,
                    "Accuracy": 100,
                    "Category": "Fisico",
                    "PP": 35
               }
            //*/
            if (_context.Moves.Count() == 0) {
                var dbmosse = JsonObject.Parse(System.IO.File.ReadAllText("moves.json"));

                foreach (var mv in dbmosse.AsArray()) {
                    Element e = (from el in _context.Elements
                                where el.ElementName == mv["Type"].ToString()
                                select el).First();
                    _context.Moves.Add(new Move {
                        MoveName = mv!["Name"].ToString(),
                        MoveHitPoints = Int32.Parse(mv["Power"].ToString()),
                        MovePrecision = Int32.Parse(mv["Accuracy"].ToString()),
                        Element = e,
                        ElementID = e.ElementID,
                        MoveMaxRepeat = Int32.Parse(mv["PP"].ToString())
                    });
                }

                _context.SaveChanges();

            }
        }

        // GET: Moves
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Moves.Include(m => m.Element);
            return View(await dataContext.ToListAsync());
        }

        // GET: Moves/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Moves == null)
            {
                return NotFound();
            }

            var move = await _context.Moves
                .Include(m => m.Element)
                .FirstOrDefaultAsync(m => m.MoveID == id);
            if (move == null)
            {
                return NotFound();
            }

            return View(move);
        }

        // GET: Moves/Create
        public IActionResult Create()
        {
            ViewData["ElementID"] = new SelectList(_context.Elements, "ElementID", "ElementID");
            return View();
        }

        // POST: Moves/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MoveID,MoveClass,MoveName,IsAttack,MoveHitPoints,MoveSpeedUp,MoveAttackUp,MoveDefenseUp,MoveLifePointsUp,IsPriority,MovePrecision,MoveMaxRepeat,IsElementary,ElementID")] Move move)
        {
            if (ModelState.IsValid)
            {
                _context.Add(move);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ElementID"] = new SelectList(_context.Elements, "ElementID", "ElementID", move.ElementID);
            return View(move);
        }

        // GET: Moves/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Moves == null)
            {
                return NotFound();
            }

            var move = await _context.Moves.FindAsync(id);
            if (move == null)
            {
                return NotFound();
            }
            ViewData["ElementID"] = new SelectList(_context.Elements, "ElementID", "ElementID", move.ElementID);
            return View(move);
        }

        // POST: Moves/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MoveID,MoveClass,MoveName,IsAttack,MoveHitPoints,MoveSpeedUp,MoveAttackUp,MoveDefenseUp,MoveLifePointsUp,IsPriority,MovePrecision,MoveMaxRepeat,IsElementary,ElementID")] Move move)
        {
            if (id != move.MoveID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(move);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MoveExists(move.MoveID))
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
            ViewData["ElementID"] = new SelectList(_context.Elements, "ElementID", "ElementID", move.ElementID);
            return View(move);
        }

        // GET: Moves/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Moves == null)
            {
                return NotFound();
            }

            var move = await _context.Moves
                .Include(m => m.Element)
                .FirstOrDefaultAsync(m => m.MoveID == id);
            if (move == null)
            {
                return NotFound();
            }

            return View(move);
        }

        // POST: Moves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Moves == null)
            {
                return Problem("Entity set 'DataContext.Moves'  is null.");
            }
            var move = await _context.Moves.FindAsync(id);
            if (move != null)
            {
                _context.Moves.Remove(move);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MoveExists(int id)
        {
          return (_context.Moves?.Any(e => e.MoveID == id)).GetValueOrDefault();
        }
    }
}
