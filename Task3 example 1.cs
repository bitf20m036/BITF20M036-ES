//Event Handling in a User Interface
using System;
abstract class UIElement
{
    protected UIElement successor;

    public void SetSuccessor(UIElement successor)
    {
        this.successor = successor;
    }

    public abstract void HandleEvent(UIEvent uiEvent);
}
class Button : UIElement
{
    public override void HandleEvent(UIEvent uiEvent)
    {
        if (uiEvent.EventType == UIEventType.Click)
        {
            Console.WriteLine("Button handles click event.");
        }
        else if (successor != null)
        {
            successor.HandleEvent(uiEvent);
        }
    }
}
class TextBox : UIElement
{
    public override void HandleEvent(UIEvent uiEvent)
    {
        if (uiEvent.EventType == UIEventType.TextChange)
        {
            Console.WriteLine("TextBox handles text change event.");
        }
        else if (successor != null)
        {
            successor.HandleEvent(uiEvent);
        }
    }
}
class UIEvent
{
    public UIEventType EventType { get; }

    public UIEvent(UIEventType eventType)
    {
        EventType = eventType;
    }
}

enum UIEventType
{
    Click,
    TextChange
}

class Program
{
    static void Main()
    {
        var button = new Button();
        var textBox = new TextBox();
        button.SetSuccessor(textBox);
        var clickEvent = new UIEvent(UIEventType.Click);
        var textChangeEvent = new UIEvent(UIEventType.TextChange);
        button.HandleEvent(clickEvent);
        Console.WriteLine();
        button.HandleEvent(textChangeEvent);
    }
}
