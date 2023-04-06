using Day18Lab2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json.Nodes;

namespace Day18Lab2.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;
        private readonly HttpClient _httpCat;
        public HomeController(ILogger<HomeController> logger, IHttpClientFactory ApiFactory) {
            _logger = logger;
            //Uso 
            _httpClient = ApiFactory.CreateClient("Md5");
            _httpCat = ApiFactory.CreateClient("cats");

        } 

        public async Task<IActionResult> Index() {
            //Let's query cats 
            /*/no automation
            var _httpCat = new HttpClient();
            _httpCat.BaseAddress = new Uri("https://cat-fact.herokuapp.com/facts");
            _httpCat.DefaultRequestHeaders.Add("ntanti", "biriguda");
            //*/
            var res =await  _httpCat.GetAsync(_httpCat.BaseAddress);
            if (res.IsSuccessStatusCode) {
                string buffer= await res.Content.ReadAsStringAsync();
                var json = JsonObject.Parse(buffer);
                List<string> quotes = new List<string>();
                foreach(var item in json.AsArray()) {
                    quotes.Add(item!["text"].ToString());
                }
                ViewData["Quotes"]= quotes;
            }
            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

        public async Task<IActionResult> query(string PlainText) {
            //To itbase + ?PlainText=ciccciocci
            string url = $"{_httpClient.BaseAddress.ToString()}?PlainText={PlainText}";
            var res = await _httpClient.GetAsync(url);
            res.EnsureSuccessStatusCode();
            if(res.IsSuccessStatusCode) {
                var dato =await  res.Content.ReadAsStringAsync();
                ViewData["result"]=dato.ToString();
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}