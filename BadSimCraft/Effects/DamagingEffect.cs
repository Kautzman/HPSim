using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadSimCraft
{
    class DamagingEffect : Effect
    {
        int totalDamage;

        public DamagingEffect(Action thisSource, int thisDamage) : base(thisSource)
        {
            totalDamage = thisDamage;
        }

        public override void Apply(Player target)
        {
            // TODO: Target Takes Damage and shit here.
            // target.damageEventsIn = totalDamage;
        }
    }
}
