using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Day8Lab1.Models {
    public class Anagraphic {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        
        public string FullName { get { return $"{LastName} {FirstName}"; } }
        public Anagraphic() { 
            FirstName = string.Empty;
            LastName = string.Empty;
            PhoneNumber = string.Empty; 
            Email= string.Empty;
        }
        public override string ToString() {
            return $"{FirstName} {LastName} [{PhoneNumber}] @=> {Email}";
        }
    }

    public class Rubrica:List<Anagraphic> {

    }
}
