using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadSimCraft
{
    class Overheat : Action
    {
        public Overheat() : base(null)
        {

        }
        public override void OnStart(Player player)
        {
            base.OnStart(player);
            player.actions.RemoveWhere(action => action.GetType() == typeof(Supernova));
            player.Take(new OverheatEffect());
        }
    }
}
