using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    internal class Program
    {
        static void Main(string[] args)
        {
        Console.WriteLine("Part 1 of Question 11 is:");
        dynamic myVar;
        myVar = 42;
        Console.WriteLine("Value of Variable (integer): " + myVar);
        myVar = "Hello, Dynamic!";
        Console.WriteLine("Value of Variable (string): " + myVar);
        
        Console.WriteLine("Part 2 of Question 11 is:");
        dynamic myVar1;
        myVar1 = 42;
        Console.WriteLine("Type of Variable (integer): " + myVar1.GetType());
        myVar1 = 3.14;
        Console.WriteLine("Type of Variable (double): " + myVar1.GetType());
        myVar1 = DateTime.Now;
        Console.WriteLine("Type of Variable (DateTime): " + myVar1.GetType());
        myVar1 = "Hello, Dynamic!";
        Console.WriteLine("Type of myVariable2 (string): " + myVar1.GetType());
     }
 }
    
}
