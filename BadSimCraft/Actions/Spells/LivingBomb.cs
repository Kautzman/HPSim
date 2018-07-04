using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadSimCraft
{
    class LivingBomb : BuffSpell
    {
        public LivingBomb() : base(0, 0, 0, 12000)
        {

        }

        public override void OnFinish(Player player)
        {
            player.Take(new LivingBombDot(player, false));
            base.OnFinish(player);
        }
    }
}
