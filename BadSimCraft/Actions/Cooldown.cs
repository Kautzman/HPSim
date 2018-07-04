using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadSimCraft
{
    public class Cooldown<T> : Action where T : Action
    {
        bool isModifiedByHaste = false;

        public Cooldown(int thisDuration, bool thisIsModifiedByHaste = false) : base(thisDuration)
        {
            isModifiedByHaste = thisIsModifiedByHaste;
        }

        public override void OnStart(Player player)
        {
            base.OnStart(player);

            if (isModifiedByHaste)
            {
                cooldownDuration = (int)(cooldownDuration * player.getHasteMulti());
            }
        }
    }
}
