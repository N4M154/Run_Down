using System;


namespace scoreboard
{
    public class Program
    {
        static double PredictWinPercentage(double teamStrength1, double teamStrength2, double form1, double form2, double pitchFactor)
        {
            double totalStrength = teamStrength1 + teamStrength2;
            double team1Contribution = (teamStrength1 * form1 + teamStrength2 * form2) / totalStrength;
            double team2Contribution = (teamStrength1 * form2 + teamStrength2 * form1) / totalStrength;
            double winningProbability = (team1Contribution + pitchFactor) / (team1Contribution + team2Contribution + pitchFactor);
            return winningProbability * 100;
        }
        static void Main(string[] args)
        {
            


            string type;

            string team1, team2;


            Console.WriteLine("Enter match type(ODI, t20 or a shortmatch)");
            type = Console.ReadLine();

            Console.WriteLine("Enter team names");


            Console.Write("team 1: ");
            team1= Console.ReadLine();


            Console.Write("team 2: ");
            team2 = Console.ReadLine();

            Prediction prediction = new Prediction(team1, team2);

            prediction.PredictionDisplay();

            Match match = new Match(team1, team2, type);
            match.Start();

            

            Console.ReadKey();

        }
    }
}
