using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Run_Down_C
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Enter team1: ");
            string team1 = Console.ReadLine();

            Console.WriteLine("Enter team2: ");
            string team2 = Console.ReadLine();

            Console.WriteLine("Enter team1's choice of toss (Heads or Tails): ");
            string team1toss = Console.ReadLine();

            Console.WriteLine("Enter team2's choice of toss (Heads or Tails): ");
            string team2toss = Console.ReadLine();
            if (team1toss == team2toss)
            {
                Console.WriteLine("Two teams choices cannot be the same! Please choose again.");return;
            }

            // Get current timestamp as the seed value
            int seed = (int)DateTime.Now.Ticks;

            // Initialize custom random number generator with the timestamp as seed
            Custom customRandom = new Custom(seed);

            // Generate a pseudo-random number
            int randomNumber = customRandom.Next();

            // Use the pseudo-random number to simulate a toss (0 for Heads, 1 for Tails)
            int tossResult = randomNumber % 2;

            // Convert the toss result to Heads or Tails
            string result = (tossResult == 0) ? "Heads" : "Tails";

            // Output the result
            Console.WriteLine($"Toss result: {result}");
            if (result == "Heads" && team1toss == "Heads")
            {
                Console.WriteLine(team1 + " won the toss! choose to bat or bowl: ");
                string bat_or_Bowl = Console.ReadLine();

            }
            if (result == "Heads" && team1toss == "Tails")
            {
                Console.WriteLine(team2 + " won the toss! choose to bat or bowl: ");
                string bat_or_Bowl = Console.ReadLine();

            }
            if (result == "Tails" && team1toss == "Tails")
            {
                Console.WriteLine(team1 + " won the toss! choose to bat or bowl: ");
                string bat_or_Bowl = Console.ReadLine();

            }
            if (result == "Tails" && team1toss == "Heads")
            {
                Console.WriteLine(team2 + " won the toss! choose to bat or bowl: ");
                string bat_or_Bowl = Console.ReadLine();

            }

            Console.ReadKey();
        }
    }
        class Custom
        {
            private int seed;

            public Custom(int seed)
            {
                this.seed = seed;
            }

            public int Next()
            {
                seed = (seed * 1103515245 + 12345) & 0x7FFFFFFF;
                return seed;
            }
        }
    }