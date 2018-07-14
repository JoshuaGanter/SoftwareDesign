using System;

namespace ChaosOffice
{
    public abstract class Entity
    {
        protected ConsoleColor _color;

        public string Name {get; private set;}
        public string Description {get; private set;}

        public Entity(string name, string description, ConsoleColor color = ConsoleColor.Gray)
        {
            Name = name;
            Description = description;
            _color = color;
        }

        public virtual void Print(string prefix = "", string suffix = "")
        {
            Game.Write(prefix);
            Game.Write(Name, _color);
            Game.WriteLine(suffix);
        }
    }
}