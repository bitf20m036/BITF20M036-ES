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
        //Part 1
        int x = 42;
        object boxObject = x;
        int y = (int)boxObject;
        Console.WriteLine("Value of \"y\": " + y);
        //Part 2
        double doubleValue = 3.14159;
        object boxedObject = doubleValue;
        double unboxedValue = (double)boxedObject;
        Console.WriteLine("Value of \"unboxedValue\": " + unboxedValue);
     }
        
    }
    
}