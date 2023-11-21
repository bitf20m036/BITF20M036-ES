//vehicleFactory
using System;


public interface IVehicle
{
    void DisplayInfo();
}
public class Car : IVehicle
{
    public void DisplayInfo()
    {
        Console.WriteLine("This is a Car.");
    }
}

public class Motorcycle : IVehicle
{
    public void DisplayInfo()
    {
        Console.WriteLine("This is a Motorcycle.");
    }
}
public interface IVehicleFactory
{
    IVehicle CreateVehicle();
}
public class CarFactory : IVehicleFactory
{
    public IVehicle CreateVehicle()
    {
        return new Car();
    }
}

public class MotorcycleFactory : IVehicleFactory
{
    public IVehicle CreateVehicle()
    {
        return new Motorcycle();
    }
}
public class Program
{
    public static void Main()
    {
        IVehicleFactory carFactory = new CarFactory();
        IVehicle car = carFactory.CreateVehicle();
        car.DisplayInfo(); 

        IVehicleFactory motorcycleFactory = new MotorcycleFactory();
        IVehicle motorcycle = motorcycleFactory.CreateVehicle();
        motorcycle.DisplayInfo(); 
    }
}