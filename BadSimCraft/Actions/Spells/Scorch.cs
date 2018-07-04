using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadSimCraft
{
    class Scorch : DamagingSpell
    {
        public Scorch() : base(2000, 10, 800)
        {

        }

        public override int CalculateDamage(Player player)
        {
            if (player.hasBuff<SupernovaEffect>())
            {
                float playerBaseCrit = player.crit;

                player.crit = 1;
                int baseDmg = base.CalculateDamage(player);
                player.crit = playerBaseCrit;

                return baseDmg;
            }

            else return base.CalculateDamage(player);
        }

        public override void OnFinish(Player player)
        {
            base.OnFinish(player);

            if (player.hasBuff<EnhanceTalent>() && player.hasBuffCount<EnhanceEffect>() < 20)
            {
                player.Take(new EnhanceEffect());
            }

        }
    }
}
