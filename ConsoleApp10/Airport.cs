using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    public class Airport
    {
        public string name { get; set; }
        public string location { get; set; }

        public Airport(string Name, string Location)
        {
            name = Name;
            location = Location;
        }
    }
}
