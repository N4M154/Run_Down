using System;
using System.IO;

namespace scoreboard
{
    public class Prediction
    {
        string team1;
        string team2;
        double teamStrength1;
        double teamStrength2;
        double form1;
        double form2;
        double pitchFactor;
        public Prediction(string team1, string team2)
        {
            this.team1 = team1;
            this.team2 = team2;
            LoadTeamValuesFromFile("team_values.txt");
        }
        private void LoadTeamValuesFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 6)
                    {
                        string teamName = parts[0].Trim(); // Trim to remove leading/trailing spaces
                        if (teamName == team1)
                        {
                            // Load values for team1
                            if (double.TryParse(parts[1], out teamStrength1) &&
                                double.TryParse(parts[2], out form1) &&
                                double.TryParse(parts[3], out form2) &&
                                double.TryParse(parts[4], out pitchFactor))
                            {
                                break; 
                                
                                // Stop searching once team1 values are found
                            
                            }
                        }
                        else if (teamName == team2)
                        {
                            // Load values for team2
                            if (double.TryParse(parts[1], out teamStrength2) &&
                                double.TryParse(parts[2], out form1) &&
                                double.TryParse(parts[3], out form2) &&
                                double.TryParse(parts[4], out pitchFactor))
                            {
                                break; // Stop searching once team2 values are found
                            }
                        }
                    }
                }
            }
        }
        /*private void LoadTeamValuesFromFile(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string[] teamNames = File.ReadAllLines(filePath);
                    if (teamNames.Length < 2)
                    {
                        Console.WriteLine("Error: The file should contain at least two team names.");
                        return;
                    }

                    // Check if the specified teams exist in the file
                    if (Array.IndexOf(teamNames, team1) == -1 || Array.IndexOf(teamNames, team2) == -1)
                    {
                        Console.WriteLine("Error: Specified teams not found in the values file.");
                        return;
                    }

                    // You may load other values here if needed
                }
                else
                {
                    Console.WriteLine("Error: Values file not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }*/
        public void PredictionDisplay()
        {
            /*Console.Write("Enter the strength of " + team1 + ": ");
            double teamStrength1 = double.Parse(Console.ReadLine());

            Console.Write("Enter the strength of " + team2 + ": ");
            double teamStrength2 = double.Parse(Console.ReadLine());

            Console.Write("Enter the current form of " + team1 + " (0 to 1): ");
            double form1 = double.Parse(Console.ReadLine());

            Console.Write("Enter the current form of " + team2 + " (0 to 1): ");
            double form2 = double.Parse(Console.ReadLine());

            Console.Write("Enter pitch conditions factor (0 to 1, 0.5 for neutral): ");
            double pitchFactor = double.Parse(Console.ReadLine());*/


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
