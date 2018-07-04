using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadSimCraft
{
    public abstract class DamagingSpell : Spell
    {
        Random random = new Random(Guid.NewGuid().GetHashCode());
        public int heat { get; set; }
        public float heatMasteryMod { get; set; } = 400f;
        public int baseDmg { get; set; }
        public float spellDamageCoefficient;

        public int totalDmg { get; set; }
        public string critMarker { get; set; }

        public DamagingSpell(TargetingStrategy thisTargetingStrategy, float thisSpellDamageCoefficient, int thisCastTime, int thisHeat,
            int thisBaseDmg, int thisCooldownDuration = 0, bool thisIsCooldownModifiedByHaste = false, bool thisIsOnGCD = true)
            : base(thisTargetingStrategy, thisCastTime, thisCooldownDuration, thisIsOnGCD, thisIsCooldownModifiedByHaste)
        {
            spellDamageCoefficient = thisSpellDamageCoefficient;
            baseDmg = thisBaseDmg;
            heat = thisHeat;
        }

        // TODO: Get rid of this...
        public virtual int ComputeHeatCost(Player player)
        {
            // We don't charge more heat for Spenders in Overheat.
            if(player.hasBuff<OverheatBuff>() && heat > 0)
            {
                return (int)(heat * 1.2);
            }
            return heat;
        }

        public virtual float GetCritChance(Player player)
        {
            return player.crit;
        }

        public override List<Effect> GetEffects(Player player)
        {
            return new List<Effect>() { new DamagingEffect(this, CalculateDamage(player)) };
        }

        public virtual float ComputeDamageMultiplier(Player player)
        {
            return 1;
        }

        public virtual float GetSpellDamageModifier(Player player)
        {
            return player.spellDamage * GetSpellDamageCoefficient();
        }

        public virtual float GetSpellDamageCoefficient()
        {
            return spellDamageCoefficient;
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

            if (this.GetType() == typeof(Fireball) && player.hasBuff<FirebugBuff>())
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
                baseDmg = (int)(baseDmg * (1 + ((player.actions.OfType<PyromaniacBuff>().ToList().Count()) * 0.10)));
            }

            // Empower

            if (this.GetType() == typeof(Scorch) || this.GetType() == typeof(Fireball) || this.GetType() == typeof(Pyroblast))
            {
                baseDmg = (int)(baseDmg * (1 + ((player.actions.OfType<EmpowerBuff>().ToList().Count()) * 0.15)));
                player.actions.RemoveWhere(action => action.GetType() == typeof(EmpowerBuff));
            }

            // Enlighten

            if (this.GetType() == typeof(Scorch) || this.GetType() == typeof(Fireball))
            {
                baseDmg = (int)(baseDmg * (1 + ((player.actions.OfType<EnlightenBuff>().ToList().Count()) * 0.08)));
            }

            // Incantor's Flow

            if (player.hasBuff<IncantorsFlowBuff>())
            {
                baseDmg = (int)(baseDmg * (1 + (0.04 * player.actions.OfType<IncantorsFlowBuff>().FirstOrDefault().stacks)));
            }

            totalDmg = baseDmg;

            //MainWindow.damageEvents.Add(MainWindow.gameTime, totalDmg);

            //return baseDmg;
            return totalDmg;
        }
    }
}
