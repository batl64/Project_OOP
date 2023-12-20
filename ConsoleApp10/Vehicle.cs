using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    public abstract class Vehicle
    {
        public int id { get; set; }
        public string name { get; set; }


        public Vehicle(string Name, int Id)
        {
            name = Name;
            id = Id;
        }


        public abstract void move();
    }
}
