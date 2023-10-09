using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3
{
    internal class Program
    {
       static void Main(string[] args)
       {
        //Part a
        Greet();
        Greet("Hello!!!");
        Greet("Hello!", "Asma"); 
        //Part b
        double area1 = CalculateArea(); 
        double area2 = CalculateArea(9.5);
        double area3 = CalculateArea(2.0, 2.5);

        Console.WriteLine($"Area 1 is: {area1}");
        Console.WriteLine($"Area 2 is: {area2}");
        Console.WriteLine($"Area 3 is: {area3}");
        //Part c
        int sum1 = AddNumbers(2, 3); 
        int sum2 = AddNumbers(2, 4, 6); 

        Console.WriteLine($"Sum 1 is: {sum1}");
        Console.WriteLine($"Sum 2 is: {sum2}");
        //Part d
        Book book1 = new Book("Miller and Harley"); 
        Book book2 = new Book("Miller and Harley ", "Gerald"); 

        Console.WriteLine($"Book 1: {book1.Title}, {book1.Author}");
        Console.WriteLine($"Book 2: {book2.Title}, {book2.Author}");
        }
    static void Greet(string greeting = "Hello", string name = "World")
    {
        Console.WriteLine($"{greeting}, {name}!");
    }
    static double CalculateArea(double length = 1.0, double width = 1.0)
    {
        return length * width;
    }
    static int AddNumbers(int num1, int num2)
    {
        return num1 + num2;
    }
    static int AddNumbers(int num1, int num2, int num3 = 0)
    {
        return num1 + num2 + num3;
    }

    class Book
    {
        public string Title;
        public string Author;

        public Book(string title, string author = "Unknown")
        {
            Title = title;
            Author = author;
        }
    }
}
}
