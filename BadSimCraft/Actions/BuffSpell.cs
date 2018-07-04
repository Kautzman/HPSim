﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadSimCraft
{
    abstract class BuffSpell : Spell
    {

        Buff buff;
        public BuffSpell(Buff thisBuff, TargetingStrategy thisTargetingStrategy, int thisCastTime, int thisCooldownDuration = 0,
            bool thisIsOnGCD = true, bool thisIsCooldownModifiedByHaste = false) :
            base (thisTargetingStrategy, thisCastTime, thisCooldownDuration, thisIsOnGCD, thisIsCooldownModifiedByHaste)
        {
            buff = thisBuff;
        }

        public override List<Effect> GetEffects(Player player)
        {
            return new List<Effect>() { new BuffEffect(this, buff) };
        }
    }
}
