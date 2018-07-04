using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadSimCraft
{
    class Firebug : Action
    {
        public Firebug() : base(null)
        {

        }
        public override void OnStart(Player player)
        {
            base.OnStart(player);
            player.Take(new FirebugEffect());
        }
    }
}
