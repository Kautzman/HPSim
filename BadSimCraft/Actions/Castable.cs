using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadSimCraft
{
    // TODO: Is this a dead class?
    abstract class Castable : Action
    {
        bool isOnGCD;

        public Castable(int castTime, int thisCooldownDuration = 0, bool thisIsOnGCD = true) : base ((int)(player.getHasteMulti() * castTime), thisCooldownDuration)
        {
            isOnGCD = thisIsOnGCD;
        }

        public override void OnStart(Player player)
        {
            if (isOnGCD)
            {
                player.Take(new GlobalCoolDown());
            }
        }
    }
}
