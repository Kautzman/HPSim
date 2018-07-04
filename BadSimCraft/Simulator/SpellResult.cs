using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadSimCraft
{
    public class SpellResult
    {
        Player caster;
        Dictionary<Player, int> damageEvents = new Dictionary<Player, int>();
        Dictionary<Player, List<DamagingSpell>> buffEvents = new Dictionary<Player, List<DamagingSpell>>();
    }
}
