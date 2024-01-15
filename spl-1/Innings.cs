using System;
using System.Collections.Generic;
using System.Linq;

namespace scoreboard
{
    public class Innings
    {
        public string bat;
        public string bowl;
        public double overs;
        public int innings;
        public int Score=0;
        public int target = 0;
        public string wicketinover;
        private readonly IDisplayRunByOver displayRunByOver;
        private readonly IDisplayBoundaryGraph displayBoundaryGraph;
        private readonly IDisplayWicketFallingGraph displayWicketFallingGraph;
        public Innings(string bat, string bowl, double overs, int innings, int target)
        {
            this.bat = bat;
            this.bowl = bowl;
            this.overs = overs;
            this.innings = innings;
            this.target = target;
            displayRunByOver=new DisplayRunByOver();
            displayWicketFallingGraph = new DisplayWicketFallingGraph();
            displayBoundaryGraph= new DisplayBoundaryGraph();

        }
       
        public int Startgame(string bat, string bowl, double overs, int innings, int target)
        {   
            
            structuredclass inningsObj = new structuredclass(overs);
            int runs = inningsObj.TheFunction(bat, bowl, overs, innings, target);
           

            //Console.WriteLine("innings " + innings + " is starting");

            // Update the total score based on the innings result
            Score += runs;
            displayWicketFallingGraph.DisplayWicketFallingbyGraph(inningsObj.GetWicketsPerOver());
            displayRunByOver.DisplayRunbyOverGraph(inningsObj.GetRunPerOver());
            displayBoundaryGraph.DisplayBoundarynyGraph(inningsObj.GetBoundaryByOver());
            

            return Score;
       


        }

        

    }


        
}
