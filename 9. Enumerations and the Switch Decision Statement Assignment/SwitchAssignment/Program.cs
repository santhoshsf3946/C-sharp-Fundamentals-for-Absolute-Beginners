using System;

namespace SwitchAssignment
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\n============================== Calculator Program ==============================\n");

            Console.WriteLine("\t1. Add two numbers\n\t2. Subtract two numbers\n\t3. Multiply two numbers\n\t4. Divide two numbers");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            Console.Write("\nEnter first number: ");
            int num1 = int.Parse(Console.ReadLine());

            Console.Write("Enter second number: ");
            int num2 = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case "1":
                {
                    Console.WriteLine($"\n{num1} + {num2} = {num1 + num2}\n");
                    break;
                }
                case "2":
                {
                    Console.WriteLine($"\n{num1} - {num2} = {num1 - num2}\n");
                    break;
                }
                case "3":
                {
                    Console.WriteLine($"\n{num1} x {num2} = {num1 * num2}\n");
                    break;
                }
                case "4":
                {
                    Console.WriteLine($"\n{num1} / {num2} = {num1 / num2}\n");
                    break;
                }
                default:
                {
                    Console.WriteLine("\nInvalid Input\n");
                    break;
                }
            }
        }
    }
}
