using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadSimCraft
{
    public class Spell : TargetedAction
    {
        bool isOnGCD;

        public Spell(TargetingStrategy thisTargetingStrategy, int thisCastTime, int thisCooldownDuration = 0,
            bool thisIsOnGCD = true, bool thisIsCooldownModifiedByHaste = false) : base(thisTargetingStrategy, thisCastTime, thisCooldownDuration)
        {
            isOnGCD = thisIsOnGCD;
        }

        //public Spell(TargetingStrategy thisTargetingStrategy, int thisCastTime, int thisCooldownDuration,
        //    bool thisIsOnGCD, bool thisIsCooldownModifiedByHaste, params Effect[] thisEffects) : 
        //    base(thisTargetingStrategy, thisCastTime, thisCooldownDuration)
        //{
        //    buffEffect = thisEffects.ToList();
        //    isOnGCD = thisIsOnGCD;
        //}

        //public Spell(TargetingStrategy thisTargetingStrategy, int thisCastTime, int thisCooldownDuration,
        //    bool thisIsOnGCD, params Effect[] thisEffects) : 
        //    this(thisTargetingStrategy, thisCastTime, thisCooldownDuration, thisIsOnGCD, false, thisEffects)
        //{

        //}

        //public Spell(TargetingStrategy thisTargetingStrategy, int thisCastTime, int thisCooldownDuration,
        //    params Effect[] thisEffects) :
        //    this(thisTargetingStrategy, thisCastTime, thisCooldownDuration, false, false, thisEffects)
        //{

        //}

        //public Spell(TargetingStrategy thisTargetingStrategy, int thisCastTime, params Effect[] thisEffects) :
        //    this(thisTargetingStrategy, thisCastTime, 0, false, false, thisEffects)
        //{

        //}

        public override void OnStart(Player player)
        {
            if (isOnGCD)
            {
                player.Take(new GlobalCoolDown());
            }
        }

        public override void OnFinish(Player player)
        {
            // Give resources, if any
            player.heat += ComputeHeatCost(player);

            // Heat specific stuff...
            if (!player.hasBuff<OverheatEffect>())
                player.heat = Util.Clamp(player.heat, 0, 100);

            player.Take(buffEffect);
            base.OnFinish(player);
        }
    }
}
