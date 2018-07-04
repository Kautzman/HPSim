using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadSimCraft
{
    class RuneofFire : BuffSpell
    {
        public RuneofFire() : base(1000, new RuneofFireBuff(), 60000)
        {

        }
    }
}
