using System;
using System.Linq;

class Program
{
    static void Main()
    {
        // Sample data representing boundaries hit in each over
        int[] boundariesPerOver = { 2, 1, 0, 4, 6, 2, 1, 4, 0, 6 };

        // Display the boundary by over graph
        DisplayBoundaryGraph(boundariesPerOver);

        Console.ReadLine(); // Keep the console window open
    }

    static void DisplayBoundaryGraph(int[] boundariesPerOver)
    {
        Console.WriteLine("Boundary by Over Graph:");
        Console.WriteLine();

        // Find the maximum number of boundaries hit in a single over
        int maxBoundaries = boundariesPerOver.Max();

        // Display the graph
        for (int row = maxBoundaries; row > 0; row--)
        {
            for (int over = 0; over < boundariesPerOver.Length; over++)
            {
                // Print '#' if the current over has enough boundaries for the current row
                if (boundariesPerOver[over] >= row)
                    Console.Write("| ");
                else
                    Console.Write("  "); // Empty space if no boundary in the current row
            }
            Console.WriteLine(); // Move to the next row
        }

        // Print over numbers at the bottom
        for (int over = 1; over <= boundariesPerOver.Length; over++)
        {
            Console.Write($"{over} ");
        }

       // Move to the next line after printing over numbers
    }
}
