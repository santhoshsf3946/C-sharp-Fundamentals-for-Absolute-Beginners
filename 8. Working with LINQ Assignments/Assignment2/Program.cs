using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\n===================== Ascending order by string length then by name ====================\n");

            string[] cities = new string[] {"ABU DHABI", "AMSTERDAM", "ROME", "PARIS", "CALIFORNIA", "LONDON", "NEW DELHI", "ZURICH", "NAIROBI"};

            cities.OrderBy(str => str.Length).ThenBy(str => str).ToList().ForEach(str => Console.WriteLine(str));

            Console.WriteLine();
        }
    }
}
