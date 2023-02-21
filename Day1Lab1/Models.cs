using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;

namespace Day1Lab1.Models {

    public class Rubrica {
        protected List<Contatto> _elenco;
        public Rubrica() {
            _elenco= new List<Contatto>();
            Console.WriteLine("Creato una rubrica!");
        }

        public void AddContatto(Contatto contatto) {
            _elenco.Add(contatto);
        }

        //public void DeleteContatto();
        //public void EditContatto();

        public List<Contatto> ListaContatti() { 
            //TODO: filter
            return _elenco;
        }

        public Contatto GetFirstByName(string _nome) {
            foreach(Contatto ct in _elenco) { 
                if(ct.Name == _nome) return ct;    
            }
            //Avoid this: return null;
            throw new ArgumentOutOfRangeException("Nome non trovato!");
        }

        public int Length { get { return _elenco.Count; } }

        public static Rubrica operator+ (Rubrica r, Contatto c) {
            r.AddContatto(c);
            return r;
        }
    }
    public class Contatto {
        /** Promemoria
        protected string _Antatni;
        public string getAntani() {  return _Antatni;}
        public void setAntatni(string foo) {  _Antatni = foo;}  
        public string Antani { get ; set; }
        //*/
        protected static string[] NameList = {"Leonardo", "Jason","Alex","Claudio","Francesco",
                "Gialuigi","Laura","Liang","Marco","Maria","Martina","Massimiliano"};
        protected static string[] SurnameList = { "foo", "Bar", "red", "green" };
        protected static int _counter = 0;
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }

        public string FullName {
            get {
                return $"{this.Name} {this.Surname}";
            }
        }

        public virtual void Contatta() {   
            Console.WriteLine($"Sto chiamando {PhoneNumber} di {FullName}");
        }

        public virtual void Contatta(string Messaggio) {
            Console.WriteLine($"Sto mandando {Messaggio} a {PhoneNumber} di {FullName}");   
        }

        public Contatto() {
            _counter++; //_counter= _counter+1;
            Console.WriteLine($"Costruttore di Contatto n°  ({_counter})");
        }
        public Contatto(string name, string surname, string phoneNumber) {
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
        }

        public override string ToString() {
            return $"({_counter}) {Name} {Surname}: {PhoneNumber}";
        }

        public static Contatto GetRandomContact() {
            Random r = new Random();
            int x = r.Next(NameList.Length);
            int y = r.Next(SurnameList.Length);
            return new Contatto() {
                Name = NameList[x],
                Surname = SurnameList[y],
                PhoneNumber = $"{x}-{y}"
            };
        }

    }
    public class EmailContatto: Contatto {
        public string Email { get; set; }
        public EmailContatto() { Console.WriteLine("Nuovo EmailContatto"); }


        public override string ToString() {
            return $"{base.ToString()}  email: {this.Email}";
        }
    }

}