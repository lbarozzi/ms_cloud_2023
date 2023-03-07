using Microsoft.AspNetCore.Mvc;

namespace Day8Lab1.Controllers {
    public class CalcController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
