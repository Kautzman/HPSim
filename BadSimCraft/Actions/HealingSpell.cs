using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadSimCraft
{
    class HealingSpell : DamagingSpell
    {
        public HealingSpell(
          TargetingStrategy thisTargetingStrategy,
          float thisSpellDamageCoefficient,
          int thisCastTime,
          int thisHeat,
          int thisBaseDmg,
          int thisCooldownDuration = 0,
          bool thisIsCooldownModifiedByHaste = false,
          bool thisIsOnGCD = true
        ) : base (
          thisTargetingStrategy,
          thisSpellDamageCoefficient,
          thisCastTime,
          thisHeat,
          thisBaseDmg,
          thisCooldownDuration,
          thisIsOnGCD,
          thisIsCooldownModifiedByHaste
        )
        {

        }

        public override List<Effect> GetEffects(Player player)
        {
            return new List<Effect>() { new DamagingEffect(this, CalculateDamage(player)) };
        }
    }
}
