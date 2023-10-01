using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace project1
{
    class Program
    {
        public static List<Ride> Rides = new List<Ride>();
        static List<Driver> drivers = new List<Driver>();
        static List<Passenger> passengers = new List<Passenger>();
        static Admin admin = new Admin();
        static void Main(string[] args)
        {
            while (true)
            {
                //Console.Clear();
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("WELCOME TO MY RIDE");
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("1. Book a Ride");
                Console.WriteLine("2. Enter as Driver");
                Console.WriteLine("3. Enter as Admin");
                Console.WriteLine("4. Exit");
                Console.Write("Press 1 to 3 to select an option: ");

                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        BookARide();
                        break;
                    case 2:
                        EnterAsDriver();
                        break;
                    case 3:
                        EnterAsAdmin();
                        break;
                    case 4:
                        Console.WriteLine("Exit");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
        static void BookARide()
        {
            
            Console.WriteLine("Book a Ride");
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Phone no: ");
            string phoneNo = Console.ReadLine();
            Console.Write("Enter Start Location (latitude, longitude): ");
            string[] startLocationInput = Console.ReadLine().Split(',');
            float startLatitude = float.Parse(startLocationInput[0]);
            float startLongitude = float.Parse(startLocationInput[1]);
            Location startLocation = new Location(startLatitude, startLongitude);
            Console.Write("Enter End Location (latitude, longitude): ");
            string[] endLocationInput = Console.ReadLine().Split(',');
            float endLatitude = float.Parse(endLocationInput[0]);
            float endLongitude = float.Parse(endLocationInput[1]);
            Location endLocation = new Location(endLatitude, endLongitude);
            Console.Write("Enter Ride Type: ");
            string rideType = Console.ReadLine();
            int price = 200;

            Console.WriteLine("Price for this ride is: " + price);
            Console.Write("Enter 'Y' to Book the ride, 'N' to cancel: ");
            string bookChoice = Console.ReadLine();
            if (bookChoice.ToUpper() == "Y")
            {
                Console.WriteLine("Happy Travel...!");
                Console.Write("Give rating out of 5: ");
                int rating = int.Parse(Console.ReadLine());

                Passenger passenger = new Passenger(name, phoneNo);
                Ride ride = new Ride(startLocation, endLocation);
                ride.assignPassenger(passenger);
                ride.CalculatePrice();
                ride.rating = rating;
                Rides.Add(ride);

                Console.WriteLine("Ride booked successfully.");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static void EnterAsDriver()
        {
            Console.WriteLine("Enter as Driver");
            Console.Write("Enter ID: ");
            int driverId = int.Parse(Console.ReadLine());
            Console.Write("Enter Name: ");
            string Name = Console.ReadLine();
            Driver driver = admin.Drivers.FirstOrDefault(d => d.Id == driverId && d.name == Name);

            if (driver != null)
            {
                Console.WriteLine($"Hello {driver.name}!");
                Console.Write("Enter your current Location (latitude, longitude): ");
                string[] location = Console.ReadLine().Split(',');
                driver.UpdateLocation(float.Parse(location[0]), float.Parse(location[1]));

                while (true)
                {
                    Console.WriteLine("Driver Options:");
                    Console.WriteLine("1. Change availability");
                    Console.WriteLine("2. Change Location");
                    Console.WriteLine("3. Exit as Driver");
                    Console.WriteLine("Press 1 to 3 to select an option:");

                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            driver.updateAvailability(true);
                            break;
                        case 2:
                            Console.Write("Enter your current Location (latitude, longitude): ");
                            string[] newLocation = Console.ReadLine().Split(',');
                            driver.UpdateLocation(float.Parse(newLocation[0]), float.Parse(newLocation[1]));
                            break;
                        case 3:
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please select a valid option.");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Driver not found. Please check your ID and Name.");
            }
        }
        static void EnterAsAdmin()
        {
            Console.WriteLine("Enter as Admin");
            Console.Write("Enter Admin Password: ");
            string adminPassword = Console.ReadLine();

            bool isAdminAuthenticated = true;

            if (!isAdminAuthenticated)
            {
                Console.WriteLine("Admin authentication failed.");
                Console.WriteLine("Press any key to return to the main menu...");
                Console.ReadKey();
                return;
            }

            while (true)
            {
                Console.WriteLine("Enter as Admin:");
                Console.WriteLine("1. Add Driver");
                Console.WriteLine("2. Remove Driver");
                Console.WriteLine("3. Update Driver");
                Console.WriteLine("4. Search Driver");
                Console.WriteLine("5. Exit as Admin");
                Console.Write("Select an option (1-5): ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        admin.AddDriver();
                        break;
                    case 2:
                        admin.RemoveDriver();
                        break;
                    case 3:
                        admin.UpdateDriver();
                        break;
                    case 4:
                        admin.SearchDriver();
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
        }

    }

}

