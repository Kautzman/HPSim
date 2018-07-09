using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadSimCraft
{
    class RaidAoE : AreaOfEffect
    {
        // Hits Everyone in Raid/Party E.g. Tranq or Healing Tide
        public RaidAoE() : base (Raid.players)
        {

        }
    }
}
