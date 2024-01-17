using System;
using System.Collections.Generic;
using System.Linq;

namespace CricketRunByOverGraph
{
    class Program
    {
        static void Main(string[] args)
        {
            // Sample data (replace with your actual data)

            List<int> runsScored = new List<int> { 5, 3, 5, 20, 2, 0, 5, 4, 11, 3 };

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Cricket Run-by-Over Graph");
            Console.WriteLine("------------------------");

            // Find the maximum number of runs scored in an over
            int maxRuns = runsScored.Max();

            // Display the run-by-over graph vertically from bottom to top
            for (int i = maxRuns; i > 0; i--)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                for (int j = 0; j < runsScored.Count; j++)
                {
                    if (i <= runsScored[j])
                    {
                        Console.Write("|");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                    Console.Write("  "); // Adjust spacing for better visualization
                }
                Console.WriteLine();
            }

            // Display the over numbers
            for (int j = 0; j < runsScored.Count; j++)
            {
                Console.Write($"{j + 1}  ");
            }
            Console.WriteLine() ;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
       
            Console.WriteLine("------------------------");
            Console.ResetColor();
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
