using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadSimCraft
{
    public class Player
    {

        public Dictionary<int, int> damageEventsIn = new Dictionary<int, int>();
        public Dictionary<int, int> healingEventsIn = new Dictionary<int, int>();

        public int heat { get; set; }

        public bool isSupernova { get; set; }
        public Patchwerk target = new Patchwerk();

        public int durationEnlighten { get; set; }
        public int durationIntenseCold { get; set; }

        public bool hasFirebug { get; set; }
        public bool hasFrostfireAdept { get; set; }
        public bool hasCyromaniac { get; set; }
        public bool hasOverheat { get; set; }
        public bool hasExtremeTemp { get; set; }

        public float mastery { get; set; }
        public float crit { get; set; }
        public float haste { get; set; }
        public float spellDamage { get; set; }

        public HashSet<Action> actions = new HashSet<Action>();

        public string outputBuffer = "";

        public Player()
        {
            haste = 0.2f;
            mastery = 0.2f;
            crit = 0.2f;
            spellDamage = 180;
        }

        public void SetPassives()
        {
            Take(new Supernova());

            Take(new Pyromaniac());
            //Take(new Firebug());
            Take(new IncantorsFlow());
            Take(new Enhance());
            //Take(new Overheat());
        }

        //public Player getInstance()
        //{
        //    return this;
        //}

        public float getHasteMulti()
        {
            return 1 / (1 + haste);
        }

        public void Take(Action action)
        {
            actions.Add(action);
            action.OnStart(this);
        }

        public void ElapseTime(int time)
        {
            // Can't delete from a HashSet during iteration so...
            // HashSet<Action> actionsCopy = new HashSet<Action>();
            Action[] actionsCopy = new Action[actions.Count()];

            actions.CopyTo(actionsCopy);

            foreach (Action action in actionsCopy)
            {
                action.castTime -= time;
                action.Update(time, this);
            }

            // TODO: FOREACH PLAYER...
            PruneActions();
        }

        public void PruneActions()
        {
            actions.RemoveWhere(action =>
            {
                if (action.castTime != null && action.castTime <= 0)
                {
                    action.OnFinish(this);
                    return true;
                }
                return false;
            });
        }

        public void RemoveAction(Action action)
        {
            actions.Remove(action);
            action.OnFinish(this);
        }

        public bool IsCasting()
        {
            return actions.Any(action => typeof(TargetedAction).IsAssignableFrom(action.GetType()));
        }

        public bool isGlobalCoolDown()
        {
            return actions.Any(action => typeof(GlobalCoolDown).IsAssignableFrom(action.GetType()));
        }

        public bool isOnCooldown<T>() where T : Action
        {
            return actions.OfType<Cooldown<T>>().ToList().Any();
        }

        public bool hasBuff<T>() where T : Buff
        {
            return actions.OfType<T>().ToList().Any();
        }

        public int hasBuffCount<T>() where T : Buff
        {
            return actions.OfType<T>().ToList().Count();
        }

        public int? remainingDuration<T>() where T : Action
        {
            if (actions.OfType<T>().ToList().Count() > 0)
            {
                T action = actions.OfType<T>().ToList().First();
                return action.castTime;
            }

            return null;
        }
    }
}
