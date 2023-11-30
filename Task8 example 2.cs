//Visitor for Computer Parts
using System;
using System.Collections.Generic;
interface IComputerPart
{
    void Accept(IComputerPartVisitor visitor);
}
class Keyboard : IComputerPart
{
    public void Accept(IComputerPartVisitor visitor)
    {
        visitor.VisitKeyboard(this);
    }
}

class Monitor : IComputerPart
{
    public void Accept(IComputerPartVisitor visitor)
    {
        visitor.VisitMonitor(this);
    }
}
interface IComputerPartVisitor
{
    void VisitKeyboard(Keyboard keyboard);
    void VisitMonitor(Monitor monitor);
}
class RepairVisitor : IComputerPartVisitor
{
    public void VisitKeyboard(Keyboard keyboard)
    {
        Console.WriteLine("Repairing Keyboard");
    }

    public void VisitMonitor(Monitor monitor)
    {
        Console.WriteLine("Repairing Monitor");
    }
}
class Client
{
    static void Main()
    {
        var computerParts = new List<IComputerPart> { new Keyboard(), new Monitor() };
        var repairVisitor = new RepairVisitor();

        foreach (var computerPart in computerParts)
        {
            computerPart.Accept(repairVisitor);
        }
    }
}
