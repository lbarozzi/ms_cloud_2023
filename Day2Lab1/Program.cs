// See https://aka.ms/new-console-template for more information
using System.Text;

Console.WriteLine("MasterMind!");

List<string> Tentatives=   new List<string>();
string key;
string tentative;
MMind game = new MMind();

do {
    Console.Write("please insert key:");
    key =Console.ReadLine().ToUpper();
}while (!MMind.IsValid(key)) ;

game.SetKey(key);
//game.GenerateKey();

int i = 0;
for ( i = 0; i < 10; i++) {
    Console.WriteLine($"Tentivo {i}");
    tentative = Console.ReadLine();
    Tentatives.Add(tentative);
    int scs = 0;
    foreach (string s in game.Validate(tentative)) {
        Console.WriteLine(s);
        if (s.Equals("Colore giusto posto giusto"))
            scs++;
    }
    if (scs == 4) {
        Console.WriteLine($"U've WIN in ** {i+1} rounds");
        break;
    }
}
if (i == 9) {
    Console.WriteLine("You loose");
}
Console.ReadLine();

public class MMind {

    string _key;
    //string tentative;

    public void SetKey(string key) {
        if(IsValid(key)) {
            _key = key;
        } else { 
            throw new ArgumentException();
        }
    }

    static char[] validchrs = { 'R', 'G', 'V', 'B' };
    public static bool IsValid(string sequence) {
        if (sequence.Length > 4) {
            return false;
        }
        foreach (char c in sequence) {
            if (!validchrs.Contains(c)) { return false; }
        }
        return true;
    }
    public  IEnumerable<string> Validate(string test) {
        List<string> res = new List<string>();
        for(int i=0;i<test.Length;i++) {
            if (test[i] == _key[i]) {
                res.Add("Colore giusto posto giusto");
            } else if (_key.Contains(test[i])) {
                res.Add("Colore giusto posto errato");
            }
        }
        return res;
    }
    public void GenerateKey() {
        Random r= new Random();
        StringBuilder sb= new StringBuilder();
        for (int i = 0; i < 4; i++) {
            sb.Append(validchrs[r.Next(validchrs.Length)]);
        }
        _key=sb.ToString();
    }
}


