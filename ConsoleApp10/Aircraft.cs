using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    public class Aircraft : Vehicle
    {
        public delegate void AccountHandler(string message);
        public event AccountHandler Notify;
        public event AccountHandler Notify1;
        public static void DisplayMessage1(string message) => Console.WriteLine("Включення мотора");
        public static void DisplayMessage2(string message) => Console.WriteLine("Розгон");
        public static void DisplayMessage3(string message) => Console.WriteLine("Зліт");
        public static void DisplayMessage4(string message) => Console.WriteLine("Приземлення");
        public static void DisplayMessage5(string message) => Console.WriteLine("Гальмування");
        public static void DisplayMessage6(string message) => Console.WriteLine(message);
        public string model { get; set; }
        public string producer { get; set; }
        public int graduationYear { get; set; }
        public Engine engine { get; set; }
        public TypeAircraft typeAircraft { get; set; }
        public List<Pilot> pilot { get; set; }
        public Airport airport { get; set; }


        public Aircraft(TypeAircraft typeAircraft, string model , string producer, int graduationYear, Engine engine, List<Pilot> pilot, Airport Airport, string Name, int Id) : base(Name, Id)
        {
            Notify = DisplayMessage1;
            Notify += DisplayMessage2;
            Notify += DisplayMessage3;
            Notify1 = DisplayMessage6;
            this.airport = Airport;
            this.model = model; 
            this.producer = producer;
            this.graduationYear = graduationYear;
            this.typeAircraft = typeAircraft;
            this.engine = engine;  
            this.pilot = pilot;
            this.graduationYear = graduationYear;
        }
        public override void move()
        {

            Notify1.Invoke("Приземлення");
            Notify1.Invoke("Гальмування");
        }

        public  void move(Airport _airport)
        {
            if (_airport != airport) {
                Notify.Invoke("");
                pilot[0].Piloting(_airport);
                Notify1.Invoke("Приземлення");
                Notify1.Invoke("Гальмування");
                airport = _airport;
            }
            else
            {
                Console.WriteLine("Літак уже знаходиться у цьому аеропорту");
            }
        }


        public override string ToString()
        {
            string message = $"Літак {typeAircraft} {model} від {producer}, рік випуску {graduationYear} з бортовим номером {id}.";
            message += $" Має {engine.name} двигун.";
            message += $" Знаходиться зараз в {airport.name} в {airport.location}";
            return message;
        }


    }
}
