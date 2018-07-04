using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadSimCraft
{
    public abstract class DamagingSpell : Spell
    {
        TargetingStrategy targetingStrategy;

        Random random = new Random(Guid.NewGuid().GetHashCode());
        public int heat { get; set; }
        public float heatMasteryMod { get; set; } = 400f;
        public int baseDmg { get; set; }

        public int totalDmg { get; set; }
        public string critMarker { get; set; }

        public DamagingSpell(TargetingStrategy thisTargetingStrategy, int thisCastTime, int thisHeat, int thisBaseDmg, int thisCooldownDuration = 0, bool thisIsCooldownModifiedByHaste = false, bool thisIsOnGCD = true) : base(thisCastTime, thisCooldownDuration, thisIsOnGCD, thisIsCooldownModifiedByHaste)
        {
            targetingStrategy = thisTargetingStrategy;
            baseDmg = thisBaseDmg;
            heat = thisHeat;
        }

        public virtual int ComputeHeatCost(Player player)
        {
            // We don't charge more heat for Spenders in Overheat.
            if(player.hasBuff<OverheatEffect>() && heat > 0)
            {
                return (int)(heat * 1.2);
            }
            return heat;
        }

        public override void OnFinish(Player player)
        {
            List<Player> allTargets = targetingStrategy.GetTargets();

            // Give resources, if any
            player.heat += ComputeHeatCost(player);

            // Heat specific stuff...
            if (!player.hasBuff<OverheatEffect>())
                player.heat = Clamp(player.heat, 0, 100);

            // Apply damage to any targets
            foreach (Player target in allTargets)
            {
                target.damageTaken += CalculateDamage(player);
            }

            base.OnFinish(player);

            //player.outputBuffer = $"{critMarker}{totalDmg}, heat = {ComputeHeatCost(player)}";
        }

        public int Clamp(int n, int l, int h)
        {
            return (n > h ? h : (n < l ? l : n));
        }
        public virtual int CalculateDamage(Player player)
        {
            critMarker = "";
            double rand = random.NextDouble();

            /******************
             * Special Cases
             * ***************/

            if (this.GetType() == typeof(Meteor))
            {
                baseDmg += (int)(100 * (player.heat / 5));
            }

            // Crit Roll
            if (rand <= player.crit)
            {
                baseDmg = baseDmg * 2;
                critMarker = "*";
            }


            // Heating Up and Mastery

            // TALENT: Firebug

            if (this.GetType() == typeof(Fireball) && player.hasBuff<FirebugEffect>())
            {
                heatMasteryMod = 400 * (1 / (1 + (player.mastery * 1.5f)));
            }
            else
            {
                heatMasteryMod = 400 * (1 / (1 + player.mastery));
            }

            baseDmg = (int)(baseDmg * (1 + ((float)player.heat / heatMasteryMod)));




            /***********
             * TALENTS (Most of them anyway) 
             ***********/


            // Pryomaniac

            if (this.GetType() == typeof(Pyroblast))
            {
                baseDmg = (int)(baseDmg * (1 + ((player.actions.OfType<PyromaniacEffect>().ToList().Count()) * 0.10)));
            }

            // Empower

            if (this.GetType() == typeof(Scorch) || this.GetType() == typeof(Fireball) || this.GetType() == typeof(Pyroblast))
            {
                baseDmg = (int)(baseDmg * (1 + ((player.actions.OfType<EmpowerEffect>().ToList().Count()) * 0.15)));
                player.actions.RemoveWhere(action => action.GetType() == typeof(EmpowerEffect));
            }

            // Enlighten

            if (this.GetType() == typeof(Scorch) || this.GetType() == typeof(Fireball))
            {
                baseDmg = (int)(baseDmg * (1 + ((player.actions.OfType<EnlightenEffect>().ToList().Count()) * 0.08)));
            }

            // Incantor's Flow

            if (player.hasBuff<IncantorsFlowEffect>())
            {
                baseDmg = (int)(baseDmg * (1 + (0.04 * player.actions.OfType<IncantorsFlowEffect>().FirstOrDefault().stacks)));
            }

            totalDmg = baseDmg;

            //MainWindow.damageEvents.Add(MainWindow.gameTime, totalDmg);

            //return baseDmg;
            return totalDmg;
        }
    }
}
