//configuration manager
using System;
using System.Collections.Generic;

public class ConfigurationManager
{
    private static ConfigurationManager instance;
    private Dictionary<string, string> settings;

    private ConfigurationManager()
    {
        settings = new Dictionary<string, string>
        {
            { "ConnectionString", "Data Source=example.com;User Id=user;Password=pass;" },
            { "LogLevel", "Info" }
        };
    }

    public static ConfigurationManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ConfigurationManager();
            }
            return instance;
        }
    }

    public string GetSetting(string key)
    {
        if (settings.ContainsKey(key))
        {
            return settings[key];
        }
        return null;
    }
}

public class Program
{
    public static void Main()
    {
        ConfigurationManager config1 = ConfigurationManager.Instance;
        string connectionString1 = config1.GetSetting("ConnectionString");
        Console.WriteLine("Connection String 1: " + connectionString1);

        ConfigurationManager config2 = ConfigurationManager.Instance;
        string connectionString2 = config2.GetSetting("ConnectionString");
        Console.WriteLine("Connection String 2: " + connectionString2 + " (Same instance as config1)");
    }
}