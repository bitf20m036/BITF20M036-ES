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
            string[] fruits={"Apple","Banana","Orange","Mango","Grapes"};
            Console.WriteLine("Elements of the fruits array using for loop are:");
            for(int i=0;i<fruits.Length;i++)
            {
                Console.WriteLine(fruits[i]);
            }
            Console.WriteLine("\n");
            //Part2
            string[] colors={"Red","Blue","Yellow","Green","Pink"};
            Console.WriteLine("Elements of the colors array using foreach loop are:");
            Console.Write("\"");
            foreach(string color in colors)
            {
                Console.Write($"{color}, ");
            }
            Console.Write("\"");
        }
    }
}
