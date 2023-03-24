using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Day13Lab2.Models {
    public class Zone {
        public int ZoneID { get; set; }
        public string Description { get; set; } = "";
        public bool IsActive { get; set; }

        public Single TargetTemperarure { get; set; }
        [NotMapped]
        public bool IsAlarm {
            get {
                //TODO: Report is any temp is in amlarm
                return false;
            }
        }
        //
        public List<Temperature> Temperatures {  get; set; }    = new List<Temperature>();
    }

    public class Temperature {
        public int TemperatureID { get; set; }
        public DateTime TemperatureDate { get; set; }   
        public Single TemperatureValue { get; set; }
        //
        public int ZoneId { get; set; }
        public Zone Zene { get; set; } = new Zone();

    }
}
