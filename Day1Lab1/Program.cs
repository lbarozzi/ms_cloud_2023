using Day1Lab1.Models;
using System.Reflection.Metadata.Ecma335;

namespace Day1Lab1 {
    internal class Program {
        static void Main(string[] args) {
            int a = 5; int b=6;
            Console.WriteLine($"a= {a} b={b}");
            Somma(a, b);
            Console.WriteLine($"a= {a} b={b}");
            Contatto t1 = Contatto.GetRandomContact();
            Console.WriteLine(t1);
            CambiaNumero(t1);
            Console.WriteLine(t1);


            //Console.WriteLine("Hello, World!");
            //Step 1: Credo 10 Contatti e li visualizzo
            //Contatto c = new Contatto();
            /* Useless
            string[] NameList = {"Leonardo", "Jason","Alex","Claudio","Francesco",
                "Gialuigi","Laura","Liang","Marco","Maria","Martina","Massimiliano"};
            string[] SurnameList = { "foo", "Bar", "red", "green" };
            //*/
            Rubrica AmiciMiei = new Rubrica(); 
            bool exit=false;
            do {
                switch (Menu()) {
                    case 0:
                        exit = true;
                        break;
                    case 1:
                        NewContact(AmiciMiei); 
                        break;
                    //AddContact
                    case 2:
                        Show(AmiciMiei);
                        break;
                    //ListAll
                    case 3:
                        Search(AmiciMiei);
                        break;
                    //Search
                    case 4:
                    default:
                        break;
                }
            } while (!exit);

            IPositionable pippo = new Car();
            IPositionable pluto = new WareHouse();

            Console.WriteLine(pluto.GetCurrentGPSPosition());

            
            //for(int i = 0; i<10;i++) {
            //    //Contatto c = new Contatto() {
            //    /* Old1 
            //    Contatto c = new EmailContatto() {
            //        Name = NameList[i % NameList.Length],
            //        Surname = SurnameList[i % SurnameList.Length],
            //        PhoneNumber=i.ToString(),
            //        Email=$"Antati:{i}"
            //    };
            //    //*/
            //    Contatto c = Contatto.GetRandomContact();
            //    //AmiciMiei.AddContatto(c);   

            //    AmiciMiei+=c;   

            //    //Console.WriteLine(c);    
            //}
            /*/
            foreach(Contatto c_iter in AmiciMiei.ListaContatti()) { 
                Console.WriteLine(c_iter);
            }
            //*/
           //Console.ReadLine(); 
        }

        static void Search(Rubrica rub) {
            Console.WriteLine("");
            Console.WriteLine("Search by Name");
            Console.WriteLine("");
            Console.Write("Query: ");
            string _nome = Console.ReadLine();
            var v = rub.GetFirstByName(_nome);  
            Console.WriteLine("Ho trovaro:");
            Console.WriteLine(v);
        }

        static void NewContact(Rubrica rub) {
            Console.WriteLine(""); 
            Console.WriteLine("Add New Contact "); 
            Console.WriteLine("");
            Console.Write("Name: ");
            string n= Console.ReadLine();
            Console.Write("Surname; ");
            string s= Console.ReadLine();
            Console.Write("Phone: ");
            string p= Console.ReadLine();   
            rub.AddContatto(new Contatto(n, s, p)); 
        }
        static void Show(Rubrica rub) {
            Console.WriteLine("");
            Console.WriteLine("*************************************");
            Console.WriteLine("");
            foreach (Contatto c_iter in rub.ListaContatti()) {
                Console.WriteLine(c_iter);
            }
            Console.WriteLine("");
            Console.WriteLine("**************************************");
            Console.WriteLine("");
        }
        static int Menu() {
            Console.WriteLine("");
            Console.WriteLine("******** Main Menù *************");
            Console.WriteLine("");
            Console.WriteLine("1    AddContact");
            Console.WriteLine("2    List All");
            Console.WriteLine("3    Search for Name");
            //Console.WriteLine("4    AddContact");
            Console.WriteLine("");
            Console.WriteLine("0    End");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write("Choice:?");
            string s = Console.ReadLine();
            int result = -1;
            try {
                result= int.Parse(s);
            } catch(Exception ops) {
                Console.WriteLine("Invalid Choice");
            }
            return result;
        }
        //WARN: BUG!!!!
        static void  Somma(int a, int b) {
            a += b;
            Console.WriteLine($"In function a={a} b={b}");
        }

        static void CambiaNumero(Contatto ctx) {
            ctx.PhoneNumber = "1234567891234597";
        }
    }
}