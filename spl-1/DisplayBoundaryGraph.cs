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
            Console.WriteLine("------------------------");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Boundary by Over Graph:");
            Console.WriteLine("------------------------");
            Console.WriteLine();

            // Find the maximum number of boundaries hit in a single over
            int maxBoundaries = boundariesPerOver.Max();
            Console.ForegroundColor = ConsoleColor.Cyan;
            // Display the graph
            for (int row = maxBoundaries; row > 0; row--)
            {
                for (int over = 0; over < boundariesPerOver.Length; over++)
                {
                    if (boundariesPerOver[over] >= row)
                        Console.Write("| ");
                    else
                        Console.Write("  "); // Empty space if no boundary in the current row
                }
                Console.WriteLine(); // Move to the next row
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            // Print over numbers at the bottom

            for (int over = 1; over <= boundariesPerOver.Length; over++)
            {
                Console.Write($"{over} ");
            }

            Console.WriteLine();

            Console.ResetColor();
            Console.WriteLine("------------------------"); // Move to the next line after printing over numbers
        }
    }
}
