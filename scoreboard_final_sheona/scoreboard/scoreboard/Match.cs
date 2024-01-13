using System;
using System.Collections.Generic;
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
        private Team team;
        private Prediction prediction;
        Innings inn;

        



        public Match(string team1, string team2, string type)
        {
          
            this.team1 = team1;
            this.team2 = team2;
            Type = type;
            team = new Team();
            


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
            //Console.WriteLine($"The batsmen of {bat} are: ");

            int target = 0;

            Innings innings1 = new Innings(bat, bowl, overs, 1, target);
            Score = innings1.Startgame(bat, bowl, overs, 1, target);
           

            target = Score + 1;
            Console.WriteLine($"{bat} has set a target of {target} runs for {bowl} to win.");
           
            string temp = bat;
            bat = bowl;
            bowl = temp;
            innings++;

            Innings innings2 = new Innings(bat, bowl, overs, 2, target);
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
                result = $"Team {bowl} wins!";
               // UpdatePrediction(false); // Team2 wins
            }
            Console.WriteLine(result);
          


            //prediction.PredictionDisplay(); // Display the final prediction
            


        }



        private void UpdatePrediction(bool team1Won)
        {
            prediction.UpdateMatchResult(team1Won);
        }


        
        
    }


}


