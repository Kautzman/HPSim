using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadSimCraft
{
    public class Spell : TargetedAction
    {
        List<Effect> buffEffect;

        public Spell(int thisCastTime, DamagingSpell thisEffect, int thisCooldownDuration = 0, bool isOnGCD = true) : base(thisCastTime, thisCooldownDuration, isOnGCD)
        {
            buffEffect = thisEffect;
        }

        public override void OnFinish(Player player)
        {
            player.Take(buffEffect);
            base.OnFinish(player);
        }
    }
}
