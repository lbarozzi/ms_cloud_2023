using System;
using System.IO.Compression;

namespace Day10Lab2 {
    internal class Program {
        class tizio {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
        }
        static void Main(string[] args) {
            Console.WriteLine("Hello, World!");
            DateTime start= DateTime.Now;
            List<Task> lista = new List<Task>();
            Console.WriteLine("start long ");
            Task t1= DoLong();
            
            lista.Add(t1);
            for(int i=0;i<3;i++) {
                Console.WriteLine("start short ");
                lista.Add(DoShort());
            }

            Task.WaitAll(lista.ToArray());
            //
            List<tizio> elenco = new List<tizio>(); 
            for(int z=0; z<30;z++   ) {
                elenco.Add(new tizio() {
                    FirstName=$"None{z}",
                    LastName=$"Cognome{z}",
                    Age=z
                });
            }
            var foo = from t in elenco
                      where t.Age % 2 == 0
                      select new { t.FirstName, t.Age };

            foreach(var idx in foo ) {
                Console.WriteLine($"{idx.FirstName}: {idx.Age}");
            }

            //


            DateTime stop= DateTime.Now;
            Console.WriteLine($"Done  in {(stop-start).TotalMilliseconds} ms");

            Console.ReadLine();
        }

        static async Task DoShort() {
            Console.WriteLine("Do Short");
            await Task.Delay(2000);
            Console.WriteLine($"End short {DateTime.Now} {DateTime.Now.Millisecond}");
        }

        static async Task DoLong() {
            Console.WriteLine("Do Long");
            await Task.Delay(10000);
            Console.WriteLine($"End long {DateTime.Now.ToLongTimeString()}");
        }

    }
}