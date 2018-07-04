namespace BadSimCraft 
{
    class Meteor : DamagingSpell
    {
        public Meteor() : base(3000, 0, 1000, 30000)
        {

        }

        public override void OnStart(Player player)
        {
            castTime = castTime - (player.hasBuffCount<EnhanceEffect>() * 150);
            base.OnStart(player);
        }

        public override int ComputeHeatCost(Player player)
        {
            return (int)(-1 * (player.heat * (1 - (player.hasBuffCount<EnhanceEffect>() * 0.05))));
        }

        public override int CalculateDamage(Player player)
        {
            baseDmg = (int)(baseDmg * (1 + (0.05f * player.hasBuffCount<EnhanceEffect>())));
            return base.CalculateDamage(player);
        }
    }
}
