//Virtual Proxy for Expensive Objects
using System;
public interface IExpensiveObject
{
    void Process();
}
public class ExpensiveObject : IExpensiveObject
{
    public ExpensiveObject()
    {
        Console.WriteLine("Expensive object created");
    }

    public void Process()
    {
        Console.WriteLine("Processing expensive object");
    }
}
public class VirtualProxy : IExpensiveObject
{
    private ExpensiveObject realObject;

    public void Process()
    {
        // Create the real object only when needed
        if (realObject == null)
        {
            realObject = new ExpensiveObject();
        }

        realObject.Process();
    }
    public static void Main()
    {
        var proxy = new VirtualProxy();
        proxy.Process();
    }
}
