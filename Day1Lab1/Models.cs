using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;

namespace Day1Lab1.Models {

    public class Rubrica {
        protected List<Contatto> _elenco;
        protected Dictionary<string, Contatto> _dictio;
        //protected Dictionary<int, Contatto> _dictio;
        public Rubrica() {
            _elenco= new List<Contatto>();
            Console.WriteLine("Creato una rubrica!");
        }

        public void AddContatto(Contatto contatto) {
            if (_dictio.ContainsKey(contatto.Name)) {
                throw new ArgumentOutOfRangeException("Nome duplicato!");
            }
            _elenco.Add(contatto);
            _dictio[contatto.Name] = contatto;  
        }

        //public void DeleteContatto();
        //public void EditContatto();
        public Contatto GetContattoByFullName(string fName) { 
            return _dictio[fName];  
        }
        public List<Contatto> ListaContatti() { 
            return _dictio.Values();
            //TODO: filter
            return _elenco;
        }

        public Contatto GetByLastName(string lastName) {
            return (from contatto in _elenco
                    where contatto.Surname == lastName
                    select contatto).First();
            //Dictionari
            return (from Contatto in _dictio.Values
                    where Contatto.Surname == lastName
                    select Contatto).First();
        }

        public Contatto GetFirstByName(string _nome) {
            if (_dictio.ContainsKey(_nome)) { 
                return _dictio[_nome]; 
            } else
                throw new ArgumentOutOfRangeException("Nome non trovato!");
            //OLD Code
            foreach (Contatto ct in _elenco) { 
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
    public abstract class Persona {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }

        public abstract string GetPersonType();
    }

    public class Contatto : Persona{
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
       

        public string FullName {
            get {
                return $"{this.Name} {this.Surname}";
            }
        }

        public override string GetPersonType() {
            return $"I'm a Contact";
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

    public class Customer {
        public string Name { get; set; }    

    }
}