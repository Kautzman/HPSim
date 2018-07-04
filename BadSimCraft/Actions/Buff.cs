using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadSimCraft
{
    public abstract class Buff : Action
    {
        public Buff(int? thisDuration = null) : base (thisDuration)
        {

        }
    }
}
