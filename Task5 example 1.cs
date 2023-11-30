//Compression Strategies
using System;
interface ICompressionStrategy
{
    void Compress(string filePath);
}
class ZipCompression : ICompressionStrategy
{
    public void Compress(string filePath)
    {
        Console.WriteLine($"Compressing {filePath} using Zip compression");
    }
}

class RarCompression : ICompressionStrategy
{
    public void Compress(string filePath)
    {
        Console.WriteLine($"Compressing {filePath} using RAR compression");
    }
}
class CompressionContext
{
    private ICompressionStrategy compressionStrategy;

    public void SetCompressionStrategy(ICompressionStrategy strategy)
    {
        compressionStrategy = strategy;
    }

    public void CompressFile(string filePath)
    {
        compressionStrategy.Compress(filePath);
    }
}

class Program
{
    static void Main()
    {
        var compressionContext = new CompressionContext();

        var zipCompression = new ZipCompression();
        compressionContext.SetCompressionStrategy(zipCompression);
        compressionContext.CompressFile("document.txt");

        Console.WriteLine();

        var rarCompression = new RarCompression();
        compressionContext.SetCompressionStrategy(rarCompression);
        compressionContext.CompressFile("image.png");
    }
}
