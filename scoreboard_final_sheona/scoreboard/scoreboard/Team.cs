

using System;
using System.IO;

namespace scoreboard
{
    public class Team
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public string team1;
        public string team2, bowl, bat;



        public Team(string team1, string team2)
        {
            this.team1 = team1;
            this.team2 = team2;

        }
        public Team() { }
        public void DisplayPlayerList(string teamName)
        {
            string playerListFileName = $"{teamName}_Team.txt"; // Adjust the file naming convention
            if (File.Exists(playerListFileName))
            {
                Console.WriteLine($"Player list for {teamName}:");
                string[] playerList = File.ReadAllLines(playerListFileName);
                foreach (string player in playerList)
                {
                    Console.WriteLine(player);
                }
            }
            else
            {
                Console.WriteLine($"Player list file not found for {teamName}.");
            }
        }

        public string[] GetPlayerList(string teamName)
        {
            string playerListFileName = $"{teamName}_Team.txt";
            if (File.Exists(playerListFileName))
            {
                return File.ReadAllLines(playerListFileName);
            }
            else
            {
                Console.WriteLine($"Player list file not found for {teamName}.");
                return new string[0];
            }
        }







    }
}
