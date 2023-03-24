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
                int deltaT = 1;
                var x = from t in Temperatures
                        where t.TemperatureValue > TargetTemperarure +deltaT || t.TemperatureValue< TargetTemperarure-deltaT
                        select t;

                return x.Count()!=0;
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
        public Zone Zone { get; set; } = new Zone();

    }
}
