using Microsoft.AspNetCore.Mvc;

namespace Day8Lab1.Controllers {
    public class CalcController : Controller {
        public IActionResult Index() {
            return View();
        }

        public IActionResult Sum(decimal a, decimal b) {
            ViewData["result"] = a + b;
            return View("Views/Calc/index.cshtml");
        }
        public IActionResult Sub(decimal a, decimal b) {
            ViewData["result"] = a - b;
            return View("Views/Calc/index.cshtml");
        }
        public IActionResult Mul(decimal a, decimal b) {
            ViewData["result"] = a * b;
            return View("Views/Calc/index.cshtml");
        }
        public IActionResult Div(decimal a, decimal b) {
            if(b!=0)
                ViewData["result"] = a / b;
            return View("Views/Calc/index.cshtml");
        }
    }
}
