//Online Shopping Order Processing
using System;

abstract class OrderProcessor
{
    public void ProcessOrder()
    {
        ValidateOrder();
        GenerateShippingLabel();
        DispatchShipment();
    }
    protected void ValidateOrder()
    {
        Console.WriteLine("Validating the order");
    }

    protected void DispatchShipment()
    {
        Console.WriteLine("Dispatching the shipment");
    }
    protected abstract void GenerateShippingLabel();
}

class PhysicalProductOrder : OrderProcessor
{
    protected override void GenerateShippingLabel()
    {
        Console.WriteLine("Generating shipping label for physical product");
    }
}

class DigitalProductOrder : OrderProcessor
{
    protected override void GenerateShippingLabel()
    {
        Console.WriteLine("No shipping label needed for digital product");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Processing physical product order:");
        var physicalOrder = new PhysicalProductOrder();
        physicalOrder.ProcessOrder();

        Console.WriteLine("\nProcessing digital product order:");
        var digitalOrder = new DigitalProductOrder();
        digitalOrder.ProcessOrder();
    }
}
