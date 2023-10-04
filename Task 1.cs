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
            Console.Write("Enter the first name:");
            string firstName=Console.ReadLine();
            Console.Write("Enter the last name:");
            string lastName = Console.ReadLine();
            string fullName = ConcatenateNames(firstName, lastName);
            Console.WriteLine("Full Name is: " + fullName);
        }
        static string ConcatenateNames(string firstName, string lastName)
        {
            string space = " ";
            return string.Concat(firstName, space, lastName);
        }
    }
}
