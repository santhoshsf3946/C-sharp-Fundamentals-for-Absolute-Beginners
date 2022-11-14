using System;
namespace SumAndAverage;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("\n================ Sum and Average ================");

        double sum = 0, average;

        for (int i = 1; i <= 10; i++)
        {
            Console.Write($"\nEnter number {i}: ");
            sum += double.Parse(Console.ReadLine());
        }

        average = sum / 10;

        Console.WriteLine($"\nThe sum of 10 number is: {sum}");
        Console.WriteLine($"\nThe average is: {average}\n");
    }
}
