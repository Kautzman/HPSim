using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadSimCraft
{
    public class Simulator
    {
        bool run = true;
        public int gameTime;
        readonly int gameInterval = 10;

        Player player;

        public ObservableCollection<SimEntry> log;

        public Simulator()
        {
            log = new ObservableCollection<SimEntry>();
        }

        public Simulator(Player thisPlayer)
        {
            player = thisPlayer;
            log = new ObservableCollection<SimEntry>();
        }

        public void Update()
        {
            gameTime += gameInterval;
            EvaluatePlayerActions_Derp();

            // Foreach Boss, evalutate actions.
            // Foreach Player, evaluate actions.

            // printOutput();
        }

        public void PrepareSim()
        {
            gameTime = 0;
        }

        private void EvaluatePlayerActions_Derp()
        {
            //printOutput();

            if (!player.isGlobalCoolDown() && !player.IsCasting())
            {
                if ((player.heat >= 35 && player.hasBuffCount<EnlightenEffect>() < 2)
                    || (player.heat >= 35 && player.remainingDuration<EnlightenEffect>() < 2000))
                {
                    player.Take(new Pyroblast());
                    //playerActionText = "Casting Pyroblast";
                }
                else if (!player.isOnCooldown<LivingBomb>())
                {
                    player.Take(new LivingBomb());
                    //playerActionText = "Casting Living Bomb";
                }
                else if (player.hasBuff<SupernovaEffect>())
                {
                    player.Take(new Scorch());
                    //playerActionText = "Casting Scorch";
                }
                else if (!player.isOnCooldown<Meteor>() && player.heat >= 80 && player.hasBuffCount<EnhanceEffect>() == 20)
                {
                    player.Take(new Meteor());
                    //playerActionText = "Casting Meteor";
                }
                else if (!player.isOnCooldown<ScorchingRay>() && player.heat >= 30)
                {
                    player.Take(new ScorchingRay());
                    //playerActionText = "Casting Scorching Ray";
                }
                else if (player.heat > 75 && !player.isOnCooldown<RuneofFire>())
                {
                    player.Take(new RuneofFire());
                    //playerActionText = "Casting Rune Of Fire";
                }
                else
                {
                    //if (!player.isOnCooldown<FrostfireBolt>())
                    //{
                    //    player.Take(new FrostfireBolt());
                    //    playerActionText = "Casting Frostfire Bolt";
                    //}
                    //else
                    {
                        player.Take(new Fireball());
                        //playerActionText = "Casting Fireball";
                    }
                }
            }

            if (player.hasBuff<SupernovaEffect>() && player.heat <= 50 && !player.isOnCooldown<Fireblast>())
            {
                player.Take(new Fireblast());
                //playerActionText = "Casting Fireblast";
            }

            player.PruneActions(); // TODO: This needs to go away and be moved to the sim
            player.ElapseTime(gameInterval);

            //printOutput();
        }
    }
}
