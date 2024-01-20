using scoreboard;
using System;
using System.Collections.Generic;
using System.IO;

namespace scoreboard
{
    public class Prediction
    {

        public void DisplayPrediction(string team1, string team2) { 

        string filePath = "team_values.txt";

            // Ensure the file exists
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Team data file not found.");
                return;
            }

    // Read data from the file
    string[] lines = File.ReadAllLines(filePath);

  

    // Find team information for the selected teams
    TeamInfo teaminfo1 = FindTeamInfo(lines, team1);
    TeamInfo teaminfo2 = FindTeamInfo(lines, team2);

            if (teaminfo1 != null && teaminfo2 != null)
            {
                // Predict winning percentage
                double winningPercentageTeam1 = PredictWinningPercentage(teaminfo1, teaminfo2);
    double winningPercentageTeam2 = 100 - winningPercentageTeam1;

    // Display the predictions
    Console.WriteLine($"Predicted Winning Percentage for {teaminfo1.Name}: {winningPercentageTeam1:F2}%");
                Console.WriteLine($"Predicted Winning Percentage for {teaminfo2.Name}: {winningPercentageTeam2:F2}%");
            }
            else
{
    Console.WriteLine("One or both of the entered team names were not found in the data file.");
}


}

static TeamInfo FindTeamInfo(string[] lines, string teamName)
{
    foreach (var line in lines)
    {
        TeamInfo teamInfo = ExtractTeamInfo(line);
        if (teamInfo.Name.Equals(teamName, StringComparison.OrdinalIgnoreCase))
        {
            return teamInfo;
        }
    }
    return null;
}
//prediction winning percentage
static double PredictWinningPercentage(TeamInfo team1, TeamInfo team2)
{
    double team1Score = 0;
    double team2Score = 0;

    // Compare wins
    team1Score += team1.Wins - team2.Wins;
    team2Score += team2.Wins - team1.Wins;

    // Compare losses (negative impact)
    team1Score -= team1.Losses - team2.Losses;
    team2Score -= team2.Losses - team1.Losses;

    // Compare average collector run
    team1Score += (team1.AvgCollectorRun - team2.AvgCollectorRun) * 0.1;
    team2Score += (team2.AvgCollectorRun - team1.AvgCollectorRun) * 0.1;

    // Compare average chases run
    team1Score += (team1.AvgChasesRun - team2.AvgChasesRun) * 0.1;
    team2Score += (team2.AvgChasesRun - team1.AvgChasesRun) * 0.1;

    // Compare average run rate
    team1Score += (team1.AvgRunRate - team2.AvgRunRate) * 0.2;
    team2Score += (team2.AvgRunRate - team1.AvgRunRate) * 0.2;

    // Normalize scores
    double normalizedScoreTeam1 = Sigmoid(team1Score);
    double normalizedScoreTeam2 = Sigmoid(team2Score);

    // Convert normalized scores to percentages
    double winningPercentageTeam1 = normalizedScoreTeam1 * 100;
    double winningPercentageTeam2 = normalizedScoreTeam2 * 100;

    return winningPercentageTeam1;
}

static TeamInfo ExtractTeamInfo(string line)
{
    // Split the line into parts
    string[] parts = line.Split(',');

    // Parse information and create a TeamInfo object
    return new TeamInfo
    {
        Name = parts[0],
        Wins = int.Parse(parts[1]),
        Losses = int.Parse(parts[2]),
        Draws = int.Parse(parts[3]),
        AvgCollectorRun = double.Parse(parts[4]),
        AvgChasesRun = double.Parse(parts[5]),
        AvgRunRate = double.Parse(parts[6])
    };
}

        // Sigmoid function to normalize scores
        /*static double Sigmoid(double x)
        {
            return 1 / (1 + Math.Exp(-x));
        }*/

        static double Sigmoid(double x)
        {
            if (x >= 0)
            {
                return 1.0 / (1.0 + ExpApproximation(-x));
            }
            else
            {
                // Avoid overflow for large negative values of x
                return ExpApproximation(x) / (1.0 + ExpApproximation(x));
            }
        }

        static double ExpApproximation(double x)
        {
            double result = 1.0;
            const int iterations = 10; // Adjust the number of iterations as needed

            for (int i = 1; i <= iterations; i++)
            {
                result += (Power(x, i) / Factorial(i));
            }

            return result;
        }

        static double Power(double baseValue, int exponent)
        {
            double result = 1.0;

            for (int i = 0; i < exponent; i++)
            {
                result *= baseValue;
            }

            return result;
        }

        static double Factorial(int n)
        {
            double result = 1.0;

            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }

            return result;
        }






    }
}

