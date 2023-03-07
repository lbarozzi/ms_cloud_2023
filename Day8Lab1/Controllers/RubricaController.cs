using Day8Lab1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Day8Lab1.Controllers {
    public class RubricaController : Controller {
        private readonly Rubrica _rub;
        public RubricaController(Rubrica rubrica) {
            _rub = rubrica;
            //Emtpy: fill
            if(_rub.Count == 0) {
                for(int i=0; i < 5;i++) {
                    _rub.Add(new Anagraphic() { 
                        FirstName=$"FirstName {i}",
                        LastName =$"LastName {i}",
                        PhoneNumber=$"555-435-333-{i}",
                        Email=$"test_{i}@test.com"
                    });
                }
            }
        }

        public IActionResult Index() {
            return View();
        }
    }
}
