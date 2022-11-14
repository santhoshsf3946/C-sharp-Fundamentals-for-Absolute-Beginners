using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\n===================== Find String With Starting and Ending Character =====================");

            string[] cities = new string[] {"ABU DHABI", "AMSTERDAM", "ROME", "MADURAI", "LONDON", "NEW DELHI", "MUMBAI", "NAIROBI"};

            Console.Write("\nInput starting character for the string: ");
            char startCh = Console.ReadLine().ToUpper()[0];

            Console.Write("Input ending character for the string: ");
            char endCh = Console.ReadLine().ToUpper()[0];

            var result = cities.Where<string>(city => city[0] == startCh && city[city.Length - 1] == endCh);

            Console.WriteLine("\n" + string.Join<string>(", ", result) + "\n");
        }
    }
}
