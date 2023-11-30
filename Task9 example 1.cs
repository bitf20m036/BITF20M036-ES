//Boolean Expression Interpreter
using System;
class BooleanContext
{
    public bool VariableValue { get; set; }
}

interface IBooleanExpression
{
    bool Interpret(BooleanContext context);
}
class VariableExpression : IBooleanExpression
{
    public bool Interpret(BooleanContext context)
    {
        return context.VariableValue;
    }
}

class ConstantExpression : IBooleanExpression
{
    private readonly bool constantValue;

    public ConstantExpression(bool constantValue)
    {
        this.constantValue = constantValue;
    }

    public bool Interpret(BooleanContext context)
    {
        return constantValue;
    }
}
class NotExpression : IBooleanExpression
{
    private readonly IBooleanExpression expression;

    public NotExpression(IBooleanExpression expression)
    {
        this.expression = expression;
    }

    public bool Interpret(BooleanContext context)
    {
        return !expression.Interpret(context);
    }
}
class BooleanClient
{
    static void Main()
    {
        var context = new BooleanContext { VariableValue = true };

        IBooleanExpression expression = new NotExpression(
            new VariableExpression()
        );

        bool result = expression.Interpret(context);
        Console.WriteLine("Result: " + result);
    }
}
