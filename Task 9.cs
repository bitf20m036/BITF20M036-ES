using System;

class Program
{
    static void Main()
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
