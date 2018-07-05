namespace ChaosOffice
{
    public class ConsumeableItem : Item
    {
        public int HealthRegeneration {get; private set;}

        public ConsumeableItem(string name, string description, int healthRegeneration) : base(name, description)
        {
            HealthRegeneration = healthRegeneration;
        }
    }
}