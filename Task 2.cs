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
            string sentence = "My roll no is BITF20M036";
            string lastFiveCharacters = GetLastCharacters(sentence, 5);
            Console.WriteLine("Last five characters are: " + lastFiveCharacters);
        }

        static string GetLastCharacters(string input, int count)
        {
            if (input.Length >= count)
            {
                return input.Substring(input.Length - count);
            }
            else
            {
                return input;
            }
        }
    }
}
