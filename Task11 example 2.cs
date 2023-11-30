//Undo Mechanism
using System;
using System.Collections.Generic;
class Memento
{
    public string State { get; }

    public Memento(string state)
    {
        State = state;
    }
}
class TextEditor
{
    private string text;

    public string Text
    {
        get => text;
        set
        {
            Console.WriteLine($"Setting text to: {value}");
            text = value;
        }
    }

    public Memento CreateMemento()
    {
        return new Memento(text);
    }

    public void RestoreMemento(Memento memento)
    {
        text = memento.State;
        Console.WriteLine($"Restored to text: {text}");
    }
}
class History
{
    private readonly Stack<Memento> history = new Stack<Memento>();

    public void SaveState(TextEditor editor)
    {
        history.Push(editor.CreateMemento());
    }

    public Memento Undo()
    {
        if (history.Count > 0)
        {
            return history.Pop();
        }
        else
        {
            Console.WriteLine("No more undo states");
            return null;
        }
    }
}
class MementoExample4
{
    static void Main()
    {
        var editor = new TextEditor();
        var history = new History();

        editor.Text = "Hello, World!";
        history.SaveState(editor);

        editor.Text = "Modified text";
        history.SaveState(editor);

        editor.Text = "Another change";
        history.SaveState(editor);

        Console.WriteLine($"Current text: {editor.Text}");

        history.Undo();
        Console.WriteLine($"After undo: {editor.Text}");

        history.Undo();
        Console.WriteLine($"After undo: {editor.Text}");

        history.Undo();
        Console.WriteLine($"After undo: {editor.Text}");
    }
}
