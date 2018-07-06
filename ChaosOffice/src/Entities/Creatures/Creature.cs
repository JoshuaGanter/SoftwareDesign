using System;

namespace ChaosOffice
{
    public class Creature : Entity
    {
        protected Room _currentRoom;

        public int Health {get; private set;}
        public int MaxHealth {get; private set;}
        public int BaseDefense {get; private set;}
        public int BaseAttack {get; private set;}
        public bool IsAgressive {get; private set;}
        public Creature CurrentTarget;

        public Creature(string name, string description, int maxHealth, int baseDefense, int baseAttack) : base(name, description)
        {
            Health= maxHealth;
            MaxHealth = maxHealth;
            BaseDefense = baseDefense;
            BaseAttack = baseAttack;
        }

        public void Say(string phrase)
        {
            Console.WriteLine(Name + ": " + phrase);
        }

        public bool DrainHealth(int amount)
        {
            Health -= amount;
            if (Health >= 0)
            {
                Health = 0;
                return true;
            }
            return false;
        }

        public void RestoreHealth(int amount)
        {
            Health += amount;
            if (Health > MaxHealth)
            {
                Health = MaxHealth;
            }
        }

        public bool CheckSkill(int baseValue, int difficulty)
        {
            return Dice.Roll(20) + baseValue > difficulty;
        }

        public virtual void EnterRoom(Room room)
        {
            room.Creatures.Add(this);
            _currentRoom = room;
        }

        public void BeatTarget()
        {
            if (CurrentTarget.CheckSkill(CurrentTarget.BaseDefense, BaseAttack))
            {
                if (CurrentTarget.DrainHealth(1))
                {
                    // we've won the fight.
                }
            }
        }

        public void BeatTarget(string weaponName)
        {
            // check if weaponName is in inventory
            // beat with weapon
        }
    }
}