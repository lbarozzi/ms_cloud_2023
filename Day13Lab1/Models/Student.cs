namespace Day13Lab1.Models {
    /*
    public class Student {

        public int StudentID { get; set; }
        public string StudentFirstName { get; set;}
        public string StudentLastName { get; set; }
        public string StudentEmail { get; set;}
        public string StudentPhone { get; set;}

        public List<Enrollment> Enrolled { get; set; }= new List<Enrollment>();
    }

    public class Enrollment {
        public int ID { get; set; }
        public Student StudentEnrolled { get; set; }=   new Student();  
        public Exam ExamEnrolled { get; set; } = new Exam();
    }

    public class Exam {
        public int ExamID { get; set; }
        public string ExamName { get; set; } = "";
        //public string CourseDescription { get; set; }
        //public List<Student> Enrolled { get; set; } = new List<Student>();
        public List<Enrollment> Enrolled { get; set; } = new List<Enrollment>();
    }
    //*/
    public class Anagraphic {
        public int AnagraphicID { get; set; }

        public string CompanyName { get; set; }
        public string  VAT { get; set; }
        List<Address> AddressList { get; set; }
    }

    public class Address {
        public int AddressID { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string AddressText { get; set; }
        public Anagraphic MyAnagraphic { get; set; }
    }   
}
