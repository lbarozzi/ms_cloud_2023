namespace Day7Lab1 {
    public class ToDoModel {
        public enum ToDoPriority {
            Low,Normal,High,VeryHigh
        }
        private static int _id=0;
        public static int GetNextId() {
            return _id++; //start from 0
            //return ++_id; //start from 1
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
                "Sbiriguda",
                "Riposare",
                "Cenetta romantica"
            };
            Random r = new Random();
            for(int i=0; i < records; i++) {
                /*/Explain
                int indice_eleco = r.Next(elenco.Length);
                string descrizione_corrente = elenco[indice_eleco]; 
                //*/
                this.Add(new ToDoModel() {  
                    ID = ToDoModel.GetNextId(), //i ,
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
