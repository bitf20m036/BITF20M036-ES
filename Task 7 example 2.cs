//Text Formatting with Decorators
using System;
interface IText
{
    string Format();
}
class PlainText : IText
{
    private string content;

    public PlainText(string content)
    {
        this.content = content;
    }

    public string Format()
    {
        return content;
    }
}
abstract class TextDecorator : IText
{
    protected IText decoratedText;

    protected TextDecorator(IText text)
    {
        decoratedText = text;
    }

    public virtual string Format()
    {
        return decoratedText.Format();
    }
}
class BoldTextDecorator : TextDecorator
{
    public BoldTextDecorator(IText text) : base(text) { }

    public override string Format()
    {
        return $"<b>{base.Format()}</b>";
    }
}

class ItalicTextDecorator : TextDecorator
{
    public ItalicTextDecorator(IText text) : base(text) { }

    public override string Format()
    {
        return $"<i>{base.Format()}</i>";
    }
}
class Program
{
    static void Main()
    {
        IText plainText = new PlainText("Hello, Decorator Pattern!");
        Console.WriteLine($"Formatted Text: {plainText.Format()}");

        IText boldText = new BoldTextDecorator(plainText);
        Console.WriteLine($"Formatted Text: {boldText.Format()}");

        IText italicBoldText = new ItalicTextDecorator(boldText);
        Console.WriteLine($"Formatted Text: {italicBoldText.Format()}");
    }
}
