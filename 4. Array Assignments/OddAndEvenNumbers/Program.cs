using System;
namespace OddAndEvenNumbers;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("\n=============== Odd and Even Numbers ===============");

        int[] intArray = new int[10];

        Console.WriteLine("\nEnter 10 numbers");

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

        Console.WriteLine("\nEven numbers in ascending order: ");
        for (int i = 0; i < intArray.Length; i++)
        {
            if (intArray[i] % 2 == 0)
            {
                Console.Write(intArray[i] + " ");
            }
        }

        Console.WriteLine("\n\nOdd numbers in descending order: ");
        for (int i = intArray.Length - 1; i >= 0; i--)
        {
            if (intArray[i] % 2 != 0)
            {
                Console.Write(intArray[i] + " ");
            }
        }

        Console.WriteLine("\n");
    }
}
