using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scoreboard
{
    public class DisplayBoundaryGraph: IDisplayBoundaryGraph
    {
        

        public void DisplayBoundarynyGraph(int[] boundariesPerOver)
        {
            Console.WriteLine("\n------------------------");
            Console.WriteLine("Boundary by Over Graph:");
            Console.WriteLine("------------------------");
            Console.WriteLine();

            // Find the maximum number of boundaries hit in a single over
            int maxBoundaries = FindMaxBoundaries(boundariesPerOver);

            // Display the graph
            for (int row = maxBoundaries; row > 0; row--)
            {
                for (int over = 0; over < boundariesPerOver.Length; over++)
                {
                    if (boundariesPerOver[over] >= row)
                        Console.Write("| ");
                    else
                        Console.Write("  ");
                }
                Console.WriteLine();
            }

            // Print over numbers at the bottom
            PrintOverNumbers(boundariesPerOver.Length);

            Console.WriteLine("------------------------\n");
        }

        // Function to find the maximum number of boundaries hit in a single over
        private int FindMaxBoundaries(int[] boundariesPerOver)
        {
            int maxBoundaries = 0;
            for (int over = 0; over < boundariesPerOver.Length; over++)
            {
                if (boundariesPerOver[over] > maxBoundaries)
                    maxBoundaries = boundariesPerOver[over];
            }
            return maxBoundaries;
        }

        // Function to print over numbers at the bottom
        private void PrintOverNumbers(int totalOvers)
        {
            for (int over = 1; over <= totalOvers; over++)
            {
                Console.Write($"{over} ");
            }
            Console.WriteLine();
        }
    }
}
