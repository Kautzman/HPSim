﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadSimCraft
{
    abstract class BuffEffect : Effect
    {
        public BuffEffect(int? thisDuration = null) : base (thisDuration)
        {

        }
    }
}
