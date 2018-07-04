using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadSimCraft
{
    class Pyroblast : DamagingSpell
    {
        public Pyroblast() : base(0, -35, 800)
        {
            
        }

        public override int ComputeHeatCost(Player player)
        {
            if(player.hasBuff<SupernovaEffect>())
            {
                return base.ComputeHeatCost(player) + 30;
            }

            if(player.hasBuff<PyromaniacEffect>())
            {
                return base.ComputeHeatCost(player) + 5;
            }

            return base.ComputeHeatCost(player);
        }

        public override void OnFinish(Player player)
        {
            base.OnFinish(player);

            if (player.hasBuffCount<EnlightenEffect>() < 2)
            {
                player.Take(new EnlightenEffect());
            }

            foreach (EnlightenEffect action in player.actions.OfType<EnlightenEffect>())
            {
                action.Refresh();
            }

            if (player.hasBuff<EnhanceTalent>() && player.hasBuffCount<EnhanceEffect>() < 20)
            {
                player.Take(new EnhanceEffect());
            }
        }
    }
}
