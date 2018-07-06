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
    }
}