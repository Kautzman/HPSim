using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadSimCraft
{
    class RuneofFireEffect : BuffEffect
    {
        int timeElapsed = 0;
        int heatInterval = 50;

        public RuneofFireEffect() : base(10000)
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
