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
            int[] scores={85,92,78,95,23,54,65,43,22,10};
            int i=0,sum=0;
            do{
                sum=sum+scores[i];
                i++;
            }while(i<scores.Length);
            Console.WriteLine($"sum of the elements of array using for do while is: {sum}");
            
        }
    }
}
