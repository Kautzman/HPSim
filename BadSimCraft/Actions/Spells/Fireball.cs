using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadSimCraft
{
    class Fireball : DamagingSpell
    {
        public Fireball(Player target) : base(new SingleTarget(target), 0.83f, 2200, 20, 1000)
        {

        }

        // TODO: Example Only, do not let it go live
        public override float GetCritChance(Player player)
        {
            return this.GetCritChance(player) * 2;
        }

        // Any damage mods would go here.
        public override float ComputeDamageMultiplier(Player player)
        {
            if (this.GetType() == typeof(Fireball) && player.hasBuff<FirebugBuff>())
            {
                heatMasteryMod = 400 * (1 / (1 + (player.mastery * 1.5f)));
            }
            else
            {
                heatMasteryMod = 400 * (1 / (1 + player.mastery));
            }

            return 1 + ((float)player.heat / heatMasteryMod);

            //baseDmg = (int)(baseDmg * (1 + ((float)player.heat / heatMasteryMod)));
        }

        public override void OnFinish(Player player)
        {
            base.OnFinish(player);

            if (player.hasBuff<EnhanceTalent>() && player.hasBuffCount<EnhanceBuff>() < 20)
            {
                player.Take(new EnhanceBuff());
            }
        }
    }
}
