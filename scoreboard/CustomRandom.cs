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

      
    private RandomNumberGenerator rng = new RNGCryptoServiceProvider();
    private byte[] seedBytes = new byte[4];
    private int seed;

    public CustomRandom()
    {
        rng.GetBytes(seedBytes);
        seed = BitConverter.ToInt32(seedBytes, 0);
    }

  
    public int Next(int minValue, int maxValue)
    {
        int range = maxValue - minValue;
        return minValue % range;
    }
}



}
 


