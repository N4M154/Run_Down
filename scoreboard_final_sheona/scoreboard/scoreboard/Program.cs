using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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


            Console.WriteLine("Enter match type(ODI, t20 or shortmatch)");
            type = Console.ReadLine();

            Console.WriteLine("Enter team names");


            Console.Write("team 1: ");
            team1= Console.ReadLine();


            Console.Write("team 2: ");
            team2 = Console.ReadLine();

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



            Match match = new Match(team1, team2, type);
            match.Start();

            

            Console.ReadKey();

        }
    }
}
