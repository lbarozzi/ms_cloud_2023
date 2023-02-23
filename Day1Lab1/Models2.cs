namespace Day1Lab1.Models {
    public class GPSPosition {
        public double Lat { get; set; }
        public double Long { get; set; }
    }

    public interface IPositionable {
        public GPSPosition GetCurrentGPSPosition();
    }

    public abstract class Veicolo : IPositionable {
        public string Modello { get; set; }
        public string Colore { get; set; }
        public int NUmeroPasseggieri { get; set; }
        public int KgCarico { get; set; }

        public abstract void MoveToGPSPosition(GPSPosition newPosition);
        public abstract GPSPosition GetCurrentGPSPosition();
    }

    public class Car : Veicolo {
        public string Cilindrata { get; set; }
        public int KmAutonomia { get; set; }
        public string Carburante { get; set; }
        public int NumeroPorte { get; set; }
        public string VIN { get; set; }
        public string Targa { get; set; }
        protected GPSPosition _myPosition;

        public override GPSPosition GetCurrentGPSPosition() {
            return _myPosition;
        }
        public override void MoveToGPSPosition(GPSPosition newPosition) {
            _myPosition = newPosition;
        }
    }

    public class Truck : Car {
        public bool Ribaltabile { get; set; }
        public bool Rimorchio { get; set; }
        public int Assi { get; set; }
    }
    public class Ship : Veicolo {
        public string Nome { get; set; }
        public string Bandiera { get; set; }
        protected GPSPosition _myPosition;

        public override GPSPosition GetCurrentGPSPosition() {
            return _myPosition;
        }
        public override void MoveToGPSPosition(GPSPosition newPosition) {
            _myPosition = newPosition;
        }
    }

    public class WareHouse : IPositionable {
        protected GPSPosition _myPosition;

        public GPSPosition GetCurrentGPSPosition() {
            return _myPosition;

        }
    }

}