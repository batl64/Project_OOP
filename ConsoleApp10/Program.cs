using static System.Net.Mime.MediaTypeNames;
using System;
using Microsoft.VisualBasic;
using System.Xml.Linq;

namespace ConsoleApp10
{


    class Program
    {
        public static void Message(string air)
        {
            Console.WriteLine($"Літак видалено: {air}");
        }



        public delegate void MyDelegate(string message);

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode; 

            List<Aircraft> airFleet = new List<Aircraft>() { new Aircraft(TypeAircraft.BusinessJet, "Boeing 747", "Boeing", 2020, new Engine("V8", "реактивний", 100000), new List<Pilot> { new Pilot("PIB", 50, 10000) }, new Airport("tt", "Kyiv"), "AN-222", 1), new Aircraft(TypeAircraft.BusinessJet, "Boeing 747", "Boeing", 2020, new Engine("V8", "реактивний", 100000), new List<Pilot> { new Pilot("PIB", 50, 10000) }, new Airport("tt", "Kyiv"), "AN-223", 2) 
       };
            List<Airport> airport = new List<Airport>() { new Airport("N1", "Kyiv"), new Airport("N2", "Ankara"), };
            bool exit = false, exit1 = false ;
            Airport air = new Airport("N1", "Kyiv");
            Engine eng = new Engine("V8","Турбо реактивний",50000);
            TypeAircraft type = TypeAircraft.CargoAircraft;
            Pilot pl = new Pilot("Joen Doe",25,10000);
            int menu = 0, num, size = 0, variant, inv = 0,count=3, year=0,pilotAge=0, flyTime=0;

            string text, prod, name, model, pilotName, text1;

            MyDelegate myDelegate = Message;
       

            while (!exit)
            {
                Console.WriteLine("\n1. додати об’єкт");
                Console.WriteLine("2. вивести на екран об’єкти");
                Console.WriteLine("3. видалити об’єкт");
                Console.WriteLine("4. демонстрація поведінки");
                Console.WriteLine("5. очистити колекцію літаків");
                Console.WriteLine("6. Додати аеропорт");
                Console.WriteLine("0. Вихід\n");


                text = Console.ReadLine();
                menu = int.TryParse(text, out num) ? int.Parse(text) :  33333;
                switch (menu)
                {

                    case 1:
                        Console.WriteLine($"Введи назву борту");
                        name = Console.ReadLine();

                  

                        exit1 = false;
                        while (!exit1)
                        {
                            foreach (TypeAircraft f in Enum.GetValues(typeof(TypeAircraft)))
                            {
                                Console.WriteLine(size++ + ". " + f);
                            }
                            Console.WriteLine($"Введи тип борту ");
                            text = Console.ReadLine();
                            if (Enum.TryParse(text, out type))
                            {
                                exit1 = true;
                            }
                        }
                            Console.WriteLine($"Введи  модель борту");
                        model = Console.ReadLine();


                        Console.WriteLine($"Введи назву виробника");
                        prod = Console.ReadLine();

                        exit1 = false;
                        while (!exit1)
                        {
                            Console.WriteLine($"Введи назву рік випуску борту");
                            text = Console.ReadLine();

                                if (int.TryParse(text, out num))
                                {
                                    year = num;
                                    exit1 = true;
                                }
                            
                        }

                        Console.WriteLine($"Введи назву ПІБ пілота");
                        pilotName = Console.ReadLine();

                        exit1 = false;
                        while (!exit1)
                        {
                            Console.WriteLine($"Введи години налета");
                            text = Console.ReadLine();

                            if (int.TryParse(text, out num))
                            {

                                flyTime = num;
                                exit1 = true;
                            }

                        }

                        exit1 = false;
                        while (!exit1)
                        {
                            Console.WriteLine($"Введи вік пілота");
                            text = Console.ReadLine();

                            if (int.TryParse(text, out num))
                            {
                                pl = new Pilot(pilotName, num, flyTime);

                                exit1 = true;
                            }

                        }
                        exit1 = false;
                        while (!exit1)
                        {
                            Console.WriteLine($"Введи назву борту параметри мотору (назва тип потужність)");
                            text = Console.ReadLine();
                            if (text.Split(" ").Count() == 3)
                            {
                                string[] mas = text.Split(" ");
                                if (int.TryParse(mas[2], out num))
                                {
                                    eng = new Engine(mas[0], mas[1], num);
                                    exit1 = true;
                                }
                            }
                        }

                        foreach (var item in airport)
                        {
                            Console.WriteLine(item.name);
                        }
                        Console.WriteLine($"Введи назву аеропорту де знаходиметься літак");
                        exit1 = false;
                        while (!exit1)
                        {
                            text = Console.ReadLine();
                            if (airport.Where(el=>el.name == text).Count() >0)
                            {
                                air = airport.Where(el => el.name == text).First();
                                exit1 = true;
                            }
                        }
                            count++;
                        airFleet.Add(new Aircraft(type,model, prod, year, eng, new List<Pilot>{pl} , air, name,count));

                        break;
                    case 2:
                        foreach (var item in airFleet)
                        {
                            Console.WriteLine(item.ToString());
                        }
                        break;
                    case 3:
                        Console.WriteLine("Ввведіть бортовий номер для видалення літака з бази даних");
                        text = Console.ReadLine();
                        int.TryParse(text, out inv);
                        Aircraft  ff = airFleet.Where((el) => el.id == inv).First();
                        airFleet.RemoveAll((el) => el.id == inv);
                        myDelegate(ff.name);
                        break;
                    case 4:
             

                        do
                        {
                            Console.WriteLine("Ввведіть бортовий номер  літака з бази даних");
                            text = Console.ReadLine();
                        } while (!int.TryParse(text, out inv));

                        foreach(var item in airport)
                        {
                            Console.WriteLine(item.name);
                        }
                        exit1 = false;
                        do
                        {
                        Console.WriteLine("Ввведіть назву прельотного аеропорту");
                        text = Console.ReadLine();
                            if (airport.Where(x => x.name == text).Count() > 0)
                            {
                                exit1 = true;
                            }
                            } while (!exit1);
                        
                        airFleet.Where(x => x.id == inv).First().move(airport.Where(x => x.name == text).First());


                        break;
                    case 5: 
                        airFleet.Clear();
                    break;
                    case 6:
                        Console.WriteLine($"Введи назву аеропорту");
                        text = Console.ReadLine();


                        Console.WriteLine($"Введи місце знаходження аеропорту");
                        text1 = Console.ReadLine();

                        airport.Add(new Airport(text, text1));
                        break;

                        
                    case 0: exit = true; break;

                    default: Console.WriteLine("Введено не коректне значення при виборі меню"); break;
                }

                }
            }
    }
}
