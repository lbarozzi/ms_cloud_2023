using Day9Lab1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Day9Lab1.Controllers {
    public class KillerController : Controller {
        protected readonly SerialKillers _killers;
        public KillerController(SerialKillers killers) {
            _killers = killers;

        }
        public IActionResult Index() {
            return View();
        }
        [HttpPost]
        public IActionResult ListKillers(string killername) {
            return View(_killers.GetKillersFromString(killername)); 
        }
    }
}
