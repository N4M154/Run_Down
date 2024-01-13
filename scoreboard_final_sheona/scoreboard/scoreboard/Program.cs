using System;
using System.IO;
using System.Collections.Generic;



namespace scoreboard
{
    public class Program
    {

        /*
        static double PredictWinPercentage(double teamStrength1, double teamStrength2, double form1, double form2, double pitchFactor)
        {
            Random random = new Random();

            // Introduce a random factor between 0.95 and 1.05 to simulate unpredictability
            double randomFactor = random.NextDouble() * 0.1 + 0.95;

            double totalStrength = teamStrength1 + teamStrength2;
            double team1Contribution = (teamStrength1 * form1 + teamStrength2 * form2) / totalStrength;
            double team2Contribution = (teamStrength1 * form2 + teamStrength2 * form1) / totalStrength;

            // Include the random factor in the winning probability calculation
            double winningProbability = (team1Contribution + pitchFactor * randomFactor) / (team1Contribution + team2Contribution + pitchFactor * randomFactor);

            return winningProbability * 100;
        }

        */

        static void Main(string[] args)
        {

            string type;

            string team1;

            string team2;
            


            Console.WriteLine("Enter match type(ODI, t20 or a shortmatch)");
            
            
            type=matchtype.GetValidType();


            List<string> teamNames = LoadTeamNamesFromFile("teamnames.txt");

            if (teamNames.Count < 2)
            {
                Console.WriteLine("Error: The file should contain at least two team names.");
                return;
            }

            Console.WriteLine("Select team 1 from the list:");
            for (int i = 0; i < teamNames.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{teamNames[i]}");
            }

            int selectedTeam1Index = GetSelectedTeamIndex(teamNames.Count);

            team1 = teamNames[selectedTeam1Index];

            // Remove the selected team 1 name from the list
            teamNames.RemoveAt(selectedTeam1Index);

            Console.WriteLine("Select team 2 from the remaining list:");
            for (int i = 0; i < teamNames.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {teamNames[i]}");
            }

            int selectedTeam2Index = GetSelectedTeamIndex(teamNames.Count);
            team2 = teamNames[selectedTeam2Index];


            Prediction prediction = new Prediction(team1, team2);

            prediction.PredictionDisplay();

            Match match = new Match(team1, team2, type);
            match.Start();

            




            Console.ReadKey();

        }
        static List<string> LoadTeamNamesFromFile(string filePath)
        {
            List<string> teamNames = new List<string>();
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                teamNames.AddRange(lines);
            }
            return teamNames;
            //Console.ReadKey();
        }

        static int GetSelectedTeamIndex(int maxIndex)
        {
            int selectedTeamIndex;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out selectedTeamIndex) && selectedTeamIndex >= 1 && selectedTeamIndex <= maxIndex)
                {
                    return selectedTeamIndex - 1;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please select a valid team number.");
                }
            }
            //Console.ReadKey();
        }
        
    }
}
