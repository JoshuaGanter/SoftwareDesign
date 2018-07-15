using System;

namespace ChaosOffice
{
    public class Item : Entity
    {
        public bool Takeable {get; private set;}

        public Item(string name, string description, bool takeable = true, ConsoleColor color = ConsoleColor.Green) : base(name, description, color)
        {
            Takeable = takeable;
        }
    }
}