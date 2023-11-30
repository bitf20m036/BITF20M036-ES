//Date Format Interpreter
using System;

class DateFormatContext
{
    public DateTime CurrentDate { get; set; }
}
interface IDateFormatExpression
{
    string Interpret(DateFormatContext context);
}
class YearExpression : IDateFormatExpression
{
    public string Interpret(DateFormatContext context)
    {
        return context.CurrentDate.Year.ToString();
    }
}

class MonthExpression : IDateFormatExpression
{
    public string Interpret(DateFormatContext context)
    {
        return context.CurrentDate.ToString("MMMM");
    }
}

class DayExpression : IDateFormatExpression
{
    public string Interpret(DateFormatContext context)
    {
        return context.CurrentDate.Day.ToString();
    }
}
class FormatExpression : IDateFormatExpression
{
    private readonly string format;
    private readonly IDateFormatExpression expression;

    public FormatExpression(string format, IDateFormatExpression expression)
    {
        this.format = format;
        this.expression = expression;
    }

    public string Interpret(DateFormatContext context)
    {
        return context.CurrentDate.ToString(format) + expression.Interpret(context);
    }
}
class DateFormatClient
{
    static void Main()
    {
        var context = new DateFormatContext { CurrentDate = DateTime.Now };

        IDateFormatExpression expression = new FormatExpression(" - ", new YearExpression());
        string result = expression.Interpret(context);
        Console.WriteLine("Result: " + result);
    }
}
