//cloneableObjects
using System;
public interface ICloneableItem
{
    ICloneableItem Clone();
    void Display();
}
public class GraphicObject : ICloneableItem
{
    public string Shape { get; set; }

    public GraphicObject(string shape)
    {
        Shape = shape;
    }

    public ICloneableItem Clone()
    {
        return new GraphicObject(Shape);
    }

    public void Display()
    {
        Console.WriteLine("GraphicObject: " + Shape);
    }
}
public class DocumentTemplate : ICloneableItem
{
    public string Type { get; set; }

    public DocumentTemplate(string type)
    {
        Type = type;
    }

    public ICloneableItem Clone()
    {
        return new DocumentTemplate(Type);
    }

    public void Display()
    {
        Console.WriteLine("DocumentTemplate: " + Type);
    }
}
public class PrototypeClient
{
    public static void Main()
    {
        ICloneableItem graphicPrototype = new GraphicObject("Circle");
        ICloneableItem graphicClone = graphicPrototype.Clone();
        graphicClone.Display();

        ICloneableItem documentPrototype = new DocumentTemplate("Proposal");
        ICloneableItem documentClone = documentPrototype.Clone();
        documentClone.Display();
    }
}