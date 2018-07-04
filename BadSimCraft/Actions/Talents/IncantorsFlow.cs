using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadSimCraft
{ 
    class IncantorsFlow : Action
    {
        public IncantorsFlow() : base(null)
        {

        }
        public override void OnStart(Player player)
        {
            base.OnStart(player);
            player.Take(new IncantorsFlowEffect());
        }
    }
}
