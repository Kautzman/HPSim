using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadSimCraft
{
    public class Supernova : Action
    {
        public Supernova() : base(null)
        {

        }
        public override void Update(int timePassed, Player player)
        {
            if(player.heat >= 100 && !player.hasBuff<SupernovaEffect>())
            {
                player.Take(new SupernovaEffect());
            }
        }

        //public override void Update(int timePassed, Player player)
        //{
        //    if (player.heat >= 100 && !player.hasBuff<SupernovaEffect>())
        //    {
        //        player.Take(new SupernovaEffect());
        //    }
        //}
    }
}
