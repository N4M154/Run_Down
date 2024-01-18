using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scoreboard
{
    public class DisplayRunByOver: IDisplayRunByOver
    {

        public void DisplayRunbyOverGraph(int[] runsScored)
        {
            Console.WriteLine("\n------------------------");
            Console.WriteLine("Cricket Run-by-Over Graph");
            Console.WriteLine("------------------------");

            // Find the maximum number of runs scored in an over
            int maxRuns = FindMaxRuns(runsScored);

            // Display the run-by-over graph vertically from bottom to top
            for (int i = maxRuns; i > 0; i--)
            {
                for (int j = 0; j < runsScored.Length; j++)
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
            PrintOverNumbers(runsScored.Length);

            Console.WriteLine("------------------------\n");
        }

        // Function to find the maximum number of runs scored in an over
        private int FindMaxRuns(int[] runsScored)
        {
            int maxRuns = 0;
            for (int j = 0; j < runsScored.Length; j++)
            {
                if (runsScored[j] > maxRuns)
                    maxRuns = runsScored[j];
            }
            return maxRuns;
        }

        // Function to print over numbers
        private void PrintOverNumbers(int totalOvers)
        {
            for (int j = 0; j < totalOvers; j++)
            {
                Console.Write($"{j + 1}  ");
            }
            Console.WriteLine();
        }
        
    }
}
