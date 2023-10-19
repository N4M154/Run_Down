using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scoreboard
{
    public class Team
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public string team1;
        public string team2, bowl, bat;

        public Team(string team1, string team2)
        {
            this.team1 = team1;
            this.team2 = team2;

        }
        public string Toss()
        {
            
            double seed; 
            Console.WriteLine("Team 1 pick a number(0 to 50): ");
          
            
            int probabilityPerson1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Team 2 pick a number(0 to 50): ");
            int probabilityPerson2 = Convert.ToInt32(Console.ReadLine());

            CustomRandom customRandom = new CustomRandom();

            int coinTossResult = customRandom.Next(0,10);

           
          

            Console.WriteLine(coinTossResult);

            if (Math.Abs(coinTossResult- probabilityPerson1) < Math.Abs(coinTossResult- probabilityPerson2))
            {

                bat = team1;
                
            }

            else
            {
                bat = team2;
            
            }



            return bat;
           
        }

        public string remain()
        {

            if (bat == team1)
            {
                bowl = team2;
            }

            else
            {
                bowl = team1;
            }

            return bowl;
        }
    }
}
