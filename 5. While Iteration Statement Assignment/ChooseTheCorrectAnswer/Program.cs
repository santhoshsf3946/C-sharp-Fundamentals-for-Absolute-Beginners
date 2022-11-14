using System;
namespace ChooseTheCorrectAnswer;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("\n============== Choose The Correct Answer ==============");

        int choice = 0;
        while (choice != 2)
        {
            Console.WriteLine("\nWhich city is capital of India?");
            Console.WriteLine("\t1. Chennai\n\t2. Delhi\n\t3. Mumbai\n\t4. Kolkata");
            Console.Write("\nEnter your choice: ");
            choice = int.Parse(Console.ReadLine());

            if (choice != 2)
            {
                Console.WriteLine("\nIncorrect!\n");
                Console.Write("Press Y to continue, Press N to close");
                ConsoleKeyInfo option = Console.ReadKey(true);
                Console.WriteLine("\n");
                if (option.KeyChar == 'n' || option.KeyChar == 'N')
                {
                    break;
                }
            }
            else
            {
                Console.WriteLine("\nCorrect!\n");
            }
        }
    }
}
