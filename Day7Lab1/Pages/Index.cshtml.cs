using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.CompilerServices;

namespace Day7Lab1.Pages {
    public class IndexModel : PageModel {
        private readonly ILogger<IndexModel> _logger;
        public ToDoList _list;

        public IndexModel(ILogger<IndexModel> logger,ToDoList lista) {
            _logger = logger;
            _list = lista;
        }

        public void OnGet() {
            if(_list.Count==0) {
                _list.PopulateList(10);
            }
        }
    }
}