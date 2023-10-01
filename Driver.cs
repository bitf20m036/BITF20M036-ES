using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1
{
    public class Driver
    {
        public int Id;
        public string name;
        public int age;
        public string gender;
        public string address;
        public string phoneNo;
        public Location currLocation;
        public Vehicle vehicle;
        public List<int> rating= new List<int>();
        public bool availability=true;
        private static int startingId = 1;

        public Driver()
        {
        }
        public Driver(string Name, int Age, string Gender, string Address, string vehicleType, string vehicleModel, string vehicleLicensePlate)
        {
            Id = startingId++;
            name = Name;
            age = Age;
            gender = Gender;
            address = Address;
            vehicle = new Vehicle(vehicleType, vehicleModel, vehicleLicensePlate);
        }
        public void updateAvailability(bool isAvailable)
        {
            availability = isAvailable;
            Console.WriteLine("Availability updated");
        }
        public double getRating()
        {
            if (rating.Count == 0)
                return 0.0;

            return rating.Average();
        }
        public void UpdateLocation(float latitude, float longitude)
        {
            currLocation = new Location(latitude, longitude);
            Console.WriteLine("Location updated");
        }


    }
}
