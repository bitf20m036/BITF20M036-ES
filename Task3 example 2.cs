//Request Processing Pipeline in a Web Framework
using System;
abstract class Middleware
{
    protected Middleware successor;

    public void SetSuccessor(Middleware successor)
    {
        this.successor = successor;
    }

    public abstract void HandleRequest(Request request);
}
class AuthenticationMiddleware : Middleware
{
    public override void HandleRequest(Request request)
    {
        Console.WriteLine("Authentication Middleware: Authenticating user.");

        if (successor != null)
        {
            successor.HandleRequest(request);
        }
    }
}
class AuthorizationMiddleware : Middleware
{
    public override void HandleRequest(Request request)
    {
        Console.WriteLine("Authorization Middleware: Authorizing user.");

        if (successor != null)
        {
            successor.HandleRequest(request);
        }
    }
}
class LoggingMiddleware : Middleware
{
    public override void HandleRequest(Request request)
    {
        Console.WriteLine("Logging Middleware: Logging request.");

        if (successor != null)
        {
            successor.HandleRequest(request);
        }
    }
}

// Request class
class Request
{
    public string Content { get; }

    public Request(string content)
    {
        Content = content;
    }
}

class Program
{
    static void Main()
    {
        
        var authenticationMiddleware = new AuthenticationMiddleware();
        var authorizationMiddleware = new AuthorizationMiddleware();
        var loggingMiddleware = new LoggingMiddleware();

        authenticationMiddleware.SetSuccessor(authorizationMiddleware);
        authorizationMiddleware.SetSuccessor(loggingMiddleware);

        var request = new Request("GET /api/data");

        authenticationMiddleware.HandleRequest(request);
    }
}
