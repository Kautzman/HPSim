﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadSimCraft
{
    class Empower : BuffSpell
    {
        public Empower(Player player) : base(new EmpowerBuff(), new SingleTarget(player), 0, 0)
        {

        }
    }
}
