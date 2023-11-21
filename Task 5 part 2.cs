//cloneable animals
using System;

public interface ICloneableAnimal
{
    ICloneableAnimal Clone();
    void MakeSound();
}
public class Dog : ICloneableAnimal
{
    public string Breed { get; set; }

    public Dog(string breed)
    {
        Breed = breed;
    }

    public ICloneableAnimal Clone()
    {
        return new Dog(Breed);
    }

    public void MakeSound()
    {
        Console.WriteLine("Dog barks!");
    }
}
public class Cat : ICloneableAnimal
{
    public string FurColor { get; set; }

    public Cat(string furColor)
    {
        FurColor = furColor;
    }

    public ICloneableAnimal Clone()
    {
        return new Cat(FurColor);
    }

    public void MakeSound()
    {
        Console.WriteLine("Cat meows!");
    }
}
public class PrototypeClient
{
    public static void Main()
    {
        ICloneableAnimal dogPrototype = new Dog("Golden Retriever");
        ICloneableAnimal dogClone = dogPrototype.Clone();
        dogClone.MakeSound();

        ICloneableAnimal catPrototype = new Cat("White");
        ICloneableAnimal catClone = catPrototype.Clone();
        catClone.MakeSound();
    }
}