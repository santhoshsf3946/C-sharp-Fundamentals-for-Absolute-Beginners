using System;
namespace GradePoints;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("\n============ Grade Points ============");

        Console.Write("\nEnter Grade: ");
        char grade = Console.ReadLine().Trim().ToUpper()[0];

        if (grade == 'A')
        {
            Console.WriteLine("\nGrade A denotes 9 Points\n");
        }
        else if (grade == 'B')
        {
            Console.WriteLine("\nGrade B denotes 8 Points\n");
        }
        else if (grade == 'C')
        {
            Console.WriteLine("\nGrade C denotes 7 Points\n");
        }
        else if (grade == 'D')
        {
            Console.WriteLine("\nGrade D denotes 6 Points\n");
        }
        else
        {
            Console.WriteLine("\nThis is not valid Grade\n");
        }
    }
}
