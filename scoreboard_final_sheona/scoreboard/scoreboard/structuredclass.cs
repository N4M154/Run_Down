using System;
using System.Runtime.InteropServices;

namespace scoreboard
{


    public class structuredclass
    {
        
        public Team team=new Team();
        public double over;
        public structuredclass(double over)
        {

            this.over = over;
        }
        //public structuredclass(Team team) { this.team = team; }
        
        public int TheFunction(string battingTeam, string bowlingTeam, double overs, int innings, int target)
        {
            Batsman Batsman1, Batsman2, NewBatsman;
            int Runs = 0;
            int Wickets = 0;
            bool IsBatsman1Striker = true;
            int Balls = 0;
            double Overs = 0;
            int BallsInOver = 0;
            int RunsScored = 0;
            int inning = innings;
            int targets=target;



            string[] batsmanList = team.GetPlayerList(battingTeam);
            string[] bowlerList = team.GetPlayerList(bowlingTeam);

            // Choose the first two batsmen automatically
            Batsman1 = new Batsman(batsmanList[0]);
            Batsman2 = new Batsman(batsmanList[1]);
            /* Console.WriteLine("Enter the name of batsman 1: ");
             Batsman1 = new Batsman(Console.ReadLine());

             Console.WriteLine("Enter the name of batsman 2: ");
             Batsman2 = new Batsman(Console.ReadLine());

             Console.WriteLine("\n");*/

            while (Overs < over && Wickets < 4) // 3 overs + 4 wickets
            {


                Console.WriteLine("________________________________________________________________________________________");
                Console.WriteLine("Score: " + Runs + "/" + Wickets + " for Over: " + Overs + "." + BallsInOver + "");
                Console.WriteLine((IsBatsman1Striker ? "*" : "") + Batsman1.Name + ": " + Batsman1.Runs);
                Console.WriteLine((!IsBatsman1Striker ? "*" : "") + Batsman2.Name + ": " + Batsman2.Runs);
               
                Console.WriteLine("________________________________________________________________________________________");

                if (innings == 2 && Runs >= targets)
                {
                    return Runs;
                }

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
                    BallsInOver++;
                    if (BallsInOver == 6)
                    {
                        BallsInOver = 0;
                        IsBatsman1Striker = !IsBatsman1Striker;
                        Overs++;

                        // Display the score at the end of each over
                        Console.WriteLine("\nEnd of Over " + Overs + ": " + Runs + "/" + Wickets+ " runrate: "+ Runs/Overs+"\n");

                        // Change striker at the end of the over
                    }
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
                        IsBatsman1Striker = !IsBatsman1Striker;
                        Overs++;

                        // Display the score at the end of each over
                        Console.WriteLine("End of Over " + Overs + ": " + Runs + "/" + Wickets + " runrate: " + Runs / Overs);

                        // Change striker at the end of the over
                    }

                   
                }
                else
                {
                    Console.WriteLine("Error! Please input (0 - 6), -1, or -2.");
                }


                if (innings == 2 && Runs > targets)
                {
                    return Runs;
                }


            }



            // Display the final score
            Console.WriteLine("Final Score: " + Runs + "/" + Wickets + " for Over: " + Overs + "." + BallsInOver);
            return Runs;
            


        }
       
    }
}
