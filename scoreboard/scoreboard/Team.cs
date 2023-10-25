using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scoreboard
{
    public class Team
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public string team1;
        public string team2, bowl, bat;

        public Team(string team1, string team2)
        {
            this.team1 = team1;
            this.team2 = team2;

        }
        
    }
}
