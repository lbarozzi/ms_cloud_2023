using Day10Lab1c;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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

        [HttpGet("undones",Name ="GetNotDones")]
        public ActionResult<List<ToDoItem>> GetUndones() {
            var nextToDo = (from item in _context.ToDoItems
                            where item.IsDone == false
                            orderby item.DueDate descending
                            orderby item.PriorityLevel descending
                            select item);

            if (nextToDo == null) {
                return NotFound("nothin to do");
            }
            return Ok(nextToDo);
        }


        [HttpGet("dones", Name = "GetDones")]
        public ActionResult<List<ToDoItem>> GetDones() {
            var nextToDo = (from item in _context.ToDoItems
                            where item.IsDone == true
                            orderby item.DueDate descending
                            orderby item.PriorityLevel descending
                            select item);

            if (nextToDo == null) {
                return NotFound("nothin to do");
            }
            return Ok(nextToDo);
        }

        [HttpGet("nextone", Name = "GetNextOne")]
        public ActionResult<ToDoItem> GetNext() {
            var nextToDo = (from item in _context.ToDoItems
                            where item.IsDone == false
                            orderby item.DueDate descending
                            orderby item.PriorityLevel descending
                            select item).FirstOrDefault();

            if (nextToDo == null) {
                return NotFound("nothin to do");
            }
            return Ok(nextToDo);
        }


        [HttpGet("{id}")] 
        public ActionResult<ToDoItem> Get(int id) {
            var item=(from idx in _context.ToDoItems
                     where idx.ToDoItemID == id
                     select idx).FirstOrDefault();

            if(item == null) {
                //NotFound!!
                return NotFound("ToDoItem not in List");
            }
            return Ok(item);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id,ToDoItem item) {
            var todo = _context.ToDoItems
                        .Where(idx => idx.ToDoItemID == id)
                        .FirstOrDefault();
            if(todo == null) {
                //
                return NotFound();
                //or create a new one
            }
            //Copy required fields to Update
            todo.Title =item.Title;
            todo.Description=item.Description;
            todo.IsDone = item.IsDone;
            todo.IsMandatory = item.IsMandatory;
            todo.PriorityLevel = item.PriorityLevel;
            todo.DueDate = item.DueDate;
            //
            _context.SaveChanges();
            return Ok();
        }

        //*/
        [HttpDelete("{id}")]
        public ActionResult Delete(int id) {
            var item = (from idx in _context.ToDoItems
                        where idx.ToDoItemID == id
                        select idx).FirstOrDefault();

            if (item == null) {
                //NotFound!!
                return NotFound("ToDoItem not in List");
            }
            _context.ToDoItems.Remove(item);
            _context.SaveChanges();
            return Ok();
        }
        //*/

        [HttpPost(Name = "NewItem")]
        public ToDoItem NewItem(ToDoItem item) {
            var res = _context.ToDoItems.Add(item);
            _context.SaveChanges();
            return res.Entity;
        }

    }
}
