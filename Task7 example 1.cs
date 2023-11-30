//ATM Machine
using System;
class ATM
{
    private IATMState currentState;

    public ATM()
    {
        currentState = new NoCardState();
    }

    public void SetState(IATMState state)
    {
        currentState = state;
    }

    public void InsertCard()
    {
        currentState.InsertCard(this);
    }

    public void EjectCard()
    {
        currentState.EjectCard(this);
    }

    public void EnterPin()
    {
        currentState.EnterPin(this);
    }

    public void WithdrawCash()
    {
        currentState.WithdrawCash(this);
    }
}

interface IATMState
{
    void InsertCard(ATM atm);
    void EjectCard(ATM atm);
    void EnterPin(ATM atm);
    void WithdrawCash(ATM atm);
}
class NoCardState : IATMState
{
    public void InsertCard(ATM atm)
    {
        Console.WriteLine("Card inserted, please enter PIN");
        atm.SetState(new HasCardState());
    }

    public void EjectCard(ATM atm)
    {
        Console.WriteLine("No card inserted");
    }

    public void EnterPin(ATM atm)
    {
        Console.WriteLine("Please insert a card first");
    }

    public void WithdrawCash(ATM atm)
    {
        Console.WriteLine("Please insert a card first");
    }
}

class HasCardState : IATMState
{
    public void InsertCard(ATM atm)
    {
        Console.WriteLine("Card is already inserted");
    }

    public void EjectCard(ATM atm)
    {
        Console.WriteLine("Card ejected");
        atm.SetState(new NoCardState());
    }

    public void EnterPin(ATM atm)
    {
        Console.WriteLine("PIN entered correctly");
        atm.SetState(new HasPinState());
    }

    public void WithdrawCash(ATM atm)
    {
        Console.WriteLine("Please enter PIN first");
    }
}

class HasPinState : IATMState
{
    public void InsertCard(ATM atm)
    {
        Console.WriteLine("Card is already inserted");
    }

    public void EjectCard(ATM atm)
    {
        Console.WriteLine("Card ejected");
        atm.SetState(new NoCardState());
    }

    public void EnterPin(ATM atm)
    {
        Console.WriteLine("PIN is already entered");
    }

    public void WithdrawCash(ATM atm)
    {
        Console.WriteLine("Cash withdrawn successfully");
        atm.SetState(new NoCardState());
    }
}

class Program
{
    static void Main()
    {
        var atm = new ATM();

        atm.InsertCard();
        atm.EjectCard();
        atm.WithdrawCash();
        atm.InsertCard();
        atm.EnterPin();
        atm.WithdrawCash();
    }
}
