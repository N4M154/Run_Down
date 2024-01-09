

using System;

namespace scoreboard
{
    public class Innings
    {
        public string bat;
        public string bowl;
        public double overs;
        public int innings;
        public int Score=0;
        public int target = 0;
        public string wicketinover;
        structuredclass Structuredclass;
        public Innings(string bat, string bowl, double overs, int innings, int target)
        {
            this.bat = bat;
            this.bowl = bowl;
            this.overs = overs;
            this.innings = innings;
            this.target = target;
            Structuredclass=new structuredclass(overs);
        }
       
        public int Startgame(string bat, string bowl, double overs, int innings, int target)
        {   
            structuredclass inningsObj = new structuredclass(overs);
            int runs = inningsObj.TheFunction(bat, bowl, overs, innings, target);
           

            //Console.WriteLine("innings " + innings + " is starting");

            // Update the total score based on the innings result
            Score += runs;
            DisplayWicketFallingGraph(inningsObj.GetWicketsPerOver());
            //Console.WriteLine("Total Runrate of the team is " + Convert.ToDouble(Score / overs));

            return Score;


        }
        public void DisplayWicketFallingGraph(int[] wicketsPerOver)
        {
            Console.WriteLine("Wicket Falling Graph (Bottom to Top):");

            for (int over = wicketsPerOver.Length - 1; over >= 0; over--)
            {
                Console.Write($"Over {over + 1}: ");

                Console.Write(new string('.', (over + 1) * 2)); // Add leading spaces based on the over number

                // Print '*' for each wicket fallen in the current over
                for (int wicket = 0; wicket < wicketsPerOver[over]; wicket++)
                {
                    Console.Write("*");
                }
                if (wicketsPerOver[over] == 0)
                {
                    Console.Write(new string('.', ((wicketsPerOver.Length) - over) * 2));
                }
                else
                {
                    Console.Write(new string('.', (((wicketsPerOver.Length) - over) * 2) - wicketsPerOver[over]));
                }
                Console.WriteLine(); // Move to the next line for the next over
            }

           
        }

    

    }
}
