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
            int[] values = {85,92,78,95,23,54,65,43,22,10};
            int max = FindMax(values);
            Console.WriteLine($"The maximum value in the array is: {max}");
        }

        static int FindMax(int[] arr)
        {
            if (arr.Length == 0)
            {
                Console.WriteLine("Empty");
            }

            int max = arr[0],i=0;
            while(i<arr.Length)
            {
                if(max<arr[i])
                {
                    max=arr[i];
                }
                i++;
            }
            return max;
        }
    }
}

