using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadSimCraft
{
    class BuffEffect : Effect
    {
        List<Buff> buffs;

        public BuffEffect(Action thisSource, params Buff[] thisBuffs) : base (thisSource)
        {
            buffs = thisBuffs.ToList();
        }

        public override void Apply(Player target)
        {
            buffs.ForEach(b => target.Take(b));
        }
    }
}
