//Chess Piece Flyweight
using System;
using System.Collections.Generic;
public interface IChessPiece
{
    void Display(int positionX, int positionY);
}
public class ChessPieceFactory
{
    private readonly Dictionary<string, IChessPiece> chessPieces = new Dictionary<string, IChessPiece>();

    public IChessPiece GetChessPiece(string key, string color, string shape)
    {
        if (!chessPieces.TryGetValue(key, out var chessPiece))
        {
            chessPiece = new ChessPiece(color, shape);
            chessPieces.Add(key, chessPiece);
        }

        return chessPiece;
    }
}
public class ChessPiece : IChessPiece
{
    private readonly string color;
    private readonly string shape; // Intrinsic properties

    public ChessPiece(string color, string shape)
    {
        this.color = color;
        this.shape = shape;
    }

    public void Display(int positionX, int positionY)
    {
        Console.WriteLine($"Chess Piece: {color} {shape}, Position: ({positionX}, {positionY})");
    }
    public static void Main()
    {
        var chessPiece = new ChessPiece("White", "Pawn");
        chessPiece.Display(2, 3);
    }
}

