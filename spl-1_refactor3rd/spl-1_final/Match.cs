using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace scoreboard
{
    public class Match
    {
        public int Score { get; private set; }
        public string bat;
        public string bowl;
        public double overs;
        public int innings = 1;
        private string team1;
        private string team2;
        private string Type;
        public string batsmen;
        public string bowlerWickets;
        private Team team;
        private Prediction prediction;
        Innings innings1;
        Innings innings2;
        public Match(string team1, string team2, string type)
        {

            this.team1 = team1;
            this.team2 = team2;
            Type = type;
            team = new Team();
            prediction = new Prediction();


            if (Type == "ODI")
            {
                overs = 50;
            }
            else if (Type == "t20")
            {
                overs = 20;
            }
            else
            {
                Console.WriteLine("Enter number of overs:");
                string input = Console.ReadLine();
                overs = Convert.ToInt32(input);
            }
        }


        public void Start()
        {
            Console.Clear();
            TossGenerate teams = new TossGenerate(team1, team2);

            bat = teams.Toss();
            bowl = teams.remain();

            Console.WriteLine($"\nFirst team to bat will be {bat} and bowl will be {bowl}.\n");



            team.DisplayPlayerList(bat);
            Console.WriteLine("\t\t");
            team.DisplayPlayerList(bowl);


            int target = 0;

            innings1 = new Innings(bat, bowl, overs, 1, target);
            Score = innings1.Startgame(bat, bowl, overs, 1, target);

            target = Score + 1;
            Console.WriteLine($"{bat} has set a target of {target} runs for {bowl} to win.");

            string temp = bat;
            bat = bowl;
            bowl = temp;
            innings++;

            innings2 = new Innings(bat, bowl, overs, 2, target);
            Score = innings2.Startgame(bat, bowl, overs, 2, target);


            string result = "Match Draw";
            if (Score == target - 1)
            {
                result = "Match Draw!";
            }
            else if (Score >= target)
            {
                result = $"Team {bat} wins!";
                //   UpdatePrediction(true); // Team1 wins
            }
            else if (Score < target)
            {
                result = $"Team {bowl} wins! by {target - Score} runs.";
                // UpdatePrediction(false); // Team2 wins
            }

            Console.WriteLine("------------------------------------------------------------------------------------------------------------");

            Console.WriteLine(result);

            Console.WriteLine("------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------");

            FinalResult();



           // prediction.DisplayPrediction(); // Display the final prediction
        }

        public void FinalResult()
        {
            Console.WriteLine("\nFinal Scores and Statistics:");

            Console.WriteLine("------------------------------------------------------------------------------------------------------------");

            Console.WriteLine($"Total runs scored: {Score}");

            Console.WriteLine("------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"\nInnings 1: {bowl} scored {innings1.Score} runs.");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------");
            innings1.GetDisplayWicketFallingGraph().DisplayWicketFallingbyGraph(innings1.GetWicketPerOver());
            Console.WriteLine("------------------------------------------------------------------------------------------------------------");
            innings1.GetDisplayRunByOver().DisplayRunbyOverGraph(innings1.GetRunPerOver());
            Console.WriteLine("------------------------------------------------------------------------------------------------------------");
            innings1.GetDisplayBoundaryGraph().DisplayBoundarynyGraph(innings1.GetBoundaryByOver());
            Console.WriteLine("------------------------------------------------------------------------------------------------------------");
            innings1.GetStructuredClass().Finalscore();
            Console.WriteLine("------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------");

            Console.WriteLine($"\nInnings 2: {bat} scored {innings2.Score} runs.");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------");
            innings2.GetDisplayWicketFallingGraph().DisplayWicketFallingbyGraph(innings2.GetWicketPerOver());
            Console.WriteLine("------------------------------------------------------------------------------------------------------------");
            innings2.GetDisplayRunByOver().DisplayRunbyOverGraph(innings2.GetRunPerOver());
            Console.WriteLine("------------------------------------------------------------------------------------------------------------");
            innings2.GetDisplayBoundaryGraph().DisplayBoundarynyGraph(innings2.GetBoundaryByOver());
            Console.WriteLine("------------------------------------------------------------------------------------------------------------");
            innings2.GetStructuredClass().Finalscore();
            Console.WriteLine("------------------------------------------------------------------------------------------------------------");
        }
        private void UpdatePrediction(bool team1Won)
        {
            //prediction.UpdateMatchResult(team1Won);
        }



    }


}


