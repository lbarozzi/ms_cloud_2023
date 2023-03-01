using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Day4lab1.Pages {
    public class IndexModel : PageModel {
        private readonly ILogger<IndexModel> _logger;


        public string[] _data { get; set; }
        public IndexModel(ILogger<IndexModel> logger) {
            _logger = logger;
            //_data = new string[0];
        }

        public void OnGet() {
            _data = "Ma la volpe sol suo balzo ha raggiunto il quieto fido".Split(' ');
            List<Anagrafica> elenco=new List<Anagrafica>(); 
            for(int i=0,j=5;i<5;i++,j--) {
                elenco.Add(new Anagrafica() { 
                    FirstName = $"Antanti {i}",
                    LastName = $"Sbiriguda {j}" });
            }
            ViewData["max"] = elenco;
        }
    }
}