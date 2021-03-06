using System;

namespace ChaosOffice
{
    public class Creature : Entity
    {
        protected int Health;
        protected int MaxHealth;
        public int ArmorClass {get; private set;}
        public int WeaponlessDamageDice {get; private set;}
        public int WeaponlessDamageModifier {get; private set;}
        public int WeaponlessAccuracyModifier {get; private set;}
        public bool IsAggressive {get; private set;}
        public bool IsAlive
        {
            get
            {
                return Health > 0;
            }
        }
        public Room CurrentRoom {get; protected set;}
        public Creature CurrentTarget;

        public Creature(string name, string description, int maxHealth = 20, int armorClass = 12, int weaponlessDamageDice = 4, int weaponlessDamageModifier = 0, int weaponlessAccuracyModifier = 2, bool isAggressive = false, ConsoleColor color = ConsoleColor.Magenta) : base(name, description, color)
        {
            Health= maxHealth;
            MaxHealth = maxHealth;
            ArmorClass = armorClass;
            WeaponlessDamageDice = weaponlessDamageDice;
            WeaponlessDamageModifier = weaponlessDamageModifier;
            WeaponlessAccuracyModifier = weaponlessAccuracyModifier;
            IsAggressive = isAggressive;
        }

        public void Say(string phrase)
        {
            Print("", ": " + phrase);
        }

        public bool DrainHealth(int amount)
        {
            Health -= amount;
            Health = Math.Clamp(Health, 0, MaxHealth);
            Print("", " was hit for " + amount + " damage. (Current HP: " + Health + ")", true);
            if (Health == 0)
            {
                Print("", " was defeated!", true);
                return true;
            }
            return false;
        }

        public void RestoreHealth(int amount)
        {
            Health += amount;
            Health = Math.Clamp(Health, 0, MaxHealth);
            Print("", " was healed for " + amount + " HP. (" + Health + "/" + MaxHealth + " HP remain).");
        }

        private bool MakeAbilityCheck(int modifier, int difficultyClass)
        {
            int diceResult = Dice.Roll(20);
            bool success = diceResult + modifier > difficultyClass;
            Print("", " threw a " + diceResult + "+" + modifier + " (DC: " + difficultyClass + "), check " + (success ? "succeeded." : "failed."));
            return success;
        }

        public virtual void EnterRoom(Room room)
        {
            room.Creatures.Add(this);
            CurrentRoom = room;
        }

        public void BeatTarget()
        {
            BeatTarget(WeaponlessDamageDice, WeaponlessDamageModifier, WeaponlessAccuracyModifier);
        }

        public void BeatTarget(int damageDice, int damageModifier, int accuracyModifier)
        {
            if (MakeAbilityCheck(accuracyModifier, CurrentTarget.ArmorClass))
            {
                int damageDealt = Math.Max(0, Dice.Roll(damageDice) + damageModifier);
                CurrentTarget.DrainHealth(damageDealt);
            }
            else
            {
                CurrentTarget.Print("", " dodged the attack!");
            }
        }

        public void Print(string prefix = "", string suffix = "", bool muteDead = false)
        {
            base.Print(prefix, suffix + (IsAlive || muteDead ? "" : " *dead*"));
        }
    }
}
