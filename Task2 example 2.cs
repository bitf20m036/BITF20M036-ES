//Stock Exchange Trading System
using System;
using System.Collections.Generic;
interface IStockExchange
{
    void RegisterTrader(Trader trader);
    void BuyStock(Trader buyer, string stock, int quantity);
    void SellStock(Trader seller, string stock, int quantity);
}
class Trader
{
    private readonly string name;
    private readonly IStockExchange mediator;

    public Trader(string name, IStockExchange mediator)
    {
        this.name = name;
        this.mediator = mediator;
        mediator.RegisterTrader(this);
    }

    public string Name => name;

    public void BuyStock(string stock, int quantity)
    {
        Console.WriteLine($"{name} buys {quantity} shares of {stock}");
        mediator.BuyStock(this, stock, quantity);
    }

    public void SellStock(string stock, int quantity)
    {
        Console.WriteLine($"{name} sells {quantity} shares of {stock}");
        mediator.SellStock(this, stock, quantity);
    }

    public void ReceiveNotification(string message)
    {
        Console.WriteLine($"{name} receives notification: {message}");
    }
}
class StockExchange : IStockExchange
{
    private readonly List<Trader> traders = new List<Trader>();

    public void RegisterTrader(Trader trader)
    {
        traders.Add(trader);
    }

    public void BuyStock(Trader buyer, string stock, int quantity)
    {
        foreach (var trader in traders)
        {
            if (trader != buyer)
            {
                trader.ReceiveNotification($"{buyer.Name} bought {quantity} shares of {stock}");
            }
        }
    }

    public void SellStock(Trader seller, string stock, int quantity)
    {
        foreach (var trader in traders)
        {
            if (trader != seller)
            {
                trader.ReceiveNotification($"{seller.Name} sold {quantity} shares of {stock}");
            }
        }
    }
}

class Program
{
    static void Main()
    {
        var stockExchange = new StockExchange();

        var trader1 = new Trader("Trader 1", stockExchange);
        var trader2 = new Trader("Trader 2", stockExchange);

        trader1.BuyStock("AAPL", 10);
        trader2.SellStock("GOOGL", 5);
    }
}
