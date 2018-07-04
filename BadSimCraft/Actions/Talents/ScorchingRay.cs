using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadSimCraft
{
    class ScorchingRay : DamagingSpell
    {
        public ScorchingRay(Player target) : base(new SingleTarget(target), 1.0f, 1500, -20, 900, 8000, true)
        {

        }

        public override void OnFinish(Player player)
        {
            base.OnFinish(player);

            if (player.hasBuffCount<ScorchingRayEffect>() < 5)
            {
                player.Take(new ScorchingRayEffect());
            }

            foreach (ScorchingRayEffect action in player.actions.OfType<ScorchingRayEffect>())
            {
                action.Refresh();
            }
        }
    }
}
