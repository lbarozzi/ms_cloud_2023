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
            return View(_rub);
        }

        public IActionResult Update(int? antani) {
            if(antani== null || antani >= _rub.Count)
                return RedirectToAction("index");

            ViewData["action"] = "Update";
            return View("/Views/Rubrica/Anagraphic.cshtml", _rub[(int)antani]);
        }
        [HttpPost]
        public IActionResult Update(int? antani, [FromForm] Anagraphic updated) {
            if (antani == null || antani >= _rub.Count || updated==null)
                return RedirectToAction("index");

            try {
                _rub[(int)antani] = updated;
            }catch(Exception ex) {
                //LOG THIS SHIT, HOLY SHIT
            }

            return RedirectToAction("index");
        }

        //TODO: DELETE!! 
        public IActionResult Delete(int? tokill) {
            if (tokill == null || tokill >= _rub.Count) {
                return RedirectToAction("index"); 
            }
            ViewData["action"] = "** DELETE **";
            return View("/Views/Rubrica/Anagraphic.cshtml", _rub[(int)tokill]);
        }
        [HttpPost]
        public IActionResult Delete(int? tokill, [FromForm] Anagraphic deleted) {
            if (tokill == null || tokill >= _rub.Count||deleted==null) {
                return RedirectToAction("index");
            }
            _rub.RemoveAt((int)tokill);
            return RedirectToAction("index");

        }

        [HttpGet]
        public IActionResult New() {
            ViewData["action"] = "Add New";
            return View("/Views/Rubrica/Anagraphic.cshtml", new Anagraphic());
        }

        [HttpPost]
        public IActionResult New([FromForm] Anagraphic Nuova) {
            _rub.Add(Nuova);
            return RedirectToAction("index");
        } 
    }
}
