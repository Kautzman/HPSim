using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadSimCraft
{
    public class SuperNovaBuff : Buff
    {
        int timeElapsed = 0;
        readonly int heatInterval = 60;

        public override void Update(int timePassed, Player player)
        {
            timeElapsed += timePassed;

            if(timeElapsed % heatInterval == 0)
            {
                player.heat--;
            }

            if(player.heat <= 0)
            {
                player.RemoveAction(this);
            }
        }
        
        public override void OnStart(Player player)
        {
            base.OnStart(player);
            player.haste += 0.2f;
        }

        public override void OnFinish(Player player)
        {
            base.OnFinish(player);
            player.haste -= 0.2f;
        }
    }
}
