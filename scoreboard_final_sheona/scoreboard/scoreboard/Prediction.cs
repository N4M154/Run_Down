using System;

namespace scoreboard
{
    public class Prediction
    {
        string team1, team2;
        public Prediction(string team1, string team2)
        {
            this.team1 = team1;
            this.team2 = team2;
        }

       public void PredictionDisplay()
        {
            Console.Write("Enter the strength of " + team1 + ": ");//is it any number?
            double teamStrength1 = double.Parse(Console.ReadLine());

            Console.Write("Enter the strength of " + team2 + ": ");
            double teamStrength2 = double.Parse(Console.ReadLine());

            Console.Write("Enter the current form of " + team1 + " (0 to 1): ");
            double form1 = double.Parse(Console.ReadLine());

            Console.Write("Enter the current form of " + team2 + " (0 to 1): ");
            double form2 = double.Parse(Console.ReadLine());

            Console.Write("Enter pitch conditions factor (0 to 1, 0.5 for neutral): ");
            double pitchFactor = double.Parse(Console.ReadLine());


            Console.WriteLine("Predicted Winning Percentage:");
            double percentTeam1 = PredictWinPercentage(teamStrength1, teamStrength2, form1, form2, pitchFactor);
            double percentTeam2 = 100 - percentTeam1;

            Console.WriteLine($"{team1}: {percentTeam1}%");
            Console.WriteLine($"{team2}: {percentTeam2}%");
        }

            
        static double PredictWinPercentage(double teamStrength1, double teamStrength2, double form1, double form2, double pitchFactor)
        {
            double totalStrength = teamStrength1 + teamStrength2;
            double team1Contribution = (teamStrength1 * form1 + teamStrength2 * form2) / totalStrength;
            double team2Contribution = (teamStrength1 * form2 + teamStrength2 * form1) / totalStrength;
            double winningProbability = (team1Contribution + pitchFactor) / (team1Contribution + team2Contribution + pitchFactor);
            return winningProbability * 100;
        }
            
    }
}
