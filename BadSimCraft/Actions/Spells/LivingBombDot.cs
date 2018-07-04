using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadSimCraft
{
    class LivingBombDot : Buff
    {
        // Is this the Og living bomb, or the spread?
        bool isPrimary;

        public LivingBombDot(Player target, bool thisIsPrimary = true) : base(12000)
        {
            isPrimary = thisIsPrimary;
        }

        public override void OnFinish(Player player)
        {
            player.Take(new LivingBombExplosion());
            base.OnFinish(player);
        }
    }
}
