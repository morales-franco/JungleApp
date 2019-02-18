using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace System
{
    public static class LongExtensions
    {
        public static decimal BytesToGb(this long bytes)
        {
            decimal total = bytes;

            for (int i = 0; i < 3; i++)
            {
                total = total / 1024;
            }

            return total;
        }
    }
}
