//Home Theater System Facade
using System;
public class DVDPlayer
{
    public void TurnOn() => Console.WriteLine("DVD Player: Turning on");
    public void Play(string movie) => Console.WriteLine($"DVD Player: Playing {movie}");
    public void TurnOff() => Console.WriteLine("DVD Player: Turning off");
}

public class AudioSystem
{
    public void TurnOn() => Console.WriteLine("Audio System: Turning on");
    public void SetVolume(int volume) => Console.WriteLine($"Audio System: Setting volume to {volume}");
    public void TurnOff() => Console.WriteLine("Audio System: Turning off");
}

public class Projector
{
    public void TurnOn() => Console.WriteLine("Projector: Turning on");
    public void SetInput(string input) => Console.WriteLine($"Projector: Setting input to {input}");
    public void TurnOff() => Console.WriteLine("Projector: Turning off");
}
public class HomeTheaterFacade
{
    private readonly DVDPlayer dvdPlayer;
    private readonly AudioSystem audioSystem;
    private readonly Projector projector;

    public HomeTheaterFacade()
    {
        dvdPlayer = new DVDPlayer();
        audioSystem = new AudioSystem();
        projector = new Projector();
    }

    public void WatchMovie(string movie)
    {
        Console.WriteLine("Get ready to watch a movie...");
        dvdPlayer.TurnOn();
        audioSystem.TurnOn();
        projector.TurnOn();
        projector.SetInput("DVD");
        dvdPlayer.Play(movie);
    }

    public void EndMovie()
    {
        Console.WriteLine("Shutting down the home theater...");
        dvdPlayer.TurnOff();
        audioSystem.TurnOff();
        projector.TurnOff();
    }
}
class Program
{
    static void Main()
    {
        var homeTheaterFacade = new HomeTheaterFacade();
        homeTheaterFacade.WatchMovie("Inception");
        homeTheaterFacade.EndMovie();
    }
}
