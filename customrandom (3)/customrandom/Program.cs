using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customrandom
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
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

            Console.ReadKey();
        }
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
