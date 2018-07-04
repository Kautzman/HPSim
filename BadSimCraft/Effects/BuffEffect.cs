using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadSimCraft
{
    abstract class BuffEffect : Effect
    {
        Buff buff;

        public BuffEffect(Action thisSource, Buff thisBuff) : base (thisSource)
        {
            buff = thisBuff;
        }

        public override void Apply(Player target)
        {
            target.Take(buff);
        }
    }
}
