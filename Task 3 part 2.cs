//opertingSystemFactory
using System;

public interface IOSButton
{
    void Press();
}

public interface IOSTextBox
{
    void InputText();
}
public class WindowsButton : IOSButton
{
    public void Press()
    {
        Console.WriteLine("Pressing a Windows Button.");
    }
}

public class WindowsTextBox : IOSTextBox
{
    public void InputText()
    {
        Console.WriteLine("Inputting text into a Windows TextBox.");
    }
}

public class MacOSButton : IOSButton
{
    public void Press()
    {
        Console.WriteLine("Pressing a MacOS Button.");
    }
}

public class MacOSTextBox : IOSTextBox
{
    public void InputText()
    {
        Console.WriteLine("Inputting text into a MacOS TextBox.");
    }
}
public interface IOperatingSystemFactory
{
    IOSButton CreateButton();
    IOSTextBox CreateTextBox();
}
public class WindowsFactory : IOperatingSystemFactory
{
    public IOSButton CreateButton()
    {
        return new WindowsButton();
    }

    public IOSTextBox CreateTextBox()
    {
        return new WindowsTextBox();
    }
}

public class MacOSFactory : IOperatingSystemFactory
{
    public IOSButton CreateButton()
    {
        return new MacOSButton();
    }

    public IOSTextBox CreateTextBox()
    {
        return new MacOSTextBox();
    }
}
public class Program
{
    public static void Main()
    {
        IOperatingSystemFactory windowsFactory = new WindowsFactory();
        IOSButton windowsButton = windowsFactory.CreateButton();
        IOSTextBox windowsTextBox = windowsFactory.CreateTextBox();

        windowsButton.Press();  
        windowsTextBox.InputText(); 

        IOperatingSystemFactory macosFactory = new MacOSFactory();
        IOSButton macosButton = macosFactory.CreateButton();
        IOSTextBox macosTextBox = macosFactory.CreateTextBox();

        macosButton.Press();  
        macosTextBox.InputText();  
    }
}