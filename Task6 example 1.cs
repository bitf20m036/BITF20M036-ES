//Stock Trading Commands
using System;
interface ICommand
{
    void Execute();
}
class BuyStockCommand : ICommand
{
    private readonly StockTrade stockTrade;

    public BuyStockCommand(StockTrade stockTrade)
    {
        this.stockTrade = stockTrade;
    }

    public void Execute()
    {
        stockTrade.Buy();
    }
}

class SellStockCommand : ICommand
{
    private readonly StockTrade stockTrade;

    public SellStockCommand(StockTrade stockTrade)
    {
        this.stockTrade = stockTrade;
    }

    public void Execute()
    {
        stockTrade.Sell();
    }
}
class StockTrade
{
    private string stock;

    public StockTrade(string stock)
    {
        this.stock = stock;
    }

    public void Buy()
    {
        Console.WriteLine($"Buying {stock} stocks.");
    }

    public void Sell()
    {
        Console.WriteLine($"Selling {stock} stocks.");
    }
}
class Broker
{
    private ICommand command;

    public void SetCommand(ICommand command)
    {
        this.command = command;
    }

    public void ExecuteAction()
    {
        command.Execute();
    }
}

class Program
{
    static void Main()
    {
        var stockTrade = new StockTrade("ABC");

        var buyStockCommand = new BuyStockCommand(stockTrade);
        var sellStockCommand = new SellStockCommand(stockTrade);

        var broker = new Broker();

        broker.SetCommand(buyStockCommand);
        broker.ExecuteAction();

        broker.SetCommand(sellStockCommand);
        broker.ExecuteAction();
    }
}
