using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadSimCraft
{
    class FrostfireBolt : DamagingSpell
    {
        public FrostfireBolt(Player target) : base(new SingleTarget(target), 0.833f, 0, 0, 1500, 12000)
        {

        }
    }
}
