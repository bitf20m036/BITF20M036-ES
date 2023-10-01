using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1
{
    public class Vehicle
    {
        public string Type;
        public string model;
        public string licensePlate;
        public Vehicle()
        {

        }
        public Vehicle(string type, string Model, string LicensePlate)
        {
            Type = type;
            model = Model;
            licensePlate = LicensePlate;
        }
    }

}
