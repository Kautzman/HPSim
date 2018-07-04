using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadSimCraft 
{
    class IncantorsFlowEffect : BuffEffect
    {
        int clock = 0;
        public int stacks = 1;
        bool climbing = true;

        public IncantorsFlowEffect() : base()
        {

        }

        public override void Update(int timePassed, Player player)
        {
            if(climbing)
            {
                clock += timePassed;
            }
            else if(!climbing)
            {
                clock -= timePassed;
            }

            if (clock >= 5000)
            {
                climbing = false;
            }
            else if (clock <= 0)
            {
                climbing = true;
            }

            stacks = (int)(clock / 1000) + 1;
        }
    }
}
