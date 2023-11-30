//Drawing Commands
using System;
using System.Collections.Generic;
interface IDrawCommand
{
    void Execute();
}
class DrawCircleCommand : IDrawCommand
{
    public void Execute()
    {
        Console.WriteLine("Drawing Circle");
    }
}

class DrawSquareCommand : IDrawCommand
{
    public void Execute()
    {
        Console.WriteLine("Drawing Square");
    }
}
class Artist
{
    private readonly List<IDrawCommand> drawCommands = new List<IDrawCommand>();

    public void AddDrawCommand(IDrawCommand drawCommand)
    {
        drawCommands.Add(drawCommand);
    }

    public void ExecuteDrawCommands()
    {
        foreach (var drawCommand in drawCommands)
        {
            drawCommand.Execute();
        }
    }
}

class Program
{
    static void Main()
    {
        var drawCircleCommand = new DrawCircleCommand();
        var drawSquareCommand = new DrawSquareCommand();

        var artist = new Artist();

        artist.AddDrawCommand(drawCircleCommand);
        artist.AddDrawCommand(drawSquareCommand);

        artist.ExecuteDrawCommands();
    }
}
