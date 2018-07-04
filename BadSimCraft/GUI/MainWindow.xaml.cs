using System;
using System.Windows;
using System.Threading;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Linq;

namespace BadSimCraft
{
    public partial class MainWindow : Window
    {
        bool run = true;
        //public static int gameTime;
        //readonly int gameInterval = 10;

        string playerActionText;
        string fireText;
        string dpsTotalText;
        string debugText;
        string passivesText;
        string damageText;

        ObservableCollection<SimEntry> log;
        SynchronizationContext uiContext = SynchronizationContext.Current;
        Player player = new Player();

        List<String> csvOutput = new List<String>();

        public static Dictionary<int, int> damageEvents = new Dictionary<int, int>();

        Simulator sim;

        public MainWindow()
        {
            InitializeComponent();
            sim = new Simulator(player);

            LogGrid.ItemsSource = sim.log;
        }

        public delegate void UpdateTextCallback(string text, TextBox textbox);

        //private void Update()
        //{
        //    gameTime += gameInterval;

        //    printOutput();

        //    EvaluatePlayerActions_Derp();
        //}

        //private void EvaluatePlayerActions_Derp()
        //{
        //    printOutput();

        //    if (!player.isGlobalCoolDown() && !player.IsCasting())
        //    {
        //        if ((player.heat >= 35 && player.hasBuffCount<EnlightenEffect>() < 2)
        //            || (player.heat >= 35 && player.remainingDuration<EnlightenEffect>() < 2000))
        //        {
        //            player.Take(new Pyroblast());
        //            playerActionText = "Casting Pyroblast";
        //        }
        //        else if (!player.isOnCooldown<LivingBomb>())
        //        {
        //            player.Take(new LivingBomb());
        //            playerActionText = "Casting Living Bomb";
        //        }
        //        else if (player.hasBuff<SupernovaEffect>())
        //        {
        //            player.Take(new Scorch());
        //            playerActionText = "Casting Scorch";
        //        }
        //        else if (!player.isOnCooldown<Meteor>() && player.heat >= 80 && player.hasBuffCount<EnhanceEffect>() == 20)
        //        {
        //            player.Take(new Meteor());
        //            playerActionText = "Casting Meteor";
        //        }
        //        else if (!player.isOnCooldown<ScorchingRay>() && player.heat >= 30)
        //        {
        //            player.Take(new ScorchingRay());
        //            playerActionText = "Casting Scorching Ray";
        //        }
        //        else if (player.heat > 75 && !player.isOnCooldown<RuneofFire>())
        //        {
        //            player.Take(new RuneofFire());
        //            playerActionText = "Casting Rune Of Fire";
        //        }
        //        else
        //        {
        //            //if (!player.isOnCooldown<FrostfireBolt>())
        //            //{
        //            //    player.Take(new FrostfireBolt());
        //            //    playerActionText = "Casting Frostfire Bolt";
        //            //}
        //            //else
        //            {
        //                player.Take(new Fireball());
        //                playerActionText = "Casting Fireball";
        //            }
        //        }
        //    }

        //    if(player.hasBuff<SupernovaEffect>() && player.heat <= 50 && !player.isOnCooldown<Fireblast>())
        //    {
        //        player.Take(new Fireblast());
        //        playerActionText = "Casting Fireblast";
        //    }

        //    player.PruneActions();

        //    player.ElapseTime(gameInterval);

        //    printOutput();
        //}

        //private string getDPS()
        //{
        //    int test = player.target.damageTaken;
        //    float result = 1000 * (((float)player.target.damageTaken) / gameTime);
        //    return result.ToString("0.00");
        //}

        //private static int getDPSLast20Seconds()
        //{
        //    return (damageEvents.Where(e => e.Key > gameTime - 20000).Sum(e => e.Value)) / 20;
        //}

        //private void printOutput()
        //{
        //    float readableTime = gameTime / 1000f;

        //    if (!String.IsNullOrEmpty(playerActionText))
        //    {
        //        fireText = player.heat.ToString();
        //        debugText = $"Ray-Stacks: {player.hasBuffCount<ScorchingRayEffect>()}, Ray-Duration: {player.remainingDuration<ScorchingRayEffect>()}";
        //        passivesText = $"Incantor's Flow: {player.actions.OfType<IncantorsFlowEffect>().FirstOrDefault().stacks}";
        //        dpsTotalText = getDPS();

        //        uiContext.Send(x => log.Add(new SimEntry(readableTime.ToString(), playerActionText, fireText, "", debugText, dpsTotalText, passivesText)), null);

        //        playerActionText = "";
        //        fireText = "";
        //        dpsTotalText = "";
        //        debugText = "";
        //        passivesText = "";
        //    }

        //    if (!String.IsNullOrWhiteSpace(player.outputBuffer))
        //    {
        //        damageText = ">>> " + player.outputBuffer;
        //        player.outputBuffer = "";

        //        uiContext.Send(x => log.Add(new SimEntry(readableTime.ToString(), damageText, player.heat.ToString(), player.target.damageTaken.ToString(), "", "", "")), null);

        //        csvOutput.Add($"{readableTime}, {getDPS()}, {(player.hasBuff<SupernovaEffect>() ? 800 : 0)}");
        //    }
        //}

        private void StartTheSim(object sender, RoutedEventArgs e)
        {
            if (sim.gameTime == 0)
            {
                sim.PrepareSim();
                player.SetPassives();
            }

            Thread loopThread = new Thread(async () =>
            {
                while (run == true)
                {
                    sim.Update();

                    if (sim.gameTime >= 500000)
                    {
                        run = false;
                    }
                }
            });

            loopThread.Start();

            // Console.WriteLine(sim.log);
        }

        private void StopTheSim(object sender, RoutedEventArgs e)
        {
            System.IO.File.WriteAllLines(@"C:\Users\Kautzman\Desktop\New folder\TESTANDSTUFF.csv", csvOutput);
        }
        private void ResetTheSim(object sender, RoutedEventArgs e)
        {
            sim.PrepareSim();
        }
    }
}
