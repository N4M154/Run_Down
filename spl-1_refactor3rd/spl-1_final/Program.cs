using System;
using System.IO;
using System.Collections.Generic;



namespace scoreboard
{
    public class Program
    {

        

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

            Console.WriteLine("\n\t\t\t\tWELCOME TO THE MATCH OF "+team1+" AND "+team2+"!");

            //Prediction prediction = new Prediction(team1, team2);
            Prediction prediction = new Prediction();
            prediction.DisplayPrediction(team1,team2);

            Match match = new Match(team1, team2, type);
            match.Start();

            

            Console.ReadKey();

        }
        public static List<string> LoadTeamNamesFromFile(string filePath)
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

        public static int GetSelectedTeamIndex(int maxIndex)
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
            
        }
        
    }
}
