using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace scoreboard
{


    public class structuredclass
    {
        private List<Batsman> batsmen;
        private Dictionary<string, int> bowlerWickets;


        public Team team = new Team();
        public double over;
        public int[] wicketsPerOver = { 0 };
        public int[] boundarybyover = { 0 };
        public int[] runPerOver = { 0 };
        public structuredclass(double over)
        {

            this.over = over;
            int overgraph = Convert.ToInt32(over);
            wicketsPerOver = new int[Convert.ToInt32(over)];
            runPerOver = new int[overgraph];
            boundarybyover = new int[overgraph];
            batsmen = new List<Batsman>();
            bowlerWickets = new Dictionary<string, int>();

        }

        public int TheFunction(string battingTeam, string bowlingTeam, double overs, int innings, int target)
        {

            int requiredRuns = 0;
            double requiredRunRate = 0;

            Batsman Batsman1, Batsman2, NewBatsman;
            int Runs = 0;
            int Wickets = 0;
            bool IsBatsman1Striker = true;

            double Balls = 0;
            double Overs = 0;
            double Runrate = 0;
            double BallsInOver = 0;
            int RunsScored = 0;
            int inning = innings;
            int targets = target;



            string[] batsmanList = team.GetPlayerList(battingTeam);
            string[] bowlerList = team.GetPlayerList(bowlingTeam);

            // Choose the first two batsmen automatically


            Console.WriteLine("________________________________________________________________________________________");
            Console.WriteLine($"Inning {innings} is starting.\n");

            //using arrray to store player list and getting the names of the batsman from there
            Batsman1 = new Batsman(batsmanList[0]);

            Batsman2 = new Batsman(batsmanList[1]);
            Console.WriteLine("---------------------------------------------------------------------");

            
            Console.WriteLine("\nBowlers for this innings:");
            int startIndex = bowlerList.Length - 5 >= 0 ? bowlerList.Length - 5 : 0;
            for (int i = startIndex; i < bowlerList.Length; i++)
            {
                Console.WriteLine(bowlerList[i]);
            }
           

            int currentBowlerIndex = startIndex;

            batsmen.Add(Batsman1);
            batsmen.Add(Batsman2);

            while (Overs < over && Wickets < 11)
            {

                Console.WriteLine("________________________________________________________________________________________");
                Console.WriteLine("Over: " + (int)Overs + "." + BallsInOver + " | Bowler: " + bowlerList[currentBowlerIndex]);
                Console.WriteLine("Score: " + Runs + "/" + Wickets + " for Over: " + Overs + "." + BallsInOver);

                if(innings==2)
                {
                    requiredRuns = target - (Runs);
                    requiredRunRate = (requiredRuns) / (overs - Overs);
                    Console.WriteLine($"\nRuns required to win: {requiredRuns}| Required Run Rate: {requiredRunRate:F2} runs per over\n");//2 digits float points

                }

                Console.WriteLine((IsBatsman1Striker ? "*" : "") + Batsman1.Name + ": " + Batsman1.Runs);
                Console.WriteLine((!IsBatsman1Striker ? "*" : "") + Batsman2.Name + ": " + Batsman2.Runs);

                Console.WriteLine("________________________________________________________________________________________");

                if (innings == 2 && Runs >= targets)
                {

                    return Runs;
                }

                Console.Write("Enter runs (0-6, -1 for wicket fall, -3 for wide, -4 for no-ball, -2 to exit the program): ");
                RunsScored = Convert.ToInt32(Console.ReadLine());


                if (RunsScored == -2)
                {
                    break; // Exit the program
                }

                if (RunsScored == -1)
                {


                    Wickets++;

                    wicketsPerOver[Convert.ToInt32(Overs)]++;

                    if (IsBatsman1Striker)
                    {
                        Console.WriteLine(Batsman1.Name + " is OUT! by " + bowlerList[currentBowlerIndex]);
                        IncrementBowlerWickets(bowlerList[currentBowlerIndex]);
                        DisplayBatsmanRuns(Batsman1);
                        NewBatsman = new Batsman(batsmanList[Wickets + 1]);
                        Batsman1 = NewBatsman;
                        batsmen.Add(Batsman1);
                        Console.WriteLine("Next batsman: " + Batsman1.Name);
                    }
                    else
                    {
                        Console.WriteLine(Batsman2.Name + " is OUT! by " + bowlerList[currentBowlerIndex]);
                        IncrementBowlerWickets(bowlerList[currentBowlerIndex]);
                        DisplayBatsmanRuns(Batsman2);
                        NewBatsman = new Batsman(batsmanList[Wickets + 1]);
                        Batsman2 = NewBatsman;
                        batsmen.Add(Batsman2);
                        Console.WriteLine("Next batsman: " + Batsman2.Name);

                    }

                    Balls++;
                    BallsInOver++;
                    if (BallsInOver == 6)
                    {
                        BallsInOver = 0;
                        IsBatsman1Striker = !IsBatsman1Striker;
                        Overs++;

                        Runrate = Runs / Overs;

                        // Display the score at the end of each over
                        Console.WriteLine("\nEnd of Over " + Overs + ": " + Runs + "/" + Wickets + " | runrate: " + Runrate + "\n");

                        // Change striker at the end of the over

                    }


                }
                else if (RunsScored == -3)
                {
                    Console.WriteLine("It's a wide!");
                }
                else if (RunsScored == -4)
                {
                    Console.WriteLine("It's a free hit!");
                }


                else if (RunsScored >= 0 && RunsScored <= 6)
                {
                    Runs += RunsScored;
                    runPerOver[Convert.ToInt32(Overs)] += RunsScored;

                    if (RunsScored == 4 || RunsScored == 6)
                    {
                        boundarybyover[Convert.ToInt32(Overs)]++;
                    }

                    Balls++;

                    BallsInOver++;



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



                    if (BallsInOver == 6)
                    {
                        BallsInOver = 0;
                        IsBatsman1Striker = !IsBatsman1Striker;

                        Overs++;

                        Runrate = Runs / Overs;

                        // Display the score at the end of each over
                        Console.WriteLine("End of Over " + Overs + ": " + Runs + "/" + Wickets + " runrate: " + Runrate);

                        // Change striker at the end of the over
                        currentBowlerIndex++;
                        if (currentBowlerIndex >= bowlerList.Length)
                        {
                            currentBowlerIndex = startIndex;
                        }
                    }


                }
                else
                {
                    Console.WriteLine("Error! Please input (0 - 6), -1, -3, -4 or -2.");
                }


                if (innings == 2 && Runs > targets)
                {
                    DisplayBatsmanRuns(Batsman1);
                    DisplayBatsmanRuns(Batsman2);
                    return Runs;
                }


                DisplayBatsmanRuns(Batsman1);
                DisplayBatsmanRuns(Batsman2);



            }



            // Display the final score
            Console.WriteLine("Final Score: " + Runs + "/" + Wickets + " for Over: " + Overs + "." + BallsInOver + " Runrate: " + Runrate);

            // Finalscore();


            return Runs;



        }
        private List<Batsman> GetTopScorers()
        {
            int maxRuns = batsmen.Max(b => b.Runs);
            return batsmen.Where(b => b.Runs == maxRuns).ToList();
            //return batsmen.OrderByDescending(b => b.Runs).FirstOrDefault();
        }
        private void DisplayBatsmanRuns(Batsman batsman)
        {
            Console.WriteLine($"{batsman.Name}'s runs: {batsman.Runs}");
        }

        private void IncrementBowlerWickets(string bowlerName)
        {
            if (bowlerWickets.ContainsKey(bowlerName))
            {
                bowlerWickets[bowlerName]++;
            }
            else
            {
                bowlerWickets.Add(bowlerName, 1);
            }
        }

        public void Finalscore()
        {
            Console.WriteLine($"\nWickets taken by the bowlers: \n");
            foreach (var entry in bowlerWickets)
            {


                Console.WriteLine($"{entry.Key}: {entry.Value} wicket" + (entry.Value <= 1 ? "." : "s."));
            }
            Console.WriteLine("\nBatsman score:");

            foreach (var entry in batsmen)
            {
                DisplayBatsmanRuns(entry);
            }



            List<Batsman> topScorers = GetTopScorers();
            Console.WriteLine("\nTop Scorers:");
            foreach (var batsman in topScorers)
            {
                Console.WriteLine($"{batsman.Name}: {batsman.Runs} runs.");
            }
            /*Batsman topScorer = GetTopScorer();
            Console.WriteLine($"\nTop Scorer: {topScorer.Name} with {topScorer.Runs} runs.");*/
        }



        public int[] GetWicketsPerOver()
        {

            return (int[])wicketsPerOver.Clone();
        }

        public int[] GetBoundaryByOver()
        {

            return (int[])boundarybyover.Clone();
        }

        public int[] GetRunPerOver()
        {

            return (int[])runPerOver.Clone();
        }



    }
}


