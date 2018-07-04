using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadSimCraft
{
    public class SingleTarget : TargetingStrategy
    {
        Player target;

        public SingleTarget(Player thisTarget)
        {
            target = thisTarget;
        }

        public List<Player> GetTargets()
        {
            return new List<Player> { target };
        }
    }
}
