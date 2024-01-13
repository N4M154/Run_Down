using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wicketgraph
{
    public class DWicketGraph
    {
        static void DwWicketGraph(int currentWickets, int totalWickets)
        {
            Console.WriteLine("Wicket Falling Graph");
            Console.WriteLine("--------------------");

            // Calculate the percentage of wickets fallen
            int percentage = (int)((double)currentWickets / totalWickets * 100);

            // Draw the graph
            Console.WriteLine($"Wickets: {currentWickets}/{totalWickets} [{percentage}%]");

            // Draw the horizontal bar graph
            Console.Write("|");
            for (int i = 0; i < 100; i++)
            {
                if (i < percentage)
                    Console.Write("-");
                else
                    Console.Write(" ");
            }
            Console.WriteLine("|");
        }

    }
}
