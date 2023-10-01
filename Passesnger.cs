using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1
{
    public class Passenger
    {
        public string name;
        public string phoneNo;

    public Passenger(string Name, string PhoneNo)
        {
            name = Name;
            phoneNo = PhoneNo;
        }

        public void bookRide()
        {
            Console.WriteLine("Enter Starting Location (latitude, longitude): ");
            string[] startLocationInput = Console.ReadLine().Split(',');
            float startLatitude = float.Parse(startLocationInput[0]);
            float startLongitude = float.Parse(startLocationInput[1]);
            Location startLocation = new Location(startLatitude, startLongitude);

            Console.WriteLine("Enter Ending Location (latitude, longitude): ");
            string[] endLocationInput = Console.ReadLine().Split(',');
            float endLatitude = float.Parse(endLocationInput[0]);
            float endLongitude = float.Parse(endLocationInput[1]);
            Location endLocation = new Location(endLatitude, endLongitude);

            Ride newRide = new Ride(startLocation, endLocation);
            Program.Rides.Add(newRide);

            Console.WriteLine("Ride booked successfully.");
        }

        public void giveRating(int rating)
        {
            if (rating < 1 || rating > 5)
            {
                Console.WriteLine("Invalid rating. Please provide a rating between 1 and 5.");
                return;
            }
            if (Program.Rides.Count > 0)
            {
                Program.Rides[Program.Rides.Count - 1].rating = rating;
                Console.WriteLine("Rating submitted successfully.");
            }
            else
            {
                Console.WriteLine("No ride to rate.");
            }
        }
    }

}
