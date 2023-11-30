//Software Development Lifecycle
using System;

abstract class SoftwareDevelopmentProcess
{
    public void Execute()
    {
        PlanProject();
        ImplementCode();
        TestSoftware();
        DeploySoftware();
    }

    protected void PlanProject()
    {
        Console.WriteLine("Planning the software development project");
    }

    protected void DeploySoftware()
    {
        Console.WriteLine("Deploying the software");
    }
    protected abstract void ImplementCode();
    protected abstract void TestSoftware();
}

class AgileDevelopmentProcess : SoftwareDevelopmentProcess
{
    protected override void ImplementCode()
    {
        Console.WriteLine("Using iterative and incremental development");
    }

    protected override void TestSoftware()
    {
        Console.WriteLine("Performing continuous testing throughout development");
    }
}

class WaterfallDevelopmentProcess : SoftwareDevelopmentProcess
{
    protected override void ImplementCode()
    {
        Console.WriteLine("Following a sequential development approach");
    }

    protected override void TestSoftware()
    {
        Console.WriteLine("Conducting testing after the completion of coding phase");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Executing Agile development process:");
        var agileProcess = new AgileDevelopmentProcess();
        agileProcess.Execute();

        Console.WriteLine("\nExecuting Waterfall development process:");
        var waterfallProcess = new WaterfallDevelopmentProcess();
        waterfallProcess.Execute();
    }
}
