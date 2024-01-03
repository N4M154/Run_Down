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

            
            Console.WriteLine("\t\t\t\tRun_Down");
            Console.WriteLine("\t\t\t\t---------");
            Console.WriteLine("\nThe First Team: X");
            Console.WriteLine("The Second Team: Y");
            Console.WriteLine("---------------------");
            Console.WriteLine("TOSS FOR THE MATCH");
            Console.WriteLine("-------------------");
            Console.WriteLine("Choose a number from (1-50) for team X: 27");
            Console.WriteLine("Choose a number from (1-50) for team Y: 15");
            Console.WriteLine("Choose the target number: 10");
            Console.WriteLine("\nY has won the toss!Choose to bat or bowl first: Bat");
            Console.WriteLine("\nFor the 1st inning--->Y won the toss and chose to bat first and " +
                "X will bowl first.");
            Console.WriteLine("------------------------------------------------------------------------------------------");
            Console.WriteLine("\n\t\t\t\tWelcome to the cricket match of X VS. Y");
            Console.WriteLine("\t\t\t-------------------------------------------------------");
            Console.WriteLine("X team batsmen: ");
            Console.WriteLine(" 1. A\n 2. B\n 3. C\n 4. D\n 5. E\n 6. F\n 7. G\n 8. H\n 9. I\n10. J\n11. K");
            Console.WriteLine("\nY team bowlers: ");
            Console.WriteLine(" 1. L\n 2. M\n 3. N\n 4. O\n 5. P");
            Console.WriteLine("-----------------------");
            Console.WriteLine("The batsmen coming down are: A and B");
            Console.WriteLine("1st bowler is: L");
            Console.WriteLine("Enter (0-6) for runs, -1 for a wicket, -2 to exit: 1");
            Console.WriteLine("A: 1\n*B: 0");
            Console.WriteLine("X: 1/0, over: 0.1, current run rate: 10.0");
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("Enter (0-6) for runs, -1 for a wicket, -2 to exit: 2");
            Console.WriteLine("A: 1 0\n*B: 0 2");
            Console.WriteLine("X: 3/0, over: 0.2, current run rate: 15.0");
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("Enter (0-6) for runs, -1 for a wicket, -2 to exit: 1");
            Console.WriteLine("*A: 1 0 0\nB: 0 2 1");
            Console.WriteLine("X: 4/0, over: 0.3, current run rate: 13.3");
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("Enter (0-6) for runs, -1 for a wicket, -2 to exit: 0");
            Console.WriteLine("*A: 1 0 0 0\nB: 0 2 1 0");
            Console.WriteLine("X: 4/0, over: 0.4, current run rate: 1.0");
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("Enter (0-6) for runs, -1 for a wicket, -2 to exit: 4");
            Console.WriteLine("*A: 1 0 0 0 4\nB: 0 2 1 0 0");
            Console.WriteLine("X: 8/0, over: 0.5, current run rate: 16.0");
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("Enter (0-6) for runs, -1 for a wicket, -2 to exit: 1");
            Console.WriteLine("A: 1 0 0 0 4 1\n*B: 0 2 1 0 0 0");
            Console.WriteLine("X: 9/0, over: 1.0, current run rate: 9.0");
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("......");
            Console.WriteLine("END OF THE 1ST INNING!");
            Console.WriteLine("At the end of the 1st inning: X: 9/0, current run rate: 9.0");
            Console.WriteLine("A: 6(runs), B: 3(runs)");
            Console.WriteLine("L: 9 runs for 0 wicket");
            Console.WriteLine("Target for Y is 10 runs from 1 over.");

            Console.WriteLine("\n\n\nFor the 2nd inning--->Y is going to bat and  " +
                "X will bowl.");
            Console.WriteLine("------------------------------------------------------------------------------------------");
            Console.WriteLine("Y team batsmen: ");
            Console.WriteLine(" 1. Q\n 2. R\n 3. S\n 4. T\n 5. U\n 6. V\n 7. L\n 8. M\n 9. N\n10. O\n11. P");
            Console.WriteLine("\nY team bowlers: ");
            Console.WriteLine(" 1. G\n 2. H\n 3. I\n 4. J\n 5. K");
            Console.WriteLine("-----------------------");
            Console.WriteLine("The batsmen coming down are: Q and R");
            Console.WriteLine("1st bowler is: H");
            Console.WriteLine("Enter (0-6) for runs, -1 for a wicket, -2 to exit: 0");
            Console.WriteLine("*Q: 0\nB: 0");
            Console.WriteLine("Y: 0/0, over: 0.1, current run rate: 0.0, required run rate: 10.0");
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("Enter (0-6) for runs, -1 for a wicket, -2 to exit: 2");
            Console.WriteLine("*Q: 0 2\nR: 0 0");
            Console.WriteLine("Y: 2/0, over: 0.2, current run rate: 10.0, required run rate: 12.0");
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("Enter (0-6) for runs, -1 for a wicket, -2 to exit: 6");
            Console.WriteLine("*Q: 0 2 6\nR: 0 0 0");
            Console.WriteLine("Y: 8/0, over: 0.3, current run rate: 26.7, required run rate: 4.0");
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("Enter (0-6) for runs, -1 for a wicket, -2 to exit: 1");
            Console.WriteLine("Q: 0 2 6 1\n*R: 0 0 0 1");
            Console.WriteLine("Y: 9/0, over: 0.4, current run rate: 22.5, required run rate: 3.0");
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("Enter (0-6) for runs, -1 for a wicket, -2 to exit: -1");
            Console.WriteLine("Q: 0 2 6 1 0\n*R: 0 0 0 1 W");
            Console.WriteLine("Y: 9/0, over: 0.5, current run rate: 18.0, required run rate: 6.0");
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("R is OUT by H!\nR: 1 from 5 balls.\nH: 9 runs for 1 wicket.");
            Console.WriteLine("\nNext to bat is S.");
            Console.WriteLine("Enter (0-6) for runs, -1 for a wicket, -2 to exit: 2");
            Console.WriteLine("Q: 0 2 6 1 0 0\n*S: 0 0 0 0 0 2");
            Console.WriteLine("Y: 11/0, over: 1.0, current run rate: 11.0, required run rate: 0.0");
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("\nY has won the match by 1 wicket!");
            Console.WriteLine("Q: 9(runs), R: 1(run), S: 2(runs)\nH: 11 runs for 1 wicket.");
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
