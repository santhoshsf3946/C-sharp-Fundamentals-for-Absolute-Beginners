using System;
namespace WorkingWithDateTime;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("\n=================== Working with DateTime ===================");

        Console.WriteLine("\nCurrent Date: " + DateTime.Now.ToString("dd/MM/yyyy"));

        Console.WriteLine("\nCurrent month of the day: " + DateTime.Now.ToString("MMMM"));

        Console.WriteLine("\nPrevious of 3 day from current date: " + DateTime.Now.AddDays(-3).ToString("dd/MM/yyyy"));

        Console.WriteLine("\n12 hours time of now: " + DateTime.Now.ToString("hh:mm:ss tt") + "\n");
    }
}
