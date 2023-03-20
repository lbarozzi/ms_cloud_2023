using System.Runtime.InteropServices;

namespace WebAPiKiller.Models {
    public class Killer {
        public int KillerID { get; set; }
        public string KillerName { get; set; }
        public string  KillerDescription { get; set; }
        public int KillerKilled { get; set; }
        public bool IsInJail { get; set; }
        public Killer() {
            KillerName = KillerDescription = string.Empty;
            IsInJail = false;
            KillerKilled = 0;
        }
        public override string ToString() {
            return $"({KillerID}) {KillerName} [{KillerKilled}]";
        }

    }
}
