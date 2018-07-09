using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadSimCraft
{
    public class HealthComparison : Comparer<Player>
    {
        public override int Compare(Player x, Player y)
        {
            return x.health - y.health;
        }
    }
}
