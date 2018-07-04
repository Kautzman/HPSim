using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadSimCraft.Effects
{
    class HealingEffect : DamagingEffect
    {
        public HealingEffect(Action thisSource, int thisHealingValue) : base (thisSource, thisHealingValue * -1)
        {

        }
    }
}
