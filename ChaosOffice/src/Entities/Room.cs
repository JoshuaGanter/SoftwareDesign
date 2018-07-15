using System;
using System.Collections.Generic;

namespace ChaosOffice
{
    public class Room : Entity
    {
        public EntityList<Creature> Creatures {get; private set;}
        public EntityList<Item> Items {get; private set;}
        public Dictionary<string, Door> Connections {get; private set;}
        
        public Room(string name, string description) : base(name, description)
        {
            Creatures = new EntityList<Creature>();
            Items = new EntityList<Item>();
            Connections = new Dictionary<string, Door>();
        }

        public EntityList<Entity> GetAllEntities()
        {
            EntityList<Entity> result = new EntityList<Entity>();
            result.AddRange(Creatures);
            result.AddRange(Items);
            return result;
        }

        public void PrintRoomIntroduction()
        {
            Game.WriteLine();
            Game.WriteLine("  " + Name + "  ", ConsoleColor.Black, ConsoleColor.Gray);
            Game.WriteLine(Description);
        }

        public bool TryGetAggressiveCreature(out Creature aggressor)
        {
            int aggressiveCreatureIndex = Creatures.FindIndex(creature => creature.IsAggressive && creature.IsAlive);
            if (aggressiveCreatureIndex != -1)
            {
                aggressor = Creatures[aggressiveCreatureIndex];
                return true;
            }
            else
            {
                aggressor = null;
                return false;
            }
        }

        public void ExamineRoom()
        {
            if (Items.Count != 0)
            {
                Console.WriteLine("As you look through the room you see:");
                foreach (Item item in Items)
                {
                    item.Print("- ");
                }
            }
            if (Creatures.Count != 0)
            {
                Console.WriteLine("There are some creatures here:");
                foreach (Creature creature in Creatures)
                {
                    creature.Print("- ");
                }
            }
        }
    }
}