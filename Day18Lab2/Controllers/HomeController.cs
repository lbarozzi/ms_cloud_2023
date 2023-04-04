using Day18Lab2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Day18Lab2.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;
        public HomeController(ILogger<HomeController> logger,IHttpClientFactory ApiFactory) {
            _logger = logger;
            //Uso 
            _httpClient = ApiFactory.CreateClient("Md5");
        }

        public IActionResult Index() {
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