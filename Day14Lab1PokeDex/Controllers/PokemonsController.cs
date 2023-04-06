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
    public class PokemonsController : Controller
    {
        private readonly DataContext _context;

        public PokemonsController(DataContext context)
        {
            _context = context;

            if (_context.Pokemons.Count()==0) {
                var json = JsonObject.Parse(System.IO.File.ReadAllText("pokemon.json"));
                var htp = new HttpClient();
                foreach(var pok in json.AsArray()) {
                    Pokemon p = new Pokemon() {
                        //PokemonID = Int32.Parse(pok!["ID"].AsValue().ToString()),
                        PokemonName= pok!["Name"].AsValue().ToString(),
                        PokemonAttack = Int32.Parse(pok!["BaseAttack"].AsValue().ToString()),
                        PokemonDefense= Int32.Parse(pok!["BaseDefense"].AsValue().ToString()),
                    };
                    //
                    var res= htp.GetAsync(pok["ImgUrl"].AsValue().ToString()).Result;
                    if(res.IsSuccessStatusCode) {
                        byte[] img = res.Content.ReadAsByteArrayAsync().Result;
                        Picture pic = new Picture() {
                            PictureName = p.PokemonName,
                            RawData = img
                        };
                    _context.Pictures.Add(pic);
                        p.Picture = pic;
                    }

                    _context.Pokemons.Add(p);   
                }
                _context.SaveChanges();
            }
        }

        // GET: Pokemons
        public async Task<IActionResult> Index(int page=1, int size=50)
        {
            int max = _context.Pokemons.Count() / size;
            ViewData["TotPages"] = max;
            ViewData["Size"] = size;
            page = (page < 1) ? 1 : page;
            page = (page > max) ? max : page;
            ViewData["Page"] = page;
            return _context.Pokemons != null ? 
                          View(await _context.Pokemons
                                .Include(p=>p.Picture)
                                .Skip(size*(page-1))
                                .Take(size)
                                .ToListAsync()) :
                          Problem("Entity set 'DataContext.Pokemons'  is null.");
        }

        // GET: Pokemons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pokemons == null)
            {
                return NotFound();
            }

            var pokemon = await _context.Pokemons
                .FirstOrDefaultAsync(m => m.PokemonID == id);
            if (pokemon == null)
            {
                return NotFound();
            }

            return View(pokemon);
        }

        // GET: Pokemons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pokemons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PokemonID,PokemonName,PokemonWeight,PokemonLevel,PokemonXP,PokemonAttack,PokemonDefense,PokemonSpecialAttack,PokemonSpecialDefense,PokemonSpeeed,PokemonLifePoints,PokemonStatus,IsMale,IsFemale,IsLegendary,IsEgg")] Pokemon pokemon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pokemon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pokemon);
        }

        // GET: Pokemons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pokemons == null)
            {
                return NotFound();
            }

            var pokemon = await _context.Pokemons.FindAsync(id);
            if (pokemon == null)
            {
                return NotFound();
            }
            return View(pokemon);
        }

        // POST: Pokemons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PokemonID,PokemonName,PokemonWeight,PokemonLevel,PokemonXP,PokemonAttack,PokemonDefense,PokemonSpecialAttack,PokemonSpecialDefense,PokemonSpeeed,PokemonLifePoints,PokemonStatus,IsMale,IsFemale,IsLegendary,IsEgg")] Pokemon pokemon)
        {
            if (id != pokemon.PokemonID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pokemon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PokemonExists(pokemon.PokemonID))
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
            return View(pokemon);
        }

        // GET: Pokemons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pokemons == null)
            {
                return NotFound();
            }

            var pokemon = await _context.Pokemons
                .FirstOrDefaultAsync(m => m.PokemonID == id);
            if (pokemon == null)
            {
                return NotFound();
            }

            return View(pokemon);
        }

        // POST: Pokemons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pokemons == null)
            {
                return Problem("Entity set 'DataContext.Pokemons'  is null.");
            }
            var pokemon = await _context.Pokemons.FindAsync(id);
            if (pokemon != null)
            {
                _context.Pokemons.Remove(pokemon);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PokemonExists(int id)
        {
          return (_context.Pokemons?.Any(e => e.PokemonID == id)).GetValueOrDefault();
        }
    }
}
