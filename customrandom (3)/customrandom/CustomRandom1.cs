using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace customrandom
{
    public class CustomRandom
    {

       
            private RandomNumberGenerator rng = new RNGCryptoServiceProvider();
            private byte[] seedBytes = new byte[4];
            private int seed;

            public CustomRandom()
            {
                rng.GetBytes(seedBytes);
                seed = BitConverter.ToInt32(seedBytes, 0);
            }

            public int Next()
            {
                seed = (seed * 1664525 + 1013904223) % int.MaxValue;
                return seed;
            }

            public int Next(int minValue, int maxValue)
            {
                int range = maxValue - minValue;
                return minValue + Next() % range;
            }
        
    }
}
