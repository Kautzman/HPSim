using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadSimCraft
{
    class Combustion : BuffSpell
    {
        public Combustion(Player player) : base(new SingleTarget(player), 0, 120000)
        {

        }

        public override List<Effect> GetEffects(Player player)
        {
            return new List<Effect> { new CombustionBuff() };
        }
    }
}
