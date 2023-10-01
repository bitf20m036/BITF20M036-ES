using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace project1
{
    public class Ride
    {
        public Location startLocation;
        public Location endLocation;
        public int price;
        public Driver driver;
        public Passenger passenger;
        public string Rtype;
        public int rating;

        public Ride(Location StartLocation, Location EndLocation,string rideType,Passenger Passenger)
        {
            startLocation = StartLocation;
            endLocation = EndLocation;
            price = 0;
            driver = null;
            passenger = Passenger;
            Rtype = rideType;
        }
        public Ride(Location StartLocation, Location EndLocation)
        {
            startLocation = StartLocation;
            endLocation = EndLocation;
        }
        public void assignPassenger(Passenger Passenger)
        {
            passenger = Passenger;
        }

        public void assignDriver(List<Driver> drivers)
        {
       
            List<Driver> availableDrivers = drivers.Where(d => d.availability).ToList();

            if (availableDrivers.Count == 0)
            {
                Console.WriteLine("No available drivers at the moment.");
                return;
            }
            double shortestDistance = double.MaxValue;
            Driver closestDriver = null;

            foreach (Driver driver in availableDrivers)
            {
                double distance = CalculateDistance(startLocation, driver.currLocation);
                if (distance < shortestDistance)
                {
                    shortestDistance = distance;
                    closestDriver = driver;
                }
            }

            if (closestDriver != null)
            {
                driver = closestDriver;
                Console.WriteLine($"Driver {driver.name} assigned to this ride.");
            }
            else
            {
                Console.WriteLine("No available drivers near your location.");
            }
        }

        public void getLocations(out Location start, out Location end)
        {
            start = startLocation;
            end = endLocation;
        }

        public void CalculatePrice()
        {
          
            double fuelPrice = 2.0; 
            double fuelAverage = 15.0; 

            double distance = CalculateDistance(startLocation,endLocation);

            double commission = 0.0;
            if (Rtype == "Bike")
            {
                commission = 0.05;
            }
            else if (Rtype == "Rickshaw")
            {
                commission = 0.10;
            }
            else if (Rtype == "Car")
            {
                commission = 0.20;
            }

            price = Convert.ToInt32((distance * fuelPrice / fuelAverage) + commission);
        }


        private double CalculateDistance(Location location1, Location location2)
        {
            double lat1 = location1.latitude;
            double lon1 = location1.longitude;
            double lat2 = location2.latitude;
            double lon2 = location2.longitude;

            double theta = lon1 - lon2;
            double dist = Math.Sin(DegreeToRadian(lat1)) * Math.Sin(DegreeToRadian(lat2)) +
                          Math.Cos(DegreeToRadian(lat1)) * Math.Cos(DegreeToRadian(lat2)) * Math.Cos(DegreeToRadian(theta));
            dist = Math.Acos(dist);
            dist = RadianToDegree(dist);
            dist = dist * 60 * 1.1515 * 1.609344;

            return dist;
        }

        private double DegreeToRadian(double degree)
        {
            return degree * Math.PI / 180.0;
        }

        private double RadianToDegree(double radian)
        {
            return radian * 180.0 / Math.PI;
        }
    }

}
