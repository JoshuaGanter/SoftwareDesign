using System;

namespace ChaosOffice
{
    public class Weapon : Item
    {
        public int DamageDice {get; private set;}
        public int DamageModifier {get; private set;}
        public int Accuracy {get; private set;}
        public Weapon(string name, string description, int damageDice, int damageModifier, int accuracy, ConsoleColor color = ConsoleColor.Green) : base(name, description, true, color)
        {
            DamageDice = damageDice;
            DamageModifier = damageModifier;
            Accuracy = accuracy;
        }

        public override void Print(string prefix = "", string suffix = "")
        {
            base.Print(prefix, " (DMG 1d" + DamageDice + DamageModifier.ToString("+0;-#") + ", ACC " + Accuracy.ToString("+#;-#;±0") + ")" + suffix);
        }
    }
}