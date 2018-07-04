using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadSimCraft
{
    class RuneofFireBuff : Buff
    {
        int timeElapsed = 0;
        int heatInterval = 50;

        public RuneofFireBuff() : base(10000)
        {

        }

        public override void Update(int timePassed, Player player)
        {
            timeElapsed += timePassed;

            if (timeElapsed % heatInterval == 0)
            {
                player.heat++;
            }
        }
    }
}
