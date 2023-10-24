using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toss
{
    class Program
    {

        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to the Toss Segment!!!!!!!");

            Console.Write("Enter the name of the first team: ");
            string team1 = Console.ReadLine();

            Console.Write("Enter the name of the second team: ");
            string team2 = Console.ReadLine();

            Console.Write("Enter a random value for toss: ");
            if (!int.TryParse(Console.ReadLine(), out int RanValue))
            {
                Console.WriteLine("Invalid Random value value. Please enter a valid integer.");
                return;
            }

            Custom customRandom = new Custom(RanValue);
            randomtoss toss = new randomtoss(team1, team2);

            Console.WriteLine($"Tossing the coin.......... (press Enter)");
            Console.ReadLine();

            string winningTeam = toss.SimulateToss(customRandom);

            Console.WriteLine($"Toss Result: {winningTeam} wins the toss!!!!!!!!!");

            Console.Write("What would you like to choose, bat (B) or bowl (BL): ");
            string choice = Console.ReadLine();

            if (choice.Equals("B", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"{winningTeam} chooses to bat.");
                Console.WriteLine($"{winningTeam} will be the batting team, and {(team1 == winningTeam ? team2 : team1)} will be the bowling team.");
            }
            else if (choice.Equals("BL", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"{winningTeam} chooses to bowl.");
                Console.WriteLine($"{winningTeam} will be the bowling team, and {(team1 == winningTeam ? team2 : team1)} will be the batting team.");
            }
            else
            {
                Console.WriteLine("Invalid choice. Please choose either 'B' or 'BL'.");
            }






            Console.Write("Enter the strength of " + team1 + ": ");
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
    }


}









