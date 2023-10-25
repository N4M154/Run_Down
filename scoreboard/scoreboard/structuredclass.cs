using System;
using System.Collections.Generic;
namespace scoreboard
{
   

    public class structuredclass
    {
        public int TheFunction(string battingTeam, string bowlingTeam, int overs, int innings)
        {
            Batsman Batsman1, Batsman2, NewBatsman;
            int Runs = 0;
            int Wickets = 0;
            bool IsBatsman1Striker = true;
            int Balls = 0;
            double Overs = 0;
            int BallsInOver = 0;
            int RunsScored = 0;

            Console.WriteLine("Enter the name of batsman 1: ");
            Batsman1 = new Batsman(Console.ReadLine());

            Console.WriteLine("Enter the name of batsman 2: ");
            Batsman2 = new Batsman(Console.ReadLine());

            Console.WriteLine("\n");

            while (Overs < 3 && Wickets < 4) // 3 overs + 4 wickets
            {
                Console.WriteLine("Score: " + Runs + "/" + Wickets + " for Over: " + Overs + "." + BallsInOver + "");
                Console.WriteLine((IsBatsman1Striker ? "*" : "") + Batsman1.Name + ": " + Batsman1.Runs);
                Console.WriteLine((!IsBatsman1Striker ? "*" : "") + Batsman2.Name + ": " + Batsman2.Runs);
                Console.WriteLine("________________________________________________________________________________________");

                Console.Write("Enter runs (0-6, -1 for wicket fall, -2 to exit the program): ");
                RunsScored = Convert.ToInt32(Console.ReadLine());

                if (RunsScored == -2)
                {
                    break; // Exit the program
                }

                if (RunsScored == -1)
                {
                    Wickets++;

                    if (IsBatsman1Striker)
                    {
                        Console.WriteLine(Batsman1.Name + " is OUT!");
                        Console.WriteLine("Enter the name of the new batsman: ");
                        NewBatsman = new Batsman(Console.ReadLine());
                        Batsman1 = NewBatsman;
                    }
                    else
                    {
                        Console.WriteLine(Batsman2.Name + " is OUT!");
                        Console.WriteLine("Enter the name of the new batsman: ");
                        NewBatsman = new Batsman(Console.ReadLine());
                        Batsman2 = NewBatsman;
                    }

                    Balls = 0;
                }
                else if (RunsScored >= 0 && RunsScored <= 6)
                {
                    Runs += RunsScored;

                    if (IsBatsman1Striker)
                    {
                        Batsman1.AddRuns(RunsScored);
                    }
                    else
                    {
                        Batsman2.AddRuns(RunsScored);
                    }

                    if (RunsScored % 2 == 1)
                    {
                        IsBatsman1Striker = !IsBatsman1Striker;
                    }

                    Balls++;
                    BallsInOver++;

                    if (BallsInOver == 6)
                    {
                        BallsInOver = 0;
                        Overs++;
                        IsBatsman1Striker=!IsBatsman1Striker;

                        // Display the score at the end of each over
                        Console.WriteLine("End of Over " + Overs + ": " + Runs + "/" + Wickets);

                        IsBatsman1Striker = true; // Change striker at the end of the over
                    }
                }
                else
                {
                    Console.WriteLine("Error! Please input (0 - 6), -1, or -2.");
                }
            }

            

            // Display the final score
            Console.WriteLine("Final Score: " + Runs + "/" + Wickets + " for Over: " + Overs + "." + BallsInOver);
            return Runs;
            
            /*Console.ReadKey();*/
        }
    }
}
