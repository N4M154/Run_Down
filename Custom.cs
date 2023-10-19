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
        public Custom(int initialSeed)
        {
            RanValue = initialSeed;
        }

        public int Next()
        {

            RanValue = (RanValue * 1664525 + 1013904223) % int.MaxValue;
            return RanValue;
        }












    }
}
