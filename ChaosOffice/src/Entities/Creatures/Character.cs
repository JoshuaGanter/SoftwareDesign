using System;
using System.Collections.Generic;

namespace ChaosOffice
{
    public class Character : Actor
    {
        public DialogLayer[] Dialog {get; private set;}
        public Character(string name, string description, int maxHealth, int baseDefense, int baseAttack, DialogLayer[] dialog) : base(name, description, maxHealth, baseDefense, baseAttack)
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