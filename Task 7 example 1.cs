//Coffee Shop with Decorators
using System;
interface ICoffee
{
    string GetDescription();
    double Cost();
}
class SimpleCoffee : ICoffee
{
    public string GetDescription()
    {
        return "Simple Coffee";
    }

    public double Cost()
    {
        return 2.0;
    }
}
abstract class CoffeeDecorator : ICoffee
{
    protected ICoffee decoratedCoffee;

    protected CoffeeDecorator(ICoffee coffee)
    {
        decoratedCoffee = coffee;
    }

    public virtual string GetDescription()
    {
        return decoratedCoffee.GetDescription();
    }

    public virtual double Cost()
    {
        return decoratedCoffee.Cost();
    }
}
class MilkDecorator : CoffeeDecorator
{
    public MilkDecorator(ICoffee coffee) : base(coffee) { }

    public override string GetDescription()
    {
        return $"{base.GetDescription()}, with Milk";
    }

    public override double Cost()
    {
        return base.Cost() + 0.5;
    }
}

class SugarDecorator : CoffeeDecorator
{
    public SugarDecorator(ICoffee coffee) : base(coffee) { }

    public override string GetDescription()
    {
        return $"{base.GetDescription()}, with Sugar";
    }

    public override double Cost()
    {
        return base.Cost() + 0.2;
    }
}
class Program
{
    static void Main()
    {
        ICoffee coffee = new SimpleCoffee();
        Console.WriteLine($"Description: {coffee.GetDescription()}, Cost: ${coffee.Cost()}");

        coffee = new MilkDecorator(coffee);
        Console.WriteLine($"Description: {coffee.GetDescription()}, Cost: ${coffee.Cost()}");

        coffee = new SugarDecorator(coffee);
        Console.WriteLine($"Description: {coffee.GetDescription()}, Cost: ${coffee.Cost()}");
    }
}
