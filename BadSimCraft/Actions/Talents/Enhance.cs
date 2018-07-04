using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadSimCraft
{
    class Enhance : Action
    {
        public Enhance() : base(null)
        {

        }

        public override void OnStart(Player player)
        {
            player.Take(new EnhanceTalent());
            base.OnStart(player);
        }
    }
}
