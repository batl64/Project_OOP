using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{


    public class Pilot : IPiloting, IPersonal
    {
        public delegate void AccountHandler(string message);
        public AccountHandler? Notify;
        public static void DisplayMessage(string message) => Console.WriteLine(message);
        public string pib { get; set; }
        public int age { get; set; }
        public int flightTimes { get; set; }

        public Pilot(string PIB,int age, int FlightTimes)
        {
            Notify = DisplayMessage;
            pib = PIB;
            this.age = age;
            flightTimes = FlightTimes;
        }

        public override string ToString()
        {
            return "Ім'я пілота "+ pib+" години пілотування "+ flightTimes;
        }

        public void Piloting( Airport airport) {

            
            Notify?.Invoke( $"Літак направляється в аєропорт " + airport.name);
        }
    }
}
