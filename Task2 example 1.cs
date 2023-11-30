//Component Communication in a GUI Framework
using System;

interface IMediator
{
    void Notify(Component sender, string eventType);
}
class Component
{
    protected readonly IMediator mediator;

    public Component(IMediator mediator)
    {
        this.mediator = mediator;
    }

    public void Click()
    {
        Console.WriteLine("Component clicked");
        mediator.Notify(this, "click");
    }

    public void KeyPress()
    {
        Console.WriteLine("Key pressed in component");
        mediator.Notify(this, "keypress");
    }
}
class GUIFramework : IMediator
{
    public void Notify(Component sender, string eventType)
    {
        Console.WriteLine($"Event '{eventType}' received from {sender.GetType().Name}");
    }
}

class Program
{
    static void Main()
    {
        var guiFramework = new GUIFramework();

        var button = new Component(guiFramework);
        var textBox = new Component(guiFramework);

        button.Click();
        textBox.KeyPress();
    }
}
