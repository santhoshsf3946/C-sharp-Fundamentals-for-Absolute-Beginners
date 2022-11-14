using System;
namespace StringSplitting;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("\n================= String Splitting =================");

        Console.Write("\nEnter comma seperated string: ");
        string text = Console.ReadLine();

        string[] values = text.Split(',');

        Console.WriteLine();

        for (int i = 0; i < values.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {values[i]}");
        }

        Console.WriteLine();
    }
}
