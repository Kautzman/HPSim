using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadSimCraft
{
    class ScorchingRayEffect : BuffEffect
    {

        public ScorchingRayEffect() : base(10000)
        {

        }

        public override void OnStart(Player player)
        {
            base.OnStart(player);
            player.haste += 0.05f;
        }

        public override void OnFinish(Player player)
        {
            base.OnFinish(player);
            player.haste -= 0.05f;
        }

        public override void Update(int timePassed, Player player)
        {
            base.Update(timePassed, player);
        }

        public void Refresh()
        {
            castTime = 10000;
        }
    }
}
