using System;


namespace scoreboard
{
    public class TossGenerate
    {


        public string Name { get; set; }
        public string Description { get; set; }
        public string team1;
        public string team2;
        public string bowl;
        public string bat;

        public TossGenerate(string team1, string team2)
        {
            this.team1 = team1;
            this.team2 = team2;

        }
        public string GetValidChoice(string team)
        {
            string choice;
            
            bool isValidInput = false;

            do
            {
              
                choice = Console.ReadLine().ToLower();


                // Convert to lowercase for case-insensitive comparison
                //whatever casing, code will reform it to heads or tails tp avoid any error


                try
                {
                    // Check if the input is either "bat" or "bowl"
                    if (choice != "bat" && choice != "bowl")
                    {
                        throw new ArgumentException("Invalid input. Please enter 'bat' or 'bowl'.");
                    }

                    isValidInput = true;
                }



                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            } 
            
            
            while (!isValidInput);

            return choice;
        }

        public string GetValidHeadortails(string team)
        {
            string toss;
            bool isValidInput = false;

            do
            {
               
                toss = Console.ReadLine().ToLower();


                // Convert to lowercase for case-insensitive comparison
                //whatever casing of heads or tails, code will reform it to heads or tails tp avoid any error


                try
                {
                    // Check if the input is either "bat" or "bowl"
                    if (toss != "heads" && toss != "tails")
                    {
                        throw new ArgumentException("Invalid input. Please enter 'heads' or 'tails'.");
                    }

                    isValidInput = true;
                }



                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            } 
            
            while (!isValidInput);

            return toss;
        }
        public string Toss()
        {


            Console.WriteLine($"For {team1}, if win, bat or bowl?");

            string response1 = GetValidChoice(team1);


            Console.WriteLine($"For {team2}, if win, bat or bowl?");


            string response2 = GetValidChoice(team2);



            Console.WriteLine($"Team {team1}, Heads or Tails?");


            string probabilityPerson1;


            probabilityPerson1 = GetValidHeadortails(team1);

          

            

            // Get current timestamp as the seed value
            int seed = (int)DateTime.Now.Ticks;

            // Initialize custom random number generator with the timestamp as seed
            CustomRandom customRandom = new CustomRandom(seed);

            // Generate a pseudo-random number
            int randomNumber = customRandom.Next();

            // Use the pseudo-random number to simulate a toss (0 for Heads, 1 for Tails)
            int tossResult = randomNumber % 2;

            // Convert the toss result to Heads or Tails
            string result = (tossResult == 0) ? "heads" : "tails";

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