using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadSimCraft
{
    class FrostfireBolt : DamagingSpell
    {
        public static int damage = 1500;

        public FrostfireBolt() : base(0, 0, damage, 12000)
        {

        }
    }
}
