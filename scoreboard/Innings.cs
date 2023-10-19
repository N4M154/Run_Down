using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scoreboard
{
    public class Innings
    {
        public string bat;
        public string bowl;
        public int overs;
        public int innings;
        public int Score;

        public Innings(string bat, string bowl, int overs, int innings)
        {
            this.bat = bat;
            this.bowl = bowl;
            this.overs = overs;
            this.innings = innings;
        }
       
        public void Startgame()
        { 
            Console.WriteLine("innings " + innings + " is starting");

            while (overs != 0)
            {
                Console.WriteLine("next over is " + overs);
                Game game = new Game();
                string bat1 = "sheona";
                string bat2 = "faiza";

                int earnedscore = game.overstart(bat1, bat2);
                Score = Score + earnedscore;
                overs--;
            }
            Console.WriteLine("total score " + Score);

            

        }

    }
}
