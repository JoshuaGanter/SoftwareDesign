using System;

namespace ChaosOffice
{
    public class Actor : Creature
    {
        public EntityList<Item> Inventory {get; private set;}

        public Actor(string name, string description, int maxHealth, int baseDefense, int baseAttack) : base(name, description, maxHealth, baseDefense, baseAttack)
        {
            Inventory = new EntityList<Item>();
        }

        public void TakeItem(string itemName)
        {
            if (_currentRoom.Items.Contains(itemName))
            {
                Item item = _currentRoom.Items.Get(itemName);
                if (item.Takeable)
                {
                    _currentRoom.Items.Remove(item);
                    Inventory.Add(item);
                    Console.WriteLine(Name + " took " + itemName + ".");
                }
                else
                {
                    Say("Ouuuhaarrrg. I cannot put " + itemName + " in my pockets.");
                }
            }
            else
            {
                Say("Damn, i can't find " + itemName + " anywhere.");
            }
        }

        public void DropItem(string itemName)
        {
            if (Inventory.Contains(itemName))
            {
                Item item = Inventory.Get(itemName);
                Inventory.Remove(item);
                _currentRoom.Items.Add(item);
                Console.WriteLine(Name + " dropped " + itemName + ".");
            }
            else
            {
                Say("Damn, i can't find " + itemName + " in my pockets.");
            }
        }

        public void ConsumeItem(string itemName)
        {
            if (Inventory.Contains(itemName))
            {
                ConsumeableItem item = Inventory.Get(itemName) as ConsumeableItem;
                if (item != null)
                {
                    RestoreHealth(item.HealthRegeneration);
                    Console.WriteLine(Name + " used " + itemName + ".");
                }
                else
                {
                    Say("I'd rather not consume " + itemName + ".");
                }
            }
            else
            {
                Say("Damn, i can't find " + itemName + " in my pockets.");
            }
        }
    }
}