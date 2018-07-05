using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadSimCraft
{
    class Pyroblast : DamagingSpell
    {
        public Pyroblast(Player target) : base(new SingleTarget(target), 1.033f, 0, -35, 800)
        {
            
        }

        public override int ComputeHeatCost(Player player)
        {
            if(player.hasBuff<SuperNovaBuff>())
            {
                return base.ComputeHeatCost(player) + 30;
            }

            if(player.hasBuff<PyromaniacBuff>())
            {
                return base.ComputeHeatCost(player) + 5;
            }

            return base.ComputeHeatCost(player);
        }

        public override void OnFinish(Player player)
        {
            base.OnFinish(player);

            if (player.hasBuffCount<EnlightenBuff>() < 2)
            {
                player.Take(new EnlightenBuff());
            }

            foreach (EnlightenBuff action in player.actions.OfType<EnlightenBuff>())
            {
                action.Refresh();
            }

            if (player.hasBuff<EnhanceTalent>() && player.hasBuffCount<EnhanceBuff>() < 20)
            {
                player.Take(new EnhanceBuff());
            }
        }
    }
}
