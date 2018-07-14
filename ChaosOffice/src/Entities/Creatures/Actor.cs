using System;

namespace ChaosOffice
{
    public abstract class Actor : Creature
    {
        public EntityList<Item> Inventory {get; private set;}

        public Actor(string name, string description, int maxHealth = 20, int armorClass = 12, int weaponlessDamageDice = 4, int weaponlessDamageModifier = 0, int weaponlessAccuracyModifier = 2, bool isAgressive = false, ConsoleColor color = ConsoleColor.Cyan) : base(name, description, maxHealth, armorClass, weaponlessDamageDice, weaponlessDamageModifier, weaponlessAccuracyModifier, isAgressive, color)
        {
            Inventory = new EntityList<Item>();
        }
    }
}