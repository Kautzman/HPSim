using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadSimCraft
{
    class Combustion : BuffSpell
    {
        public Combustion() : base(0, new CombustionEffect(), 120000)
        {

        }
    }
}
