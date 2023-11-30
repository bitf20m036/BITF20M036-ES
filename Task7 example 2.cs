//Writing Tools
using System;
class WritingTool
{
    private IWritingToolState currentState;

    public WritingTool()
    {
        currentState = new InkedState();
    }

    public void SetState(IWritingToolState state)
    {
        currentState = state;
    }

    public void Write()
    {
        currentState.Write(this);
    }
}
interface IWritingToolState
{
    void Write(WritingTool writingTool);
}
class InkedState : IWritingToolState
{
    public void Write(WritingTool writingTool)
    {
        Console.WriteLine("Writing with ink");
        writingTool.SetState(new OutOfInkState());
    }
}

class OutOfInkState : IWritingToolState
{
    public void Write(WritingTool writingTool)
    {
        Console.WriteLine("Out of ink, please refill");
        writingTool.SetState(new InkedState());
    }
}

class Program
{
    static void Main()
    {
        var writingTool = new WritingTool();

        writingTool.Write();
        writingTool.Write();
    }
}
