namespace Day7Lab1 {
    public class ToDoModel {
        public enum ToDoPriority {
            Low,Normal,High,VeryHigh
        }
        public int ID { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public ToDoPriority PriorityLevel { get; set; }
        public bool done { get; set; }
        public ToDoModel() { 
            this.Description = string.Empty;
        }
    }
    public class ToDoList: List<ToDoModel> { 
        public ToDoList() { }
        public void PopulateList(int records=5) {
            string[] elenco =
            {
                "Pulire Lettiera",
                "Prepare letto",
                "Telefonare Antanti",
                "Tagliando Macchina",
                "Sbiriguda"
            };
            Random r = new Random();
            for(int i=0; i < records; i++) {
                this.Add(new ToDoModel() {  
                    ID = i ,
                    Description = $"{elenco[r.Next(elenco.Length)]} {i}",
                    DueDate = DateTime.Now,
                    done = false    ,
                    PriorityLevel=(ToDoModel.ToDoPriority)r.Next(
                        Enum.GetValues(typeof(ToDoModel.ToDoPriority)).Length ) ,
                });
            }
        }
    }
}
