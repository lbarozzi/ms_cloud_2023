namespace TestMezzo.Models {


    public class Taxi {
        public int Id { get; set; }
        public string Plate { get; set; }
        //public int NmeroCorse { get;set; }

        public List<Corsa> Corse { get; set; }

    }

    public class Corsa {
        public int Id { get; set; }
        public Taxi Driver { get; set; }
        public string From { get; set; }
        public string To { get; set; }
    }
}
