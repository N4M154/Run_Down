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
        public int overs;
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
                Console.WriteLine("number of overs?");
                overs = Convert.ToInt32(Console.ReadLine());
            }


        }



        public void Start()
        {

            TossGenerate teams = new TossGenerate(team1, team2);


            bat = teams.Toss();
            bowl = teams.remain();


            Console.WriteLine($"first team to bat will be {bat} and bowl will be {bowl}");

            Console.WriteLine($"Press any key to start");
            Console.ReadKey();


            Innings innings1 = new Innings(bat, bowl, overs, 1);
            innings1.Startgame();

            Innings innings2 = new Innings(bowl, bat, overs, 2);
            innings2.Startgame();

         
        }

       
     


    }
}
