using System;
using System.Collections.Generic;

namespace ChaosOffice
{
    public class Character : Actor
    {
        public DialogLayer[] Dialog {get; private set;}
        public Character(string name, string description, int maxHealth = 20, int armorClass = 12, int weaponlessDamageDice = 4, int weaponlessDamageModifier = 0, int weaponlessAccuracyModifier = 2, bool isAgressive = false, ConsoleColor color = ConsoleColor.Cyan) : base(name, description, maxHealth, armorClass, weaponlessDamageDice, weaponlessDamageModifier, weaponlessAccuracyModifier, isAgressive, color)
        {}

        public Character(string name, string description, DialogLayer[] dialog, ConsoleColor color = ConsoleColor.Cyan) : base(name, description, 20, 12, 4, 0, 2, false, color)
        {
            Dialog = dialog;
        }

        public void Say(int dialogLayerIndex)
        {
            DialogLayer dialogLayer = Dialog[dialogLayerIndex];
            Say(dialogLayer.Opening);
            List<DialogOption> dialogOptions = dialogLayer.GetAvailableDialogOptions();
            for (int i = 1; i <= dialogOptions.Count; i++)
            {
                Console.WriteLine(i + ": " + dialogOptions[i-1].Sentence);
            }
        }
    }
}