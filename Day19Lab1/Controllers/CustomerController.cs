using Microsoft.AspNetCore.Mvc;
using Day19Lab1.Models;

namespace Day19Lab1.Controllers {
    public class CustomerController : Controller {

        private readonly DataContext _Context;
        public CustomerController(DataContext _DContext) {
            _Context = _DContext;
        }
        public IActionResult Index() {
            var custs= _Context.Customers.ToList();
            return View(custs);
        }
    }
}
