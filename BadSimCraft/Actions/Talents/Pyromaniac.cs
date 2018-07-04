using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadSimCraft
{
    class Pyromaniac : Action
    {
        public Pyromaniac() : base(null)
        {

        }
        public override void OnStart(Player player)
        {
            base.OnStart(player);
            player.Take(new PyromaniacBuff());
        }
    }
}
