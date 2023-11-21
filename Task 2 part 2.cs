//shapeFactory
using System;

public interface IShape
{
    void Draw();
}
public class Circle : IShape
{
    public void Draw()
    {
        Console.WriteLine("Drawing a Circle.");
    }
}

public class Square : IShape
{
    public void Draw()
    {
        Console.WriteLine("Drawing a Square.");
    }
}
public interface IShapeFactory
{
    IShape CreateShape();
}
public class CircleFactory : IShapeFactory
{
    public IShape CreateShape()
    {
        return new Circle();
    }
}

public class SquareFactory : IShapeFactory
{
    public IShape CreateShape()
    {
        return new Square();
    }
}
public class Program
{
    public static void Main()
    {
        IShapeFactory circleFactory = new CircleFactory();
        IShape circle = circleFactory.CreateShape();
        circle.Draw(); 

        IShapeFactory squareFactory = new SquareFactory();
        IShape square = squareFactory.CreateShape();
        square.Draw(); 
    }
}