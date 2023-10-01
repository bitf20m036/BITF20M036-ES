using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1
{
    public class Admin
    {
        public List<Driver> Drivers;

        public Admin()
        {
            Drivers = new List<Driver>();
        }
        public void AddDriver()
        {
            Console.WriteLine("Add a new Driver");
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Age: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Enter Gender: ");
            string gender = Console.ReadLine();
            Console.Write("Enter Address: ");
            string address = Console.ReadLine();
            Console.Write("Enter Vehicle Type (Car/Bike/Rickshaw): ");
            string vehicleType = Console.ReadLine();
            Console.Write("Enter Vehicle Model: ");
            string vehicleModel = Console.ReadLine();
            Console.Write("Enter Vehicle License Plate: ");
            string licensePlate = Console.ReadLine();

            Driver driver = new Driver(name, age, gender, address, vehicleType, vehicleModel, licensePlate);
            Drivers.Add(driver);

            Console.WriteLine("Driver added successfully!");
        }

        public void UpdateDriver()
        {
            Console.WriteLine("Enter driver ID to update: ");
            int driverId;
            int.TryParse(Console.ReadLine(), out driverId);

            Driver driverToUpdate = Drivers.FirstOrDefault(d => d.Id == driverId);
            if (driverToUpdate == null)
            {
                Console.WriteLine("Driver not found!!!");
                return;
            }
       
                Console.WriteLine($"Editing driver: {driverToUpdate.name}");
                Console.WriteLine("Select a field to update:");
                Console.WriteLine("1. Name");
                Console.WriteLine("2. Age");
                Console.WriteLine("3. Gender");
                Console.WriteLine("4. Address");
                Console.WriteLine("5. Phone Number");
                Console.WriteLine("6. Current Location");
                Console.WriteLine("7. Vehicle Type");
                Console.WriteLine("8. Vehicle Model");
                Console.WriteLine("9. Vehicle License Plate");
                int.TryParse(Console.ReadLine(), out int choice);

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter new name: ");
                    driverToUpdate.name = Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("Enter new age: ");
                    int.TryParse(Console.ReadLine(), out int age);
                    driverToUpdate.age = age;
                    break;
                case 3:
                    Console.WriteLine("Enter new gender: ");
                    driverToUpdate.gender = Console.ReadLine();
                    break;
                case 4:
                    Console.WriteLine("Enter new address: ");
                    driverToUpdate.address = Console.ReadLine();
                    break;
                case 5:
                    Console.WriteLine("Enter new phone number (digits only): ");
                    driverToUpdate.phoneNo = Console.ReadLine();
                    break;
                case 6:
                    Console.WriteLine("Enter new current location (latitude): ");
                    float.TryParse(Console.ReadLine(), out float latitude);
                    Console.WriteLine("Enter new current location (longitude): ");
                    float.TryParse(Console.ReadLine(), out float longitude);
                    driverToUpdate.currLocation = new Location { latitude = latitude, longitude = longitude };
                    break;
                case 7:
                    Console.WriteLine("Enter new vehicle type (Car, Bike, Rickshaw): ");
                    driverToUpdate.vehicle.Type = Console.ReadLine();
                    break;
                case 8:
                    Console.WriteLine("Enter new vehicle model: ");
                    driverToUpdate.vehicle.model = Console.ReadLine();
                    break;
                case 9:
                    Console.WriteLine("Enter new vehicle license plate: ");
                    driverToUpdate.vehicle.licensePlate = Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

            Console.WriteLine("Driver updated successfully!!!");
        }

        public void RemoveDriver()
        {
            Console.WriteLine("Enter driver ID to remove: ");
            int driverId;
            int.TryParse(Console.ReadLine(), out driverId);

            Driver driverToRemove = Drivers.FirstOrDefault(d => d.Id == driverId);
            if (driverToRemove == null)
            {
                Console.WriteLine("Driver not found.");
                return;
            }

            Drivers.Remove(driverToRemove);
            Console.WriteLine("Driver removed successfully!");
        }

        public void SearchDriver()
        {
            Console.WriteLine("Search Driver");
            Console.Write("Enter Driver ID: ");
            int driverId = int.Parse(Console.ReadLine());
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Age: ");
            int age;
            int.TryParse(Console.ReadLine(), out age);
            Console.Write("Enter Gender: ");
            string gender = Console.ReadLine();
            Console.Write("Enter Vehicle Type (Car/Bike/Rickshaw): ");
            string vehicleType = Console.ReadLine();
            Console.Write("Enter Vehicle Model: ");
            string vehicleModel = Console.ReadLine();
            Console.Write("Enter Vehicle License Plate: ");
            string licensePlate = Console.ReadLine();

            var filteredDrivers = Drivers.Where(d =>
            (driverId == 0 || d.Id == driverId) &&
            (string.IsNullOrEmpty(name) || d.name == name) &&
            (age == 0 || d.age == age) &&
            (string.IsNullOrEmpty(gender) || d.gender == gender) &&
            (string.IsNullOrEmpty(vehicleType) || d.vehicle.Type == vehicleType) &&
            (string.IsNullOrEmpty(vehicleModel) || d.vehicle.model == vehicleModel) &&
            (string.IsNullOrEmpty(licensePlate) || d.vehicle.licensePlate == licensePlate)
        );


            if (filteredDrivers.Any())
            {
                Console.WriteLine("-------------------------------------------------------------------------");
                Console.WriteLine("Name     Age   Gender    Type    Model    License");
                Console.WriteLine("-------------------------------------------------------------------------");
                foreach (var driver in filteredDrivers)
                {
                    Console.WriteLine($"{driver.name}     {driver.age}     {driver.gender}     {driver.vehicle.Type}     {driver.vehicle.model}     {driver.vehicle.licensePlate}");
                }
                Console.WriteLine("-------------------------------------------------------------------------");
            }
            else
            {
                Console.WriteLine("No driver found!!!.");
            }
        }
    }

}