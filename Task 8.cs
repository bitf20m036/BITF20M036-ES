using System;

class Program
{
    static void Main()
    {
        int[] numbers = {0,1,2,3,4,5};

        reverseArray(numbers);

        Console.WriteLine("Reversed array is:");
        foreach (int number in numbers)
        {
            Console.Write(number + " ");
        }
    }

    static void reverseArray(int[] arr)
    {
        int length = arr.Length;
        for (int i = 0; i < length / 2; i++)
        {
            int temp = arr[i];
            arr[i] = arr[length - 1 - i];
            arr[length - 1 - i] = temp;
        }
    }
}
