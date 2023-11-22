//logging adapter
using System;
public interface ILogger
{
    void LogMessage(string message);
}

public class DefaultLogger : ILogger
{
    public void LogMessage(string message)
    {
        Console.WriteLine("Default Logger: " + message);
    }
}

public interface INewLogger
{
    void Log(string logMessage);
}

public class NewLogger : INewLogger
{
    public void Log(string logMessage)
    {
        Console.WriteLine("New Logger: " + logMessage);
    }
}
public class LoggerAdapter : ILogger
{
    private readonly INewLogger newLogger;

    public LoggerAdapter(INewLogger newLogger)
    {
        this.newLogger = newLogger;
    }

    public void LogMessage(string message)
    {
        newLogger.Log(message);
    }
}
class Program
{
    static void Main()
    {
        var loggerAdapter = new LoggerAdapter(new NewLogger());
        loggerAdapter.LogMessage("Log this message using the adapter");
    }
}
