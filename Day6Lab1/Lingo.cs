using System.Reflection.Metadata;
using System.Text;

namespace Day6Lab1 {
    public class Lingo {
        public enum status {
            NONE,GREEN,YELLOW,RED
        }
        protected string _word;
        public string Hint { get; set; }
        public List<string> Tentativi { get; set; }
        private List<status> lastResult { get; set; }
        public int MaxLen { get; set; }
        private string _dicname = "660000_parole_italiane.txt";
        private string[] _dictionary = {
            "rotto","cielo","pizza","puzza","carta","massa","righe","dighe","corsa","borsa","torta",
            "camici","rotoli","rutile","ponevo","rigore","donare","peroro","sicuro","ricevo","farete",
            "faretra","sistema","ramarro","pastore","bastone","pistola","cantore","candela","pitocco"
        };
        public Lingo() {
            if(File.Exists(_dicname)) {
                _dictionary= File.ReadAllText(_dicname).Split("\n".ToCharArray());  
            }
            Tentativi = new List<string>(); 
            lastResult = new List<status>();
            MaxLen = 5;
        }
        public void NewWord() {
            Random rnd = new Random();
            var mydic = (from voce in _dictionary
                        where voce.Length == MaxLen
                        select voce).ToList();
            _word= mydic[rnd.Next(mydic.Count)];
            List<status> r= new List<status>();
            r.Add(status.GREEN);
            for(int i=1;i<MaxLen;i++) {
                r.Add(status.NONE);
            }
            //Hint = _word[0] + string.Join("_", new char[_word.Length-1]);
            UpdateHint("",r); 
        }

        public void UpdateHint(string newWord, List<status> result) {
            StringBuilder sb= new StringBuilder();
            
            result[0] = status.GREEN;
            //Keep greens
            for(int j=0; j<lastResult.Count; j++ ){
                if (lastResult[j]==status.GREEN) {
                    result[j] = status.GREEN;
                }
            }
            //test
            int i = 0;
            foreach (status st in result) {
                switch(st) {
                    case status.GREEN:
                        sb.Append(_word.ToUpper()[i]); 
                        break;
                    case status.YELLOW:
                        sb.Append(newWord.ToLower()[i]);
                        break;
                    default: // status.NONE:
                            sb.Append("_");
                        break;
                }
                i++;
            }
            Hint=sb.ToString();
            lastResult = result;    
        }
        public List<status> TestWord(string newWord) {
            List<status> result = new List<status>();
            if (newWord.Length > _word.Length) {
                foreach (char c in newWord.Substring(_word.Length)) {
                    result.Add(status.RED);
                }
            } else {
                //Test
                for (int i = 0; i < newWord.Length; i++) {
                    char current = newWord[i];
                    if (current == _word[i]) {
                        result.Add(status.GREEN);
                    } else {
                        if (_word.Contains(current)) {
                            result.Add(status.YELLOW);
                        } else {
                            result.Add(status.NONE);
                        }
                    }
                }
            }
            //Update Hint
            UpdateHint(newWord,result);
            //GO!
            return result;
        }
    }
}
