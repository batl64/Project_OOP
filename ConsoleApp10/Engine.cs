using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    public class Engine
    {
        public string name { get; set; }
        public string type { get; set; }
        public double power { get; set; }

        public Engine(string Name, string Type, double Power) {
            name = Name;
            type = Type;
            power = Power;
        }
    }
}
