using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scoreboard
{
    public class Match
    {   


        public int Score { get; set; }
        public string bat;
        public string bowl;
        public double overs;
        public int innings;
        string team1, team2;
        string Type;

        public Match(string team1, string team2, string type) {
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

            else
            {
                Console.WriteLine("enter number of overs");
                string input=Console.ReadLine();
                overs = Convert.ToInt32(input);
                    
            }


        }



        public void Start()
        {

            TossGenerate teams = new TossGenerate(team1, team2);


            bat = teams.Toss();
            bowl = teams.remain();


            Console.WriteLine($"first team to bat will be {bat} and bowl will be {bowl}");


            int target = 0;

            Innings innings1 = new Innings(bat, bowl, overs, 1, target);
             Score=innings1.Startgame(bat, bowl, overs, 1, target);

            target = Score + 1;
            Console.WriteLine($"{bat} has set a target of {target} runs for {bowl} to win.");

            string temp = bat;
            bat = bowl;
            bowl = temp;

            Console.WriteLine($"For team {bat} the batsmen are: ");

            Innings innings2 = new Innings(bat, bowl, overs, 2, target);
             Score=innings2.Startgame(bat, bowl, overs, 2, target);

            string result = "Match Draw";
            if (Score == target)
            {
                result = $"draw!";
            }
            else if (Score > target)
            {
                result = $"{bat} wins!";
            }

            else if (Score < target)
            {
                result = $"{bowl} wins!";
            }
            Console.WriteLine(result);


        }

       
     


    }
}
