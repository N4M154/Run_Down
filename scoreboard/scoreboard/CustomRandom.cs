using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scoreboard
{
    public class CustomRandom
    {

        private int seed;

        public CustomRandom(int seed)
        {
            this.seed = seed;
        }

        public int Next()
        {
            seed = (seed * 1103515245 + 12345) & 0x7FFFFFFF;
            return seed;
        }
    }



}
 


