using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPiKiller.Models;

namespace WebAPiKiller.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class KillerController : ControllerBase {
        private readonly DataContext _context;
        public KillerController(DataContext context) {
            _context = context;
            //Check killers
        }

        [HttpGet("PopolaDB")]
        public ActionResult<List<Killer>> PopolaDB() {
            string[] dati = System.IO.File.ReadAllLines("names.txt");
            Random _generator = new Random();
            //Pulisco
            _context.Killers.RemoveRange(_context.Killers);
            _context.SaveChanges();
            //
            foreach (string nome in dati) {
                Killer k = new Killer() {
                    KillerName= nome,   
                    KillerDescription= $"Sono il killer {nome}",
                    KillerKilled= _generator.Next(10000),
                    IsInJail= _generator.NextInt64()%2==0,
                };
                _context.Killers.Add(k);
            }
            //Update real DATABASE
            /* Query syntax
            var lista = (from k in _context.Killers
                         select k).Take(10).ToList();
            //*/
            _context.SaveChanges();
            return Ok(_context.Killers
                        .Take(10)
                        .ToList()
            );
        }

        [HttpGet]
        public ActionResult<List<Killer>> Index() {
            var killerlist = _context.Killers
                            .Take(50)
                            .ToList(); 

            return Ok(killerlist);
        }
    }
}
