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
        static void Main(string[] args)
        {
            


            string type;

            string team1, team2;


            Console.WriteLine("Enter match type(ODI, t20 or limited)");
            type = Console.ReadLine();

            Console.WriteLine("Enter team names");


            Console.Write("team 1: ");
            team1= Console.ReadLine();


            Console.Write("team 2: ");
            team2 = Console.ReadLine();

            


            Match match = new Match(team1, team2, type);
            match.Start();

            

            Console.ReadKey();

        }
    }
}
