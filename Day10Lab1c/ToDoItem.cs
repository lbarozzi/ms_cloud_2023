namespace Day10Lab1c {
    public class ToDoItem {
        public int ToDoItemID { get; set; }
        //
        public string Title { get; set; }
        
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CreationDate { get; set; }
        public int PriorityLevel { get; set; }
        public bool IsMandatory { get; set; }
        public bool IsDone { get; set; }

        public ToDoItem() {
            Title = Description = string.Empty;
            IsMandatory=IsDone=false;
        }

        public override string ToString() {
            return $"{Title} ({Description}) on {DueDate.ToLocalTime()} [{PriorityLevel}] done: {IsDone}";
        }
    }
}