using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadSimCraft
{
    class RuneOfFire : BuffSpell
    {
        public RuneOfFire(Player player) : base(new RuneofFireBuff(), new SingleTarget(player), 1000, 60000)
        {

        }
    }
}
