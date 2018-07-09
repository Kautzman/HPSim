using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadSimCraft.Actions.TargetingStrategies
{
    // Smart Heal - Chooses lowest health targets E.g. CoH or Wild Growth
    class SmartHealAoE : RaidAoE
    {
        int targetLimit;

        public SmartHealAoE (int thisTargetLimit)
        {
            targetLimit = thisTargetLimit;
        }

        public override IEnumerable<Player> GetTargets()
        {
            List<Player> targets = base.GetTargets().ToList();

            targets.Sort(new HealthComparison());
            //targets.Sort(Comparer<Player>.Create((p1, p2) => p1.health - p2.health));

            return targets.Take(targetLimit);
        }
    }
}
