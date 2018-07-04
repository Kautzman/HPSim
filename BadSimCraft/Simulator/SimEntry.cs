using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadSimCraft
{
    public class SimEntry
    {
        public string time { get; set; }
        public string action { get; set; }
        public string fire { get; set; }
        public string damage { get; set; }
        public string extra { get; set; }
        public string passives { get; set; }
        public string dps { get; set; }

        public SimEntry(string thisTime, string thisAction, string thisFire, string thisDamage, string thisExtra, string thisDps, string thisPassives)
        {
            time = thisTime;
            action = thisAction;
            fire = thisFire;
            damage = thisDamage;
            extra = thisExtra;
            dps = thisDps;
            passives = thisPassives;
        }
    }
}
