using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadSimCraft
{
    public abstract class Effect
    {
        public Action source;

        public Effect(Action thisSource)
        {
            source = thisSource;
        }

        public abstract void Apply(Player target);
    }
}
