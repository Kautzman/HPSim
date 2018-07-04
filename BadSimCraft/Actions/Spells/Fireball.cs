using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadSimCraft
{
    class Fireball : DamagingSpell
    {
        public Fireball(Player target) : base(new SingleTarget(target), 2200, 20, 1000)
        {

        }

        public override void OnFinish(Player player)
        {
            base.OnFinish(player);

            if (player.hasBuff<EnhanceTalent>() && player.hasBuffCount<EnhanceEffect>() < 20)
            {
                player.Take(new EnhanceEffect());
            }
        }
    }
}
