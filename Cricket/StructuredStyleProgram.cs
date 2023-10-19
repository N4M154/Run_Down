using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cricket
{
    internal class StructuredStyleProgram
    {
        static void Main(string[] args)
        {


            string Batsman1, Batsman2, NewBatsman;
            int Runs = 0;
            int Wickets = 0;
            int[] RunsByBatsman1 = new int[20];
            int[] RunsByBatsman2 = new int[20];
            bool IsBatsman1Striker = true;
            int Balls = 0;
            double Overs = 0;
            int BallsInOver = 0;
            int RunsScored = 0;
            

            Console.WriteLine("Enter the name of batsman 1: ");
            Batsman1 = Console.ReadLine();
            Console.WriteLine("Enter the name of batsman 2: ");
            Batsman2 = Console.ReadLine();
            Console.WriteLine("\n");

            while (Overs < 1 && Wickets < 2) //1 over + 1 wicket
            {

                
                Console.WriteLine("Score: " + Runs + "/" + Wickets + " for Over: " + Overs + "." + BallsInOver + "");
                Console.WriteLine((IsBatsman1Striker ? "*" : "") + Batsman1 + ": " + (RunsScored == -1 ? ("After Wicket" + GetRunsString(RunsByBatsman1, Balls)) : (GetRunsString(RunsByBatsman1, Balls))));
                Console.WriteLine((!IsBatsman1Striker ? "*" : "") + Batsman2 + ": " + (RunsScored == -1 ? ("After Wicket" + GetRunsString(RunsByBatsman2, Balls)) : (GetRunsString(RunsByBatsman2, Balls))));
                Console.WriteLine("________________________________________________________________________________________");

                
                Console.Write("Enter runs (0-6, -1 for wicket fall, -2 to exit the program): ");
                RunsScored = Convert.ToInt32(Console.ReadLine());

                if (RunsScored == -2)
                {
                     break;//exit the program
                }

                if (RunsScored == -1)
                {
                    
                    Wickets++;
                    if (IsBatsman1Striker)
                    { 
                        Console.WriteLine(Batsman1 + " is OUT!");
                    }
                    else
                    {
                        Console.WriteLine(Batsman2 + " is OUT!");
                    }
                   
                    // Check if there are wickets left
                    if (Wickets < 2)
                    { 
                        
                        Console.WriteLine("Enter the name of the new batsman: ");
                        NewBatsman = Console.ReadLine();
                        if (IsBatsman1Striker)
                        {
                            Batsman1 = NewBatsman;
                            RunsByBatsman1 = new int[20];
                            
                        }
                        else
                        {
                            Batsman2 = NewBatsman;
                            RunsByBatsman1 = new int[20];
                           
                        }
                        Balls = 0;
                    }
                }
                else if (RunsScored >= 0 && RunsScored <= 6)
                {
                    
                    Runs += RunsScored;

                    // Store runs in the batsman's individual array
                    if (IsBatsman1Striker)
                    {
                        RunsByBatsman1[Balls] = RunsScored;

                    }
                    else
                    {
                        RunsByBatsman2[Balls] = RunsScored;
                    }

                    // Swap striker if there is an odd number of runs scored
                    if (RunsScored % 2 == 1)
                    {
                        IsBatsman1Striker = !IsBatsman1Striker;
                    }

                    Balls++;
                    BallsInOver++;

                    // Check if the over is completed
                    if (BallsInOver == 6)
                    {
                        BallsInOver = 0;
                        Overs++;
                        IsBatsman1Striker = true; // Change striker at the end of the over
                    }
                }
                else
                {
                    Console.WriteLine("Error!Please input (0 - 6), -1 or -2.");
                }
            }
            Console.WriteLine("Score: " + Runs + "/" + Wickets + " for Over: " + Overs + "." + BallsInOver + "");
            Console.WriteLine((IsBatsman1Striker ? "*" : "") + Batsman1 + ": " + GetRunsString(RunsByBatsman1, Balls));
            Console.WriteLine((!IsBatsman1Striker ? "*" : "") + Batsman2 + ": " + GetRunsString(RunsByBatsman2, Balls));
            Console.WriteLine("________________________________________________________________________________________");
            //final score
            Console.WriteLine("Final Score: " + Runs + "/" + Wickets + " for Over: " + Overs + ".0");
            Console.ReadKey();
        }

        static string GetRunsString(int[] RunsArray, int balls)
        {
            string RunsString = "";
            for (int i = 0; i < balls; i++)
            {
                RunsString += RunsArray[i] + " ";
            }
            return RunsString;
        }

           
    }
}