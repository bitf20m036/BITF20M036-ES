//Visitor for Documents
using System;
using System.Collections.Generic;
interface IDocumentElement
{
    void Accept(IVisitor visitor);
}
class TextElement : IDocumentElement
{
    public void Accept(IVisitor visitor)
    {
        visitor.VisitTextElement(this);
    }
}

class ImageElement : IDocumentElement
{
    public void Accept(IVisitor visitor)
    {
        visitor.VisitImageElement(this);
    }
}
interface IVisitor
{
    void VisitTextElement(TextElement textElement);
    void VisitImageElement(ImageElement imageElement);
}
class PreviewVisitor : IVisitor
{
    public void VisitTextElement(TextElement textElement)
    {
        Console.WriteLine("Previewing Text Element");
    }

    public void VisitImageElement(ImageElement imageElement)
    {
        Console.WriteLine("Previewing Image Element");
    }
}
class Client
{
    static void Main()
    {
        var documentElements = new List<IDocumentElement> { new TextElement(), new ImageElement() };
        var previewVisitor = new PreviewVisitor();

        foreach (var documentElement in documentElements)
        {
            documentElement.Accept(previewVisitor);
        }
    }
}
