using CricektClasses_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CricketClasses_2
{
    public class Toss
    {
        public string Team1,Team2;
        public bool Team1batting = false;
        /*public Toss(string team1,string team2)
        {
            Team1 = team1;
            Team2 = team2;
        } */  
        public void TossDisplay()
        {
            Console.WriteLine("Enter the name of the first team: ");
            Team1 = Console.ReadLine();
            Console.WriteLine("Enter the name of the second team: ");
            Team2 = Console.ReadLine();

            Console.WriteLine("Toss to determine which team will bat first: ");
            Console.WriteLine("Choose a number from 1 - 10: ");
            int tossResult = Convert.ToInt32(Console.ReadLine());

            if (tossResult == 2 || tossResult == 3 || tossResult == 5 || tossResult == 8 || tossResult == 9)
            {
                Team1batting = true;
                Console.WriteLine(Team1 + " will bat first and " + Team2 + " is bowling first.");
            
            } 
            else if (tossResult == 1 || tossResult == 4 || tossResult == 6 || tossResult == 7 || tossResult == 10) 
            {
                Console.WriteLine(Team2 + " will bat first and " + Team1 + " is bowling first.");
            }
            else 
            {
                Console.WriteLine("Invalid input. Exiting.");
                return;
            }

        }
    }
}
