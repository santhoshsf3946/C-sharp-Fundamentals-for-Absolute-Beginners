using System;
namespace Calculator;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("\n=============== Calculator ===============");

        Console.WriteLine("\n\t1. Addition\n\t2. Subtraction\n\t3. Multiplication\n\t4. Division\n\t5. Modulus");
        Console.Write("Select an option to perform calculation: ");
        char choice = Console.ReadLine()[0];

        Console.Write("\nEnter first number: ");
        double num1 = double.Parse(Console.ReadLine());

        Console.Write("\nEnter second number: ");
        double num2 = double.Parse(Console.ReadLine());

        switch (choice)
        {
            case '1':
            {
                Console.WriteLine($"\n{num1} + {num2} = {num1 + num2}\n");
                break;
            }
            case '2':
            {
                Console.WriteLine($"\n{num1} - {num2} = {num1 - num2}\n");
                break;
            }
            case '3':
            {
                Console.WriteLine($"\n{num1} * {num2} = {num1 * num2}\n");
                break;
            }
            case '4':
            {
                Console.WriteLine($"\n{num1} / {num2} = {num1 / num2}\n");
                break;
            }
            case '5':
            {
                Console.WriteLine($"\n{num1} % {num2} = {num1 % num2}\n");
                break;
            }
            default:
            {
                Console.WriteLine("\nInvalid Option\n");
                break;
            }
        }
    }
}
