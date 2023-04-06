using Microsoft.AspNetCore.Mvc;
using Day19Lab1.Models;

namespace Day19Lab1.Controllers {
    public class CustomerController : Controller {

        private readonly DataContext _Context;
        public CustomerController(DataContext _DContext) {
            _Context = _DContext;
            //Popolate DB
            if (_Context.Customers.Count() == 0) {
                for (int i = 0; i < 10; i++) {
                    Customer mio = new Customer() {
                        CusotmerStatus = 1,
                        CustomerName = $"Customer {i}",
                        CustomerEmail = $"cust{i}@test.com",
                        CustomerPhone = $"555-5{i}9-9338"
                    };
                    _Context.Customers.Add(mio);
                }
                _Context.SaveChanges();
            }
        }
        public IActionResult Index() {
            var custs= _Context.Customers.ToList();
            return View(custs);
        }
    }
}
