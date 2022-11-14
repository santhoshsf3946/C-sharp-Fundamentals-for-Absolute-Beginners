using System;
namespace StringManipulation;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("\n================ Wrking with Strings ================");
        Console.Write("\nEnter a string: ");
        string text = Console.ReadLine();

        // 1. Display the odd number of characters from above string.
        Console.WriteLine("\nOdd number of characters from the string");
        for (int i = 1; i < text.Length; i += 2)
        {
            Console.Write(text[i] + " ");
        }

        // 2. Replace the character n with capital N
        Console.WriteLine("\n\nReplace the character n with capital N");
        Console.WriteLine(text.Replace('n', 'N'));

        // 3. Display the above string in reverse
        Console.WriteLine("\nReversed String");
        string reversedText = "";
        for (int i = text.Length - 1; i >= 0; i--)
        {
            reversedText += text[i];
        }
        Console.WriteLine(reversedText);

        // 4. Calculate the length of above string
        Console.WriteLine("\n\nLength of the string: " + text.Length);

        Console.WriteLine("\n==================================================");

        // 5. Get the two string from user and concatenate the first 4 characters of first string and last 3 characters of second string

        Console.WriteLine("\nString concatenation");

        Console.Write("\nEnter First string: ");
        string string1 = Console.ReadLine();

        Console.Write("\nEnter Second string: ");
        string string2 = Console.ReadLine();

        Console.WriteLine($"\nOutput: {string1.Substring(0, 4)}{string2.Substring(string2.Length - 3)}\n");
    }
}
