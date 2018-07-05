using System;
using System.Collections.Generic;

namespace ChaosOffice
{
    public class Room : Entity
    {
        public EntityList<Creature> Creatures;
        public EntityList<Item> Items;
        public Dictionary<string, Door> Connections;
        
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