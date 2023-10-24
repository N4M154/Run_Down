using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toss
{
     class Custom
    {
        private int RanValue;
        public Custom(int r)
        {
            RanValue = (int)DateTime.Now.Ticks; 
            // Initialize the seed with the current timestamp.
        }
    

        public int Next()
        {


            // Update the seed with the current timestamp (in milliseconds).
            RanValue = (int)(DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond);
            RanValue = (RanValue * 1664525 + 1013904223) % int.MaxValue;
            return RanValue;











            //RanValue = (RanValue * 1664525 + 1013904223) % int.MaxValue;
           // return RanValue;
        }












    }
}
