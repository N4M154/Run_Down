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


            Console.WriteLine("------------------------");
            Console.WriteLine("Cricket Run-by-Over Graph");
            Console.WriteLine("------------------------");
    
            // Find the maximum number of runs scored in an over
            int maxRuns = runsScored.Max();

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
            for (int j = 0; j < runsScored.Count(); j++)
            {
                Console.Write($"{j + 1}  ");
                // Console.Write($"(runsScored)");
            }

            Console.WriteLine();

            Console.WriteLine("------------------------");
        }
    }
}
