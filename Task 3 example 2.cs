//Protection Proxy for Access Control
using System;
public interface ISensitiveOperation
{
    void PerformOperation();
}
public class SensitiveOperation : ISensitiveOperation
{
    public void PerformOperation()
    {
        Console.WriteLine("Sensitive operation performed");
    }
}
public class ProtectionProxy : ISensitiveOperation
{
    private readonly SensitiveOperation realObject;
    private readonly string userRole;

    public ProtectionProxy(string userRole)
    {
        realObject = new SensitiveOperation();
        this.userRole = userRole;
    }

    public void PerformOperation()
    {
        if (userRole == "Admin")
        {
            realObject.PerformOperation();
        }
        else
        {
            Console.WriteLine("Access denied. Insufficient privileges.");
        }
    }
    public static void Main()
    {
        var proxy = new ProtectionProxy("Admin");
        proxy.PerformOperation();
    }
}
