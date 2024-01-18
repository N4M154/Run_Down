using System;
using System.IO;
using System.Collections.Generic;



namespace scoreboard
{
    public class Program
    {
        public static CustomList<string> LoadTeamNamesFromFile(string filePath)
        {
            CustomList<string> teamNames = new CustomList<string>();
            if (FileExists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        teamNames.Add(line);
                    }
                }
            }
            return teamNames;
        }


        static void Main(string[] args)
        {

            string type;

            string team1;

            string team2;


            Console.WriteLine("Enter match type(ODI, t20 or a shortmatch)");
            
            
            type=matchtype.GetValidType();


            CustomList<string>/*List<string>*/ teamNames = LoadTeamNamesFromFile("teamnames.txt");

            if (teamNames.ToArray().Length < 2)//teamNames.Count < 2)
            {
                Console.WriteLine("Error: The file should contain at least two team names.");
                return;
            }

            Console.WriteLine("Select team 1 from the list:");
            for (int i = 0; i < teamNames.ToArray().Length/*Count*/; i++)
            {
                Console.WriteLine($"{i + 1}.{teamNames.ToArray()[i]}");
            }

            int selectedTeam1Index = GetSelectedTeamIndex(teamNames.ToArray().Length);//Count);
                team1 = teamNames.ToArray()[selectedTeam1Index];



            //team1 = teamNames[selectedTeam1Index];

            // Remove the selected team 1 name from the list
            teamNames=RemoveItemAtIndex(teamNames,selectedTeam1Index);

            Console.WriteLine("Select team 2 from the remaining list:");
            for (int i = 0; i < teamNames.ToArray().Length; i++)
            {
                Console.WriteLine($"{i + 1}. {teamNames.ToArray()[i]}");
            }

            int selectedTeam2Index = GetSelectedTeamIndex(teamNames.ToArray().Length);
            team2 = teamNames.ToArray()[selectedTeam2Index];
            //team2 = teamNames[selectedTeam2Index];

            Console.WriteLine("\n\t\t\t\tWELCOME TO THE MATCH OF "+team1+" VS "+team2+"!\n");
            //Prediction prediction = new Prediction(team1, team2);
            Prediction prediction = new Prediction();
            prediction.DisplayPrediction(team1,team2);

            Match match = new Match(team1, team2, type);
            match.Start();

            

            Console.ReadKey();

        }

        public static bool FileExists(string filePath)
        {
            return File.Exists(filePath);
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

        public static CustomList<string> RemoveItemAtIndex(CustomList<string> list, int index)
        {
            CustomList<string> newList = new CustomList<string>();
            string[] items = list.ToArray();

            for (int i = 0; i < items.Length; i++)
            {
                if (i != index)
                {
                    newList.Add(items[i]);
                }
            }

            return newList;
        }

        public static string GetValidType()
        {
            string type;
            while (true)
            {
                type = Console.ReadLine().ToLower();
                if (type == "odi" || type == "t20" || type == "shortmatch")
                {
                    return type;
                }
                else
                {
                    Console.WriteLine("Invalid match type. Please enter ODI, t20, or shortmatch.");
                }
            }
        }
        /*public static List<string> LoadTeamNamesFromFile(string filePath)
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
*/
        /*public static int GetSelectedTeamIndex(int maxIndex)
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
            
        }*/
        
    }
}
