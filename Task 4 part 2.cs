//ComputerBuilder
using System;
public class Computer
{
    private string cpu;
    private string ram;
    private string storage;
    private string graphicsCard;

    public Computer(string cpu, string ram, string storage, string graphicsCard)
    {
        this.cpu = cpu;
        this.ram = ram;
        this.storage = storage;
        this.graphicsCard = graphicsCard;
    }

    public void Display()
    {
        Console.WriteLine("Computer Specifications:\nCPU: " + cpu + "\nRAM: " + ram + "\nStorage: " + storage + "\nGraphics Card: " + graphicsCard);
    }
}


public interface IComputerBuilder
{
    void BuildCPU();
    void BuildRAM();
    void BuildStorage();
    void BuildGraphicsCard();
    Computer GetComputer();
}


public class GamingComputerBuilder : IComputerBuilder
{
    private Computer computer;

    public GamingComputerBuilder()
    {
        computer = new Computer("Intel Core i7", "16GB", "1TB SSD", "NVIDIA GeForce RTX 3080");
    }

    public void BuildCPU()
    {
        // No additional CPU customization for gaming computer
    }

    public void BuildRAM()
    {
        // No additional RAM customization for gaming computer
    }

    public void BuildStorage()
    {
        // No additional storage customization for gaming computer
    }

    public void BuildGraphicsCard()
    {
        // No additional graphics card customization for gaming computer
    }

    public Computer GetComputer()
    {
        return computer;
    }
}

public class OfficeComputerBuilder : IComputerBuilder
{
    private Computer computer;

    public OfficeComputerBuilder()
    {
        computer = new Computer("Intel Core i5", "8GB", "512GB SSD", "Integrated Graphics");
    }

    public void BuildCPU()
    {
        // No additional CPU customization for office computer
    }

    public void BuildRAM()
    {
        // No additional RAM customization for office computer
    }

    public void BuildStorage()
    {
        // No additional storage customization for office computer
    }

    public void BuildGraphicsCard()
    {
        // No additional graphics card customization for office computer
    }

    public Computer GetComputer()
    {
        return computer;
    }
}


public class ComputerDirector
{
    public void Construct(IComputerBuilder builder)
    {
        builder.BuildCPU();
        builder.BuildRAM();
        builder.BuildStorage();
        builder.BuildGraphicsCard();
    }
}
public class Program
{
    public static void Main()
    {
        ComputerDirector computerDirector = new ComputerDirector();

        IComputerBuilder gamingComputerBuilder = new GamingComputerBuilder();
        computerDirector.Construct(gamingComputerBuilder);
        Computer gamingComputer = gamingComputerBuilder.GetComputer();
        gamingComputer.Display();

        Console.WriteLine();

        IComputerBuilder officeComputerBuilder = new OfficeComputerBuilder();
        computerDirector.Construct(officeComputerBuilder);
        Computer officeComputer = officeComputerBuilder.GetComputer();
        officeComputer.Display();
    }
}