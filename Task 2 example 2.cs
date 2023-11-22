//Graphic Shapes
using System;
using System.Collections.Generic;
public interface IShape
{
    void Draw();
}
public class Circle : IShape
{
    public void Draw()
    {
        Console.WriteLine("Drawing Circle");
    }
}
public class Square : IShape
{
    public void Draw()
    {
        Console.WriteLine("Drawing Square");
    }
}
public class CompositeShape : IShape
{
    private readonly List<IShape> shapes = new List<IShape>();

    public void AddShape(IShape shape)
    {
        shapes.Add(shape);
    }

    public void Draw()
    {
        Console.WriteLine("Drawing Composite Shape");

        foreach (var shape in shapes)
        {
            shape.Draw();
        }
    }
    public static void Main()
    {
        var composite = new CompositeShape();
        composite.AddShape(new Circle());
        composite.AddShape(new Square());

        var anotherComposite = new CompositeShape();
        anotherComposite.AddShape(new Circle());
        anotherComposite.AddShape(new Square());

        composite.AddShape(anotherComposite);

        composite.Draw();
    }
}
