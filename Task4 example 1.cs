//Chat Room with Online Users
using System;
using System.Collections.Generic;
interface IChatRoom
{
    void AddObserver(IUser user);
    void RemoveObserver(IUser user);
    void NotifyObservers(string message, IUser sender);
}
interface IUser
{
    void Update(string message);
}
class ChatRoom : IChatRoom
{
    private List<IUser> users = new List<IUser>();

    public void AddObserver(IUser user)
    {
        users.Add(user);
    }

    public void RemoveObserver(IUser user)
    {
        users.Remove(user);
    }

    public void NotifyObservers(string message, IUser sender)
    {
        foreach (var user in users)
        {
            if (user != sender)
            {
                user.Update($"{sender.GetType().Name} says: {message}");
            }
        }
    }

    public void SendMessage(string message, IUser sender)
    {
        Console.WriteLine($"{sender.GetType().Name} sends message: {message}");
        NotifyObservers(message, sender);
    }
}
class ChatUser : IUser
{
    private readonly string name;

    public ChatUser(string name)
    {
        this.name = name;
    }

    public void Update(string message)
    {
        Console.WriteLine($"{name} received message: {message}");
    }
}

class Program
{
    static void Main()
    {
        var chatRoom = new ChatRoom();

        var user1 = new ChatUser("User 1");
        var user2 = new ChatUser("User 2");

        chatRoom.AddObserver(user1);
        chatRoom.AddObserver(user2);
        chatRoom.SendMessage("Hello, everyone!", user1);
    }
}    
