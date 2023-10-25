using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scoreboard
{
    public class Match
    {


        public int Score = 0;
        public string bat;
        public string bowl;
        public int overs;
        public int innings;
        string team1, team2;
        string Type;

        public Match(string team1, string team2, string type) 
        {
            this.team1 = team1;
            this.team2 = team2;
            Type = type;


            if (Type == "ODI")
            {
                overs = 50;
            }
            else if (Type == "t20")
            {
                overs = 20;
            }

            else if(Type == "limited")
            {
                overs = 3;
            }


        }

        public void Start()
        {

            TossGenerate teams = new TossGenerate(team1, team2);


            bat = teams.Toss();
            bowl = teams.remain();


            Console.WriteLine($"first team to bat will be {bat} and bowl will be {bowl}\n.");

            Console.WriteLine($"For team {bat} the batsmen are: ");
            SimulateInnings(bat, bowl, overs, 1);

           
            // Calculate the target for the second team
            int target = Score+1;
            Console.WriteLine($"{bat} has set a target of {target} runs for {bowl} to win.");

            Console.WriteLine($"For team {bowl} the batsmen are: ");

            // Simulate the second innings for the chasing team
            SimulateInnings(bowl, bat, overs, 2);

            // Determine the result of the match
            
                string result = "Match Draw";
                if (Score >= target)
                {
                    result = $"{bowl} wins!";
                }
                else if (Score == target - 1)
                {
                    result = "Match Draw";
                }
                else if (Score < target - 1)
                {
                    result = $"{bat} wins!";
                }

                Console.WriteLine(result);
            }
        
        public void SimulateInnings(string battingTeam, string bowlingTeam, int overs, int innings)
        {
            structuredclass inningsObj = new structuredclass();
            int runs = inningsObj.TheFunction(battingTeam, bowlingTeam, overs, innings);

            // Update the total score based on the innings result
            Score += runs;
        }


        


    }

       
     


    }


