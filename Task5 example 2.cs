//Drawing Shapes with Different Strategies
using System;
interface IDrawStrategy
{
    void Draw();
}
class DrawCircle : IDrawStrategy
{
    public void Draw()
    {
        Console.WriteLine("Drawing Circle");
    }
}

class DrawSquare : IDrawStrategy
{
    public void Draw()
    {
        Console.WriteLine("Drawing Square");
    }
}
class DrawingContext
{
    private IDrawStrategy drawStrategy;

    public void SetDrawStrategy(IDrawStrategy strategy)
    {
        drawStrategy = strategy;
    }

    public void ExecuteDraw()
    {
        drawStrategy.Draw();
    }
}

class Program
{
    static void Main()
    {
        var drawingContext = new DrawingContext();

        var drawCircle = new DrawCircle();
        drawingContext.SetDrawStrategy(drawCircle);
        drawingContext.ExecuteDraw();

        Console.WriteLine();

        var drawSquare = new DrawSquare();
        drawingContext.SetDrawStrategy(drawSquare);
        drawingContext.ExecuteDraw();
    }
}
