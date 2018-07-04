using System;

namespace BadSimCraft
{
    public abstract class Action
    {

        public int? castTime { get; set; }
        public int cooldownDuration { get; set; }
        public bool isCooldownModifiedByHaste { get; set; }
        public Player thisPlayer { get; set; }

        public Action(int? baseCastTime, int thisCooldownDuration = 0, bool thisIsCooldownModifiedByHaste = false)
        {
            castTime = baseCastTime;
            cooldownDuration = thisCooldownDuration;
            isCooldownModifiedByHaste = thisIsCooldownModifiedByHaste;

            if (castTime < 750 && castTime > 0)
            {
                castTime = 750;
            }
        }

        public virtual void OnStart(Player player)
        {
            thisPlayer = player;
            castTime = (int)(player.getHasteMulti()) * castTime;
        }

        public virtual void OnFinish(Player player)
        {
            if (cooldownDuration > 0)
            {
                player.Take((Action)Activator.CreateInstance(typeof(Cooldown<>).MakeGenericType(this.GetType()), cooldownDuration, isCooldownModifiedByHaste));
            }
        }

        public virtual void Update(int timePassed, Player player)
        {

        }
    }
}
