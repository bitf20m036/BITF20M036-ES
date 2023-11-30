//Traffic Light Controller
using System;
using System.Collections.Generic;
interface ITrafficLight
{
    void AddObserver(IDriver observer);
    void RemoveObserver(IDriver observer);
    void NotifyObservers(TrafficLightColor color);
}
interface IDriver
{
    void Update(TrafficLightColor color);
}
enum TrafficLightColor
{
    Red,
    Yellow,
    Green
}
class TrafficLight : ITrafficLight
{
    private List<IDriver> drivers = new List<IDriver>();
    private TrafficLightColor currentColor;

    public void AddObserver(IDriver driver)
    {
        drivers.Add(driver);
    }

    public void RemoveObserver(IDriver driver)
    {
        drivers.Remove(driver);
    }

    public void NotifyObservers(TrafficLightColor color)
    {
        foreach (var driver in drivers)
        {
            driver.Update(color);
        }
    }

    public void ChangeColor(TrafficLightColor newColor)
    {
        if (newColor != currentColor)
        {
            currentColor = newColor;
            NotifyObservers(currentColor);
        }
    }
}

class CarDriver : IDriver
{
    private readonly string name;

    public CarDriver(string name)
    {
        this.name = name;
    }

    public void Update(TrafficLightColor color)
    {
        Console.WriteLine($"{name}'s car sees {color} light");
    }
}

class Program
{
    static void Main()
    {
        var trafficLight = new TrafficLight();

        var driver1 = new CarDriver("Driver 1");
        var driver2 = new CarDriver("Driver 2");

        trafficLight.AddObserver(driver1);
        trafficLight.AddObserver(driver2);

        trafficLight.ChangeColor(TrafficLightColor.Green);
        Console.WriteLine();

        trafficLight.ChangeColor(TrafficLightColor.Red);
    }
}
