using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Project3
{
class MyList<T>
{
    private List<T> elements = new List<T>();

    public void Add(T element)
    {
        elements.Add(element);
    }

    public bool Remove(T element)
    {
        return elements.Remove(element);
    }

    public void Display()
    {
        foreach (var element in elements)
        {
            Console.WriteLine(element);
        }
    }
}

internal class Program
{
    static void Main(string[] args)
    {
        //part a
        MyList<int> myIntList = new MyList<int>();
        Console.WriteLine($"List elements after adding elements in list");
        myIntList.Add(1);
        myIntList.Add(2);
        myIntList.Display(); 
        Console.WriteLine($"List elements after removing an element");
        myIntList.Remove(2);
        myIntList.Display(); 

        MyList<string> myStringList = new MyList<string>();
        Console.WriteLine($"List elements after adding elements in list");
        myStringList.Add("Hello");
        myStringList.Add("Asma");
        myStringList.Display(); 

        //Part b
        int a = 1, b = 2;
        Swap(ref a, ref b);
        Console.WriteLine($"Swapped values are a = {a}, b = {b}"); 

        string x = "Hello", y = "Asma";
        Swap(ref x, ref y);
        Console.WriteLine($"Swapped values are x = {x}, y = {y}");

       //Part c
        int[] myIntArray = { 1, 2, 3, 4, 5 };
        double[] myDoubleArray = { 1.10, 2.20, 3.30, 4.40, 5.50 };

        Console.WriteLine($"Sum of integers: {Sum(myIntArray)}"); 
        Console.WriteLine($"Sum of doubles: {Sum(myDoubleArray)}"); 

        //Part d
        Dictionary<int, string> studentDatabase = new Dictionary<int, string>();
        studentDatabase.Add(101, "Alice");
        studentDatabase.Add(102, "Bob");
        studentDatabase.Add(103, "Charlie");
        studentDatabase.Add(104, "David");

        while (true)
        {
            Console.WriteLine("\nStudent Database Menu:");
            Console.WriteLine("1. View the student database");
            Console.WriteLine("2. Search for a student by ID");
            Console.WriteLine("3. Update a student's name");
            Console.WriteLine("4. Exit");

            Console.Write("Enter your choice: ");
            int no = int.Parse(Console.ReadLine());

            switch (no)
            {
                case 1:
                    DisplayStudentDatabase(studentDatabase);
                    break;

                case 2:
                    SearchStudentByID(studentDatabase);
                    break;

                case 3:
                    UpdateStudentName(studentDatabase);
                    break;

                case 4:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice!!! Please try again.");
                    break;
            }
        }
    }

    static void Swap<T>(ref T a, ref T b)
    {
        T temp = a;
        a = b;
        b = temp;
    }
    static T Sum<T>(T[] array) where T : struct
    {
        if (array.Length == 0)
            throw new InvalidOperationException("Array cannot be empty.");

        dynamic sum = 0;
        foreach (var item in array)
        {
            sum += item;
        }
        return sum;
    }
    static void DisplayStudentDatabase(Dictionary<int, string> database)
    {
        Console.WriteLine("Student Database:");
        foreach (var student in database)
        {
            Console.WriteLine($"Student ID: {student.Key}, Name: {student.Value}");
        }
    }
    static void SearchStudentByID(Dictionary<int, string> database)
    {
        Console.Write("Enter Student ID to search: ");
        int studentID = int.Parse(Console.ReadLine());

        if (database.ContainsKey(studentID))
        {
            string studentName = database[studentID];
            Console.WriteLine($"Student ID: {studentID}, Name: {studentName}");
        }
        else
        {
            Console.WriteLine("Student ID not found in the database.");
        }
    }

    static void UpdateStudentName(Dictionary<int, string> database)
    {
        Console.Write("Enter Student ID to update: ");
        int studentID = int.Parse(Console.ReadLine());

        if (database.ContainsKey(studentID))
        {
            Console.Write("Enter new name: ");
            string newName = Console.ReadLine();

            database[studentID] = newName;
            Console.WriteLine("Student name updated successfully.");
        }
        else
        {
            Console.WriteLine("Student ID not found in the database.");
        }
    }
}
}
