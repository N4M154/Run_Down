using System;
using System.Linq;

namespace scoreboard
{
    public class Innings
    {
        public string bat;
        public string bowl;
        public double overs;
        public int innings;
        public int Score=0;
        public int target = 0;
        public string wicketinover;
     
        public Innings(string bat, string bowl, double overs, int innings, int target)
        {
            this.bat = bat;
            this.bowl = bowl;
            this.overs = overs;
            this.innings = innings;
            this.target = target;
         
        }
       
        public int Startgame(string bat, string bowl, double overs, int innings, int target)
        {   
            
            structuredclass inningsObj = new structuredclass(overs);
            int runs = inningsObj.TheFunction(bat, bowl, overs, innings, target);
           

            //Console.WriteLine("innings " + innings + " is starting");

            // Update the total score based on the innings result
            Score += runs;
            DisplayWicketFallingGraph(inningsObj.GetWicketsPerOver());
            DisplayRunbyOverGraph(inningsObj.GetRunPerOver());
            DisplayBoundaryGraph(inningsObj.GetBoundaryByOver());
            //Console.WriteLine("Total Runrate of the team is " + Convert.ToDouble(Score / overs));

            return Score;
       


        }
        public void DisplayWicketFallingGraph(int[] wicketsPerOver)
        {
            Console.WriteLine("------------------------");
            Console.ForegroundColor = ConsoleColor.Yellow;
          
            Console.WriteLine("Wicket Falling Graph:");

            Console.WriteLine("------------------------");

            for (int over = wicketsPerOver.Length - 1; over >= 0; over--)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;

                Console.Write($"Over {over + 1}: ");

                Console.ForegroundColor = ConsoleColor.Cyan;

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
            Console.ResetColor();
            Console.WriteLine("------------------------");
        }

            public void DisplayRunbyOverGraph(int[] runsScored)
            {
            
         
            Console.WriteLine("------------------------");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Cricket Run-by-Over Graph");
            Console.WriteLine("------------------------");
            Console.ForegroundColor = ConsoleColor.Cyan;
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

            Console.ForegroundColor = ConsoleColor.Yellow;


            // Display the over numbers
            for (int j = 0; j < runsScored.Count(); j++)
             {
                Console.WriteLine($"{j + 1} ");
               // Console.Write($"(runsScored)");
             }
           
             Console.WriteLine() ;
         
            Console.ResetColor();
            Console.WriteLine("------------------------");
        }


        static void DisplayBoundaryGraph(int[] boundariesPerOver)
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
