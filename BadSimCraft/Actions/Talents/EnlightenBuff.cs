using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadSimCraft
{
    class EnlightenBuff : Buff
    {
        public EnlightenBuff() : base(8000)
        {

        }

        public override void Update(int timePassed, Player player)
        {
            base.Update(timePassed, player);
        }

        public void Refresh()
        {
            castTime = 8000;
        }
    }
}
