using System;
using System.Collections.Generic;
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
        DateTime predictionDateTime;
        int team1WinCount;
        int team2WinCount;

        public Prediction(string team1, string team2)
        {
            this.team1 = team1;
            this.team2 = team2;
            LoadTeamValuesFromFile("team_values.txt");
            predictionDateTime = DateTime.Now;
        }

        private void LoadTeamValuesFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 9) // Updated for including historical match results
                    {
                        string teamName = parts[0].Trim();
                        if (teamName == team1 || teamName == team2)
                        {
                            if (double.TryParse(parts[1], out teamStrength1) &&
                                double.TryParse(parts[2], out form1) &&
                                double.TryParse(parts[3], out form2) &&
                                double.TryParse(parts[4], out pitchFactor) &&
                                int.TryParse(parts[5], out team1WinCount) &&
                                int.TryParse(parts[6], out team2WinCount))
                            {
                                if (DateTime.TryParse(parts[7], out predictionDateTime))
                                {
                                    break; // Stop searching once values are found
                                }
                            }
                        }
                    }
                }
            }
        }

        public void RecordMatchResult(bool team1Won)
        {
            if (team1Won)
            {
                team1WinCount++;
            }
            else
            {
                team2WinCount++;
            }

            // Recalculate form based on historical results or other criteria if needed
            form1 = CalculateForm(team1WinCount);
            form2 = CalculateForm(team2WinCount);
        }

        private double CalculateForm(int winCount)
        {
            // You can implement your own logic to calculate form based on historical results
            // For simplicity, you can use a basic formula like: form = totalWins / (totalWins + totalLosses)
            return winCount / (double)(winCount + (team1WinCount + team2WinCount - winCount));
        }

        public void PredictionDisplay()
        {
            Console.WriteLine($"Prediction generated on: {predictionDateTime}");

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

