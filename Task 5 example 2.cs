//Computer Startup Facade
using System;
public class CPU
{
    public void Start() => Console.WriteLine("CPU: Starting");
}

public class Memory
{
    public void Load() => Console.WriteLine("Memory: Loading data");
}

public class HardDrive
{
    public void Read() => Console.WriteLine("Hard Drive: Reading data");
}
public class ComputerFacade
{
    private readonly CPU cpu;
    private readonly Memory memory;
    private readonly HardDrive hardDrive;

    public ComputerFacade()
    {
        cpu = new CPU();
        memory = new Memory();
        hardDrive = new HardDrive();
    }

    public void StartComputer()
    {
        Console.WriteLine("Starting the computer...");
        cpu.Start();
        memory.Load();
        hardDrive.Read();
        Console.WriteLine("Computer started successfully.");
    }
}
class Program
{
    static void Main()
    {
        var computerFacade = new ComputerFacade();
        computerFacade.StartComputer();
    }
}
