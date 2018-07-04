using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadSimCraft
{
    public interface TargetingStrategy
    {
        List<Player> GetTargets();
    }
}
