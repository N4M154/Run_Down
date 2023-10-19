using CricketClasses_2;
using System;

namespace CricektClasses_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Batsmen bat = new Batsmen();

            Score score = new Score();

            Toss toss = new Toss();
            toss.TossDisplay();

            bat.BatsmenNameDisplay();

            while(score.Overs < 1 && score.Wickets <2 )
            {
                score.BatsmenLoop();
               

                Console.Write("Enter runs (0-6, -1 for wicket fall, -2 to exit the program): ");
                score.RunsScored = Convert.ToInt32(Console.ReadLine());

                if(score.RunsScored==-2)
                {
                    break;
                }
                if(score.RunsScored==-1)
                {
                    score.WicketDisplay();
                }

                else if (score.RunsScored>=0 && score.RunsScored<=6)
                {
                    score.RunDisplay();
                }
                else
                {
                    Console.WriteLine("Error!Please input (0 - 6), -1 or -2.");
                }
            }
            score.FinalDisplay();
            Console.ReadKey();


        }
    }
    
}