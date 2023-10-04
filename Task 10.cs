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
        Console.WriteLine("Part 1 of Question 10 is:");
        int[] numbers = {1,3,5,7};

        foreach (int number in numbers)
        {
            object boxedObject = number;
            int y = (int)boxedObject;
            int squareValue = y * y;
            Console.WriteLine($"Original Integer: {y}, Squared Value: {squareValue}");
        }
        Console.WriteLine("Part 2 of Question 10 is:");
        List<object> mixList = new List<object>();
        mixList.Add(10);             
        mixList.Add(3.148989);           
        mixList.Add('X');            
        foreach (object list in mixList)
        {
            if (list is int intInValue)
            {
                Console.WriteLine($"Integer Value: {intInValue}");
            }
            else if (list is double doubleInValue)
            {
                Console.WriteLine($"Double Value: {doubleInValue}");
            }
            else if (list is char charInValue)
            {
                Console.WriteLine($"Char Value: {charInValue}");
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
    }
}
}
