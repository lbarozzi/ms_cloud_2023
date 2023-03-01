using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic;
using System.Security.Cryptography;

namespace Day5Lab1.Pages {
    public class IndexModel : PageModel {
        private readonly ILogger<IndexModel> _logger;

        //public List<ToDoItem>  ToDoList { get; set; }
        protected ToDoList _list;
        public IEnumerable<ToDoItem> ToDoList {
            get {
                return _list.GetList();
            }
        }
        public IndexModel(ILogger<IndexModel> logger,ToDoList Lista) {
            _logger = logger;
            //ToDoList= new List<ToDoItem>();
            //_list = new ToDoList();
            _list = Lista;
        }

        public void OnGet() {
            for(int i=0;i<10;i++) {
                _list.Add( new ToDoItem() { Title=$"To Do iten n° {i}" });
            }
        }
        public void OnPost(string title,string notes,DateTime dueDate) {
            //TODO: Check Data integrity
            /* One way
            string myTitle = this.Request.Form["title"];
            string myNotes = Request.Form["notes"];
            //TODO: try / catch
            DateTime myDueDate = DateTime.Parse(Request.Form["dueDate"]);
            //*/
            ToDoItem myItem = new ToDoItem() {
                /* old1 
                Title = myTitle,
                Notes = myNotes,
                DueDate = myDueDate,
                //*/
                //Id=Guid.NewGuid().,
                //Id = _list.GetList().Count() + 1,
                Title = title,
                Notes = notes,
                DueDate = dueDate
            };
            //Aggiungo alla lista
            _list.Add(myItem);
        }
    }
}