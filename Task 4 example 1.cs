//Text Formatting Flyweight
using System;
using System.Collections.Generic;
public interface ITextFormat
{
    void ApplyFormatting(string text);
}
public class TextFormatFactory
{
    private readonly Dictionary<string, ITextFormat> textFormats = new Dictionary<string, ITextFormat>();

    public ITextFormat GetTextFormat(string key, string font, int size, ConsoleColor color)
    {
        if (!textFormats.TryGetValue(key, out var textFormat))
        {
            textFormat = new TextFormat(font, size, color);
            textFormats.Add(key, textFormat);
        }

        return textFormat;
    }
}
public class TextFormat : ITextFormat
{
    private readonly string font;
    private readonly int size;
    private readonly ConsoleColor color;

    public TextFormat(string font, int size, ConsoleColor color)
    {
        this.font = font;
        this.size = size;
        this.color = color;
    }

    public void ApplyFormatting(string text)
    {
        Console.ForegroundColor = color;
        Console.WriteLine($"Text: {text}, Font: {font}, Size: {size}");
        Console.ResetColor();
    }
    public static void Main()
    {
        var textFormat = new TextFormat("Arial", 12, ConsoleColor.Blue);
        textFormat.ApplyFormatting("Hello, Flyweight!");
    }
}

