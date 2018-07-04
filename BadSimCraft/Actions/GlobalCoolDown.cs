using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadSimCraft
{
    public class GlobalCoolDown : Action
    {
        public GlobalCoolDown() : base (1500)
        {

        }
    }
}
