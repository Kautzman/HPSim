using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadSimCraft
{
    static class Util
    {
        public static int Clamp(int n, int l, int h)
        {
            return (n > h ? h : (n < l ? l : n));
        }
    }
}
