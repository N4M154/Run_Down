using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scoreboard
{
    internal class TossGenerate
    {


        public string Name { get; set; }
        public string Description { get; set; }
        public string team1;
        public string team2, bowl, bat;

        public TossGenerate(string team1, string team2)
        {
            this.team1 = team1;
            this.team2 = team2;

        }


        public string Toss()
        {


            Console.WriteLine("for team 1, if win, bat or bowl?");

            string response1 = Console.ReadLine();

            Console.WriteLine("for team 2, if win, bat or bowl?");

            string response2 = Console.ReadLine();

            Console.WriteLine("TEAM1, Heads or Tails?");


            string probabilityPerson1 = Console.ReadLine();


            // Get current timestamp as the seed value
            int seed = (int)DateTime.Now.Ticks;

            // Initialize custom random number generator with the timestamp as seed
            CustomRandom customRandom = new CustomRandom(seed);

            // Generate a pseudo-random number
            int randomNumber = customRandom.Next();

            // Use the pseudo-random number to simulate a toss (0 for Heads, 1 for Tails)
            int tossResult = randomNumber % 2;

            // Convert the toss result to Heads or Tails
            string result = (tossResult == 0) ? "Heads" : "Tails";

            // Output the result
            Console.WriteLine($"Toss result: {result}");


            if (result == probabilityPerson1)
            {
                if (response1 == "bat")
                {
                    bat = team1;
                }
                else
                {
                    bat = team2;
                }
            }

            else
            {
                if (response2 == "bat")
                {
                    bat = team2;
                }

                else
                {
                    bat = team1;
                }


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