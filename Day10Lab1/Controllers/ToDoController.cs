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
        }

        [HttpGet(Name ="GetToDoItem")]
        public IEnumerable<ToDoItem> Get() {

            return from item in _context.ToDoItems
                   select item;
            //return _context.ToDoItems;
        }
    }
}
