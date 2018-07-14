using System;

namespace ChaosOffice
{
    public class ConsumeableItem : Item
    {
        public int HealthRegeneration {get; private set;}

        public ConsumeableItem(string name, string description, int healthRegeneration, ConsoleColor color = ConsoleColor.Green) : base(name, description, true, color)
        {
            HealthRegeneration = healthRegeneration;
        }
        
        public override void Print(string prefix = "", string suffix = "")
        {
            base.Print(prefix, " (LP " + HealthRegeneration.ToString("+#;-#;±0") + ")" + suffix);
        }
    }
}