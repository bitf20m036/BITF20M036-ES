//FurnitureFactory
using System;

public interface IChair
{
    void Create();
}

public interface ITable
{
    void Create();
}

public class ModernChair : IChair
{
    public void Create()
    {
        Console.WriteLine("Creating a Modern Chair.");
    }
}

public class ModernTable : ITable
{
    public void Create()
    {
        Console.WriteLine("Creating a Modern Table.");
    }
}

public class VictorianChair : IChair
{
    public void Create()
    {
        Console.WriteLine("Creating a Victorian Chair.");
    }
}

public class VictorianTable : ITable
{
    public void Create()
    {
        Console.WriteLine("Creating a Victorian Table.");
    }
}
public interface IFurnitureFactory
{
    IChair CreateChair();
    ITable CreateTable();
}
public class ModernFurnitureFactory : IFurnitureFactory
{
    public IChair CreateChair()
    {
        return new ModernChair();
    }

    public ITable CreateTable()
    {
        return new ModernTable();
    }
}

public class VictorianFurnitureFactory : IFurnitureFactory
{
    public IChair CreateChair()
    {
        return new VictorianChair();
    }

    public ITable CreateTable()
    {
        return new VictorianTable();
    }
}
public class Program
{
    public static void Main()
    {
        IFurnitureFactory modernFactory = new ModernFurnitureFactory();
        IChair modernChair = modernFactory.CreateChair();
        ITable modernTable = modernFactory.CreateTable();

        modernChair.Create();  
        modernTable.Create(); 

        IFurnitureFactory victorianFactory = new VictorianFurnitureFactory();
        IChair victorianChair = victorianFactory.CreateChair();
        ITable victorianTable = victorianFactory.CreateTable();

        victorianChair.Create();  
        victorianTable.Create();  
    }
}