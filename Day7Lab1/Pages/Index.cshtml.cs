using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Runtime.CompilerServices;

namespace Day7Lab1.Pages {
    public class IndexModel : PageModel {
        private readonly ILogger<IndexModel> _logger;
        public ToDoList _list;
        //Binding properties
        [BindProperty]
        public string Description { get; set; }
        [BindProperty]
        public DateTime DueDate { get; set; }
        [BindProperty]
        public bool Done { get; set; }
        [BindProperty]
        public int ID { get; set; }
        [BindProperty]
        public ToDoModel.ToDoPriority Priority { get; set; }

        public IndexModel(ILogger<IndexModel> logger,ToDoList lista) {
            _logger = logger;
            _list = lista;
        }

        public void OnGet() {
            if(_list.Count==0) {
                //FOR TESTING PURPOSE
                _list.PopulateList(10);
            }
            //ViewData["enum"] = Enum.GetValues(typeof(ToDoModel.ToDoPriority));
            Priority = ToDoModel.ToDoPriority.VeryHigh;
            DueDate = DateTime.Now;
            Done = false;
        }
        public void OnPost(string nomecampo) {
            //Request.Form["Antani"]
            ToDoModel newItem = new ToDoModel() {
                Description=this.Description,
                DueDate=this.DueDate,   
                done=this.Done,
                PriorityLevel=this.Priority
            };
            _list.Add(newItem);
        }
    }
}