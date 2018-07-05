using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadSimCraft
{
    class Fireblast : DamagingSpell
    {
        public Fireblast(Player target) : base(new SingleTarget(target), 0.66f, 0, 40, 300, 24000, false, false)
        {

        }
    }
}
