using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadSimCraft
{
    abstract class AreaOfEffect : TargetingStrategy
    {
        List<Player> targets;

        public AreaOfEffect(List<Player> thisTargets)
        {
            targets = thisTargets;
        }

        public virtual IEnumerable<Player> GetTargets()
        {
            return targets;
        }
    }
}
