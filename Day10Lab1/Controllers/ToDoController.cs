using Day10Lab1c;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day10Lab1.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase {
        //Dependency Injection
        private readonly DataContext _context;

        public ToDoController(DataContext context) {
            _context= context;  
            //Popola
            if(context.ToDoItems.Count()==0) {
                for(int i=0;i<5;i++ ) {
                    ToDoItem item = new ToDoItem() {
                        Title = $"Item {i}",
                        Description = $"Description {i}",
                        CreationDate = DateTime.Now,
                        DueDate = DateTime.Now.AddDays(i),
                        PriorityLevel = 10 + i,
                        IsDone = false,
                        IsMandatory = false,    
                    };
                    context.ToDoItems.Add(item);
                }
                //Savechanges to DB
                context.SaveChanges();
            }
        }

        [HttpGet(Name ="GetToDoItem")]
        public IEnumerable<ToDoItem> Get() {

            return from item in _context.ToDoItems
                   select item;
            //return _context.ToDoItems;
        }

        [HttpPut(Name = "NewItem")]
        public ToDoItem NewItem(ToDoItem item) {
            var res = _context.ToDoItems.Add(item);
            _context.SaveChanges();
            return res.Entity;
        }
    }
}
