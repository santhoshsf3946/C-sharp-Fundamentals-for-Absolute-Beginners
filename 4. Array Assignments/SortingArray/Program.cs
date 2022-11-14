using System;
namespace SortingArray;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("\n=============== Sorting Array ===============");

        int[] intArray = new int[5];

        Console.WriteLine("\nEnter 5 numbers");

        for (int i = 0; i < intArray.Length; i++)
        {
            Console.Write($"\nEnter number {i + 1}: ");
            intArray[i] = int.Parse(Console.ReadLine());
        }

        int temp;

        for (int i = 0; i < intArray.Length; i++)
        {
            for (int j = 0; j < intArray.Length - 1; j++)
            {
                if (intArray[j] > intArray[j + 1])
                {
                    temp = intArray[j];
                    intArray[j] = intArray[j + 1];
                    intArray[j + 1] = temp;
                }
            }
        }

        Console.WriteLine("\nThe sorted array is: ");

        for (int i = 0; i < intArray.Length; i++)
        {
            Console.Write($"{intArray[i]}");
            if (i != intArray.Length - 1)
            {
                Console.Write(", ");
            }
        }

        Console.WriteLine("\n");
    }
}
