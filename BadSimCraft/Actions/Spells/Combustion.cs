using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadSimCraft
{
    class Combustion : BuffSpell
    {
        // CarlQuestion: I don't think this is right - Do we give the constructor a single Buff or a List of Buffs?
        public Combustion(Player target) : base(GetEffects(), new SingleTarget(target), 0, 120000)
        {

        }

        public override List<Effect> GetEffects(Player player)
        {
            return new List<Effect> { new CombustionBuff() };
        }
    }
}
