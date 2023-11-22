//Remote Controls with Different Implementations
using System;
interface IDevice
{
    void TurnOn();
    void TurnOff();
    void SetChannel(double channel); 
}

class Tv : IDevice
{
    public void TurnOn()
    {
        Console.WriteLine("TV is ON");
    }

    public void TurnOff()
    {
        Console.WriteLine("TV is OFF");
    }

    public void SetChannel(double channel) 
    {
        Console.WriteLine($"Setting TV channel to {channel}");
    }
}

class Radio : IDevice
{
    public void TurnOn()
    {
        Console.WriteLine("Radio is ON");
    }

    public void TurnOff()
    {
        Console.WriteLine("Radio is OFF");
    }

    public void SetChannel(double channel)
    {
        Console.WriteLine($"Setting Radio channel to {channel}");
    }
}
abstract class RemoteControl
{
    protected IDevice device;

    protected RemoteControl(IDevice device)
    {
        this.device = device;
    }

    public abstract void TurnOn();
    public abstract void TurnOff();
    public abstract void SetChannel(double channel); 
}
class BasicRemoteControl : RemoteControl
{
    public BasicRemoteControl(IDevice device) : base(device) { }

    public override void TurnOn()
    {
        device.TurnOn();
    }

    public override void TurnOff()
    {
        device.TurnOff();
    }

    public override void SetChannel(double channel)
    {
        device.SetChannel(channel);
    }
}
class Program
{
    static void Main()
    {
        var tv = new Tv();
        var radio = new Radio();

        var tvRemote = new BasicRemoteControl(tv);
        var radioRemote = new BasicRemoteControl(radio);

        tvRemote.TurnOn();
        tvRemote.SetChannel(5);
        tvRemote.TurnOff();

        radioRemote.TurnOn();
        radioRemote.SetChannel(102.5);
        radioRemote.TurnOff();
    }
}
