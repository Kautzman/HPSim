using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadSimCraft
{
    public abstract class TargetableSpell : Spell
    {
        public TargetableSpell(Player target, int thisCastTime, int thisHeat, int thisBaseDmg, int thisCooldownDuration = 0, bool thisIsCooldownModifiedByHaste = false, bool thisIsOnGCD = true) : base (thisCastTime, thisHeat, thisBaseDmg, thisCooldownDuration = 0, thisIsCooldownModifiedByHaste = false, thisIsOnGCD = true) 
        {

        }

        public abstract void ApplyEffect();
    }
}
