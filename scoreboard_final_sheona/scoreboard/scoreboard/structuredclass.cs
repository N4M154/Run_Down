using System;
using System.Runtime.InteropServices;

namespace scoreboard
{


    public class structuredclass
    {
        
        public Team team=new Team();
        public double over;
        public structuredclass(double over)
        {

            this.over = over;
        }
        //public structuredclass(Team team) { this.team = team; }
        
        public int TheFunction(string battingTeam, string bowlingTeam, double overs, int innings, int target)
        {
            Batsman Batsman1, Batsman2, NewBatsman;
            int Runs = 0;
            int Wickets = 0;
            bool IsBatsman1Striker = true;
            double Balls = 0;
            double Overs = 0;
            double Runrate = 0;
            double BallsInOver = 0;
            int RunsScored = 0;
            int inning = innings;
            int targets=target;



            string[] batsmanList = team.GetPlayerList(battingTeam);
            string[] bowlerList = team.GetPlayerList(bowlingTeam);

            // Choose the first two batsmen automatically


            //using arrray to store player list and getting the names of the batsman from there
            Batsman1 = new Batsman(batsmanList[0]);

            Batsman2 = new Batsman(batsmanList[1]);


            /* Console.WriteLine("Enter the name of batsman 1: ");
             Batsman1 = new Batsman(Console.ReadLine());

             Console.WriteLine("Enter the name of batsman 2: ");
             Batsman2 = new Batsman(Console.ReadLine());

             Console.WriteLine("\n");*/

            while (Overs < over && Wickets < 11) 
            {

               
                Console.WriteLine("________________________________________________________________________________________");
                Console.WriteLine("Score: " + Runs + "/" + Wickets + " for Over: " + Overs + "." + BallsInOver );
                Console.WriteLine((IsBatsman1Striker ? "*" : "") + Batsman1.Name + ": " + Batsman1.Runs);
                Console.WriteLine((!IsBatsman1Striker ? "*" : "") + Batsman2.Name + ": " + Batsman2.Runs);
               
                Console.WriteLine("________________________________________________________________________________________");

                if (innings == 2 && Runs >= targets)
                {
                    return Runs;
                }

                Console.Write("Enter runs (0-6, -1 for wicket fall, -2 to exit the program): ");
                RunsScored = Convert.ToInt32(Console.ReadLine());

                if (RunsScored == -2)
                {
                    break; // Exit the program
                }

                if (RunsScored == -1)
                {
                    //will fall a wicket

                    //number of ball will increase
                    
                    //run will remain the same
                    
                    //will display the name of the upcoming batsman
                    
                    Wickets++;

                    if (IsBatsman1Striker)
                    {
                        Console.WriteLine(Batsman1.Name + " is OUT!");
                        NewBatsman = new Batsman(batsmanList[Wickets + 1]);
                        Batsman1 = NewBatsman;
                        Console.WriteLine("Next batsman: " + Batsman1.Name);
                    }
                    else
                    {
                        Console.WriteLine(Batsman2.Name + " is OUT!");
                        NewBatsman = new Batsman(batsmanList[Wickets + 1]);
                        Batsman2 = NewBatsman;
                        Console.WriteLine("Next batsman: " + Batsman2.Name);

                    }


                    


                    Balls++;
                    BallsInOver++;
                    if (BallsInOver == 6)
                    {
                        BallsInOver = 0;
                        IsBatsman1Striker = !IsBatsman1Striker;
                        Overs++;

                        Runrate = Runs / Overs;

                        // Display the score at the end of each over
                        Console.WriteLine("\nEnd of Over " + Overs + ": " + Runs + "/" + Wickets+ " runrate: "+ Runrate+"\n");

                        // Change striker at the end of the over
                    }
                }
                else if (RunsScored >= 0 && RunsScored <= 6)
                {
                    Runs += RunsScored;

                   
                    
                    Balls++;
                    
                    BallsInOver++;

                   

                    if (IsBatsman1Striker)
                    {
                        Batsman1.AddRuns(RunsScored);
                    }
                    else
                    {
                        Batsman2.AddRuns(RunsScored);
                    }

                    if (RunsScored % 2 == 1)
                    {
                        IsBatsman1Striker = !IsBatsman1Striker;
                    }

                    

                    if (BallsInOver == 6)
                    {
                        BallsInOver = 0;
                        IsBatsman1Striker = !IsBatsman1Striker;

                        Overs++;

                        Runrate = Runs / Overs;

                        // Display the score at the end of each over
                        Console.WriteLine("End of Over " + Overs + ": " + Runs + "/" + Wickets + " runrate: " + Runrate);

                        // Change striker at the end of the over
                    }

                   
                }
                else
                {
                    Console.WriteLine("Error! Please input (0 - 6), -1, or -2.");
                }


                if (innings == 2 && Runs > targets)
                {
                    return Runs;
                }


            }



            // Display the final score
            Console.WriteLine("Final Score: " + Runs + "/" + Wickets + " for Over: " + Overs + "." + BallsInOver+ " Runrate: "+ Runrate);
            return Runs;
            


        }
       
    }
}
