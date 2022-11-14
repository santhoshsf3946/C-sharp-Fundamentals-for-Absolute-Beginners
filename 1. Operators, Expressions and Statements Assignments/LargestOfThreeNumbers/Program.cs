using System;
namespace LargestOfThreeNumbers;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("\n=============== Largest Of Three Numbers ===============");

        Console.Write("\nEnter first number: ");
        double num1 = double.Parse(Console.ReadLine());

        Console.Write("\nEnter second number: ");
        double num2 = double.Parse(Console.ReadLine());

        Console.Write("\nEnter third number: ");
        double num3 = double.Parse(Console.ReadLine());

        if (num1 > num2)
        {
            if (num1 > num3)
            {
                Console.WriteLine($"\n{num1} is the largest number\n");
            }
            else
            {
                Console.WriteLine($"\n{num3} is the largest number\n");
            }
        }
        else
        {
            if (num2 > num3)
            {
                Console.WriteLine($"\n{num2} is the largest number\n");
            }
            else
            {
                Console.WriteLine($"\n{num3} is the largest number\n");
            }
        }
    }
}
