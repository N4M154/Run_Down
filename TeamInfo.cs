using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scoreboard
{
    public class TeamInfo
    {



        public string Name { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Draws { get; set; }
        public double AvgCollectorRun { get; set; }
        public double AvgChasesRun { get; set; }
        public double AvgRunRate { get; set; }

    }
}
