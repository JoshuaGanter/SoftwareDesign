namespace ChaosOffice
{
    public abstract class Entity
    {
        public string Name {get; private set;}
        public string Description {get; private set;}

        public Entity(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}