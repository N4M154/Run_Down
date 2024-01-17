using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scoreboard
{
    public class DisplayWicketFallingGraph:IDisplayWicketFallingGraph
    {
        public void DisplayWicketFallingbyGraph(int[] wicketsPerOver)
        {
            Console.WriteLine("------------------------");
            //Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("Wicket Falling Graph:");

            Console.WriteLine("------------------------");

            for (int over = wicketsPerOver.Length - 1; over >= 0; over--)
            {
                //Console.ForegroundColor = ConsoleColor.DarkCyan;

                Console.Write($"Over {over + 1}: ");

                //Console.ForegroundColor = ConsoleColor.Cyan;

                Console.Write(new string('.', (over + 1) * 2)); // Add leading spaces based on the over number

                // Print '*' for each wicket fallen in the current over
                for (int wicket = 0; wicket < wicketsPerOver[over]; wicket++)
                {
                    Console.Write("*");
                }
                if (wicketsPerOver[over] == 0)
                {
                    Console.Write(new string('.', ((wicketsPerOver.Length) - over) * 2));
                }
                else
                {
                    Console.Write(new string('.', (((wicketsPerOver.Length) - over) * 2) - wicketsPerOver[over]));
                }
                Console.WriteLine(); // Move to the next line for the next over

            }
            //Console.ResetColor();
            Console.WriteLine("------------------------");
        }

    }
}
