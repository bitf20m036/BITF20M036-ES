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
            Console.Write("Enter the current temperature:");
            double temperature=double.Parse(Console.ReadLine());
            Console.Write("Enter the name of your city:");
            string cityName=Console.ReadLine();
            
            Console.WriteLine($"The temperature in {cityName} is {temperature} degrees Celsius.");
        }
    }
}
