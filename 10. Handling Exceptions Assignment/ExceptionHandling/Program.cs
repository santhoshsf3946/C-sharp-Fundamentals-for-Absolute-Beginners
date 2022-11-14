using System;

namespace ExceptionHandling
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\n==================== Division Program ====================\n");

            Console.Write("Enter first number: ");
            int num1 = int.Parse(Console.ReadLine());

            Console.Write("Enter second number: ");
            int num2 = int.Parse(Console.ReadLine());

            try
            {
                Console.WriteLine($"\n{num1} / {num2} = {num1 / num2}\n");
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("\n" + e.Message + "\n");
            }
            catch (Exception e)
            {
                Console.WriteLine("\nSomething went wrong\n");
            }
        }
    }
}
