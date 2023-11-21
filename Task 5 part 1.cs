//copy constructor
using System;

public interface ICloneableItem
{
    ICloneableItem Clone();
    void Display();
}

public class Car : ICloneableItem
{
    public string Model { get; set; }
    public string Color { get; set; }

    public Car(string model, string color)
    {
        Model = model;
        Color = color;
    }
    public Car(Car original)
    {
        Model = original.Model;
        Color = original.Color;
    }

    public ICloneableItem Clone()
    {
        return new Car(this);
    }

    public void Display()
    {
        Console.WriteLine("Car: " + Color + " " + Model);
    }
}
public class Smartphone : ICloneableItem
{
    public string Brand { get; set; }
    public string OperatingSystem { get; set; }

    public Smartphone(string brand, string operatingSystem)
    {
        Brand = brand;
        OperatingSystem = operatingSystem;
    }
    public Smartphone(Smartphone original)
    {
        Brand = original.Brand;
        OperatingSystem = original.OperatingSystem;
    }

    public ICloneableItem Clone()
    {
        return new Smartphone(this);
    }

    public void Display()
    {
        Console.WriteLine("Smartphone: " + Brand + " with " + OperatingSystem);
    }
}
public class PrototypeClient
{
    public static void Main()
    {
        ICloneableItem carPrototype = new Car("Sedan", "Blue");
        ICloneableItem carClone = carPrototype.Clone();
        carClone.Display();

        ICloneableItem phonePrototype = new Smartphone("Samsung", "Android");
        ICloneableItem phoneClone = phonePrototype.Clone();
        phoneClone.Display();
    }
}