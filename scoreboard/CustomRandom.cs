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

        // private instance variable. It holds the current seed value for the pseudo-random number generator
        public CustomRandom(int seed)
        {
            this.seed = seed;
        }

        // generates the next pseudo-random number in the sequence. 
        public int Next()
        {
            seed = (seed * 1103515245 + 12345) & 0x7FFFFFFF;
            //0x7FFFFFFF ensures that the generated number is a positive integer within the range of an int data type
            return seed;
        }
    }



}
 


