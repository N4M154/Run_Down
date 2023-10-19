using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toss
{
     class randomtoss
    {
        public string Team1 { get; set; }
        public string Team2 { get; set; }

        public randomtoss(string team1, string team2)
        {
            Team1 = team1;
            Team2 = team2;
        }

        public string SimulateToss(Custom customRandom)
        {
            int tossResult = customRandom.Next() % 2;
            return tossResult == 0 ? Team1 : Team2;
        }






    }
}
