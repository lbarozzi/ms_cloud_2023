using System.Security.Principal;

namespace Day5Lab1 {
    public class MySingleton {
        static MySingleton _instance;
        protected MySingleton() { } 

        public MySingleton GetSingleton() {
            if(_instance == null ) {
                _instance = new MySingleton();  
            }
            return _instance;
        }
    }
    public class ToDoList {
        protected List<ToDoItem> _list = new List<ToDoItem>();
        public ToDoList() { }
        public void Add(ToDoItem toDoItem   ) {
            _list.Add(toDoItem);
        }
        public IEnumerable<ToDoItem> GetList() {
            return _list; 
        }
    }
    public class ToDoItem {
        public enum ItemStates {
            ToDo,Done,Deferred,Overdue
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Notes { get; set; }
        public DateTime DueDate { get; set; }
        public int Priority { get; set; }
        public ItemStates status { get; set; }
        public bool IsDone { get { return status == ItemStates.Done; } }

        public ToDoItem() { 
            DueDate= DateTime.Now;
            Title = Notes = string.Empty;
            status = ItemStates.ToDo;
        }
        public override string ToString() {
            return $"{DueDate.ToShortDateString()}:{DueDate.ToShortTimeString()} => {Title} : {status}";
        }
    }
}
