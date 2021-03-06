﻿namespace BadSimCraft 
{
    class Meteor : DamagingSpell
    {
        public Meteor(Player target) : base(new SingleTarget(target), 1.2f, 3000, 0, 1000, 30000)
        {

        }

        public override void OnStart(Player player)
        {
            castTime = castTime - (player.hasBuffCount<EnhanceBuff>() * 150);
            base.OnStart(player);
        }

        public override int ComputeHeatCost(Player player)
        {
            return (int)(-1 * (player.heat * (1 - (player.hasBuffCount<EnhanceBuff>() * 0.05))));
        }

        public override int CalculateDamage(Player player)
        {
            baseDmg = (int)(baseDmg * (1 + (0.05f * player.hasBuffCount<EnhanceBuff>())));
            return base.CalculateDamage(player);
        }
    }
}
