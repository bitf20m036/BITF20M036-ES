//Complex Object Memento
using System;
class Memento
{
    public ComplexObject State { get; }

    public Memento(ComplexObject state)
    {
        State = state.Clone();
    }
}
class ComplexObject
{
    public int Value { get; set; }

    public ComplexObject Clone()
    {
        return new ComplexObject { Value = this.Value };
    }

    public void RestoreState(ComplexObject state)
    {
        this.Value = state.Value;
    }

    public void Display()
    {
        Console.WriteLine($"Current value: {Value}");
    }
}
class Caretaker
{
    public Memento Memento { get; set; }
}
class MementoExample3
{
    static void Main()
    {
        var originator = new ComplexObject();
        var caretaker = new Caretaker();

        originator.Value = 42;
        originator.Display();
        caretaker.Memento = new Memento(originator);

        originator.Value = 99;
        originator.Display();

        originator.RestoreState(caretaker.Memento.State);
        originator.Display();
    }
}
