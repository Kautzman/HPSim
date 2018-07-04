using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadSimCraft
{
    public abstract class TargetedAction : Action
    {
        TargetingStrategy targetingStrategy;

        public TargetedAction(TargetingStrategy thisTargetingStrategy, int thisCastTime, int thisCooldownDuration = 0) : 
            base(thisCastTime, thisCooldownDuration)
        {
            targetingStrategy = thisTargetingStrategy;
        }

        public abstract List<Effect> GetEffects(Player player);

        public override void OnFinish(Player player)
        {
            List<Player> allTargets = targetingStrategy.GetTargets();

            // Apply effects to any targets
            allTargets.ForEach(target =>
            {
                GetEffects(player).ForEach(e => e.Apply(target));
            });

            base.OnFinish(player);

            //player.outputBuffer = $"{critMarker}{totalDmg}, heat = {ComputeHeatCost(player)}";
        }
    }
}
