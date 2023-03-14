using System.IO;

namespace Day9Lab1.Models {
    public class SerialKillers {
        List<string> Killers = new List<string>();
        public SerialKillers() {
            LoadFromFile();
        }
        public void LoadFromFile(string path = "names.txt") {
            if (File.Exists(path)) {
                Killers= new List<string>(File.ReadAllLines(path));
            } else {
                Killers= new List<string>();
                //Killers.Add("Emplty List")
                throw new ArgumentException("File dosn't exists");
            }
            //Second way
            //Killers = new List<string>(File.ReadAllLines(path));
        }

        public List<string> GetKillersFromString(string start_killer) {
            return (from killer in Killers
                    where killer.ToLower().StartsWith(start_killer.ToLower())
                    //orderby  killer
                    select killer).ToList();
        }
        public List<string> GetKillerByLen(int KillerLen=5) {
            /*/ Maunual Way
            List<string> list = new List<string>();
            foreach (string killer in Killers) {
                if (killer.Length== KillerLen) { 
                    list.Add(killer);
                }
            }
            return list;
            //*/
            /*
            var list = from killer in Killers
                       where killer.Length == KillerLen
                       //orderby  killer
                       select killer;
            return list.ToList();
            //*/
            // Query syntax
            return (from killer in Killers
                   where killer.Length == KillerLen
                   //orderby  killer
                   select killer)
                   .ToList();
            //*/
            //Method Syntax
            /*/
            return Killers
                    .Where(killer =>  killer.Length==KillerLen )
                    //.OrderBy(killer=>killer.Length)
                    .ToList();
            //*/

        }
    }
}
