//Logger
using System;

public class Logger
{
    private static Logger instance;
    private static readonly object lockObject = new object();

    private Logger() { }

    public static Logger Instance
    {
        get
        {
            lock (lockObject)
            {
                if (instance == null)
                {
                    instance = new Logger();
                }
            }
            return instance;
        }
    }

    public void LogMessage(string message)
    {
        Console.WriteLine("Log: " + message);
    }
}

public class Program
{
    public static void Main()
    {
        Logger logger1 = Logger.Instance;
        logger1.LogMessage("Log Message 1");  

        Logger logger2 = Logger.Instance;
        logger2.LogMessage("Log Message 2");  
    }
}