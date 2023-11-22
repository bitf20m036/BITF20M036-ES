//Shape Drawing with Different Renderers
using System;
interface IRenderer
{
    void RenderCircle(float radius, int x, int y);
}

class VectorRenderer : IRenderer
{
    public void RenderCircle(float radius, int x, int y)
    {
        Console.WriteLine($"Drawing a circle of radius {radius} at position ({x},{y}) in vector format.");
    }
}

class RasterRenderer : IRenderer
{
    public void RenderCircle(float radius, int x, int y)
    {
        Console.WriteLine($"Drawing a circle of radius {radius} at position ({x},{y}) in raster format.");
    }
}
abstract class Shape
{
    protected IRenderer renderer;

    protected Shape(IRenderer renderer)
    {
        this.renderer = renderer;
    }

    public abstract void Draw();
}
class Circle : Shape
{
    private float radius;
    private int x, y;

    public Circle(float radius, int x, int y, IRenderer renderer) : base(renderer)
    {
        this.radius = radius;
        this.x = x;
        this.y = y;
    }

    public override void Draw()
    {
        renderer.RenderCircle(radius, x, y);
    }
}
class Program
{
    static void Main()
    {
        var vectorRenderer = new VectorRenderer();
        var rasterRenderer = new RasterRenderer();

        var vectorCircle = new Circle(5, 10, 15, vectorRenderer);
        var rasterCircle = new Circle(5, 10, 15, rasterRenderer);

        vectorCircle.Draw();
        rasterCircle.Draw();
    }
}
