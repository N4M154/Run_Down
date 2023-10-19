using System;
namespace CricektClasses_2
{
    public class Score
    {

        public int Runs = 0;
        public int Wickets = 0;
        public int Balls = 0;
        public double Overs = 0;
        public int BallsInOver = 0;
        public int RunsScored = 0;

        public Batsmen batsmen;
        public Score()
        {
            batsmen = new Batsmen();
        }
        public void BatsmenLoop()
        {
            Console.WriteLine("Score: " + Runs + "/" + Wickets + " for Over: " + Overs + "." + BallsInOver + "");
            Console.WriteLine((batsmen.IsBatsman1Striker ? "* " : "") + batsmen.Batsman1 + ": " + (RunsScored == -1 ? ("After Wicket" + GetRunsString(batsmen.RunsByBatsman1, Balls)) : (GetRunsString(batsmen.RunsByBatsman1, Balls))));
            Console.WriteLine((!batsmen.IsBatsman1Striker ? "*" : "") + batsmen.Batsman2 + ": " + (RunsScored == -1 ? ("After Wicket" + GetRunsString(batsmen.RunsByBatsman2, Balls)) : (GetRunsString(batsmen.RunsByBatsman2, Balls))));
            Console.WriteLine("________________________________________________________________________________________");

        }

        public void WicketDisplay()
        {
            Wickets++;
            if (batsmen.IsBatsman1Striker)
            {
                Console.WriteLine(batsmen.Batsman1 + " is OUT!");
            }
            else
            {
                Console.WriteLine(batsmen.Batsman2 + " is OUT!");
            }

            // Check if there are wickets left
            if (Wickets < 2)
            {

                Console.WriteLine("Enter the name of the new batsman: ");
                batsmen.NewBatsman = Console.ReadLine();
                if (batsmen.IsBatsman1Striker)
                {
                    batsmen.Batsman1 = batsmen.NewBatsman;
                    batsmen.RunsByBatsman1 = new int[20];

                }
                else
                {
                    batsmen.Batsman2 = batsmen.NewBatsman;
                    batsmen.RunsByBatsman1 = new int[20];

                }
                Balls = 0;
            }
        }
        public void RunDisplay()
        {
            Runs += RunsScored;

            // Store runs in the batsman's individual array
            if (batsmen.IsBatsman1Striker)
            {
                batsmen.RunsByBatsman1[Balls] = RunsScored;

            }
            else
            {
                batsmen.RunsByBatsman2[Balls] = RunsScored;
            }

            // Swap striker if there is an odd number of runs scored
            if (RunsScored % 2 == 1)
            {
                batsmen.IsBatsman1Striker = !batsmen.IsBatsman1Striker;
            }

            Balls++;
            BallsInOver++;

            // Check if the over is completed
            if (BallsInOver == 6)
            {
                BallsInOver = 0;
                Overs++;
                batsmen.IsBatsman1Striker = true; // Change striker at the end of the over
            }
        }

        public void FinalDisplay()
        {
            Console.WriteLine("Score: " + Runs + "/" + Wickets + " for Over: " + Overs + "." + BallsInOver + "");
            Console.WriteLine((batsmen.IsBatsman1Striker ? "*" : "") + batsmen.Batsman1 + ": " + GetRunsString(batsmen.RunsByBatsman1, Balls));
            Console.WriteLine((!batsmen.IsBatsman1Striker ? "*" : "") + batsmen.Batsman2 + ": " + GetRunsString(batsmen.RunsByBatsman2, Balls));
            Console.WriteLine("________________________________________________________________________________________");
            //final score
            Console.WriteLine("Final Score: " + Runs + "/" + Wickets + " for Over: " + Overs + ".0");

        }
        static string GetRunsString(int[] RunsArray, int balls)
        {
            string RunsString = "";
            for (int i = 0; i < balls; i++)
            {
                RunsString += RunsArray[i] + " ";
            }
            return RunsString;
        }

    }
}