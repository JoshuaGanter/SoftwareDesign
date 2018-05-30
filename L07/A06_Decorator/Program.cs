using System;
using System.Collections.Generic;

namespace A06_Decorator
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<ICharacter> characters = new List<ICharacter>();

            characters.Add(new Monster());
            characters.Add(new Hero());
            characters.Add(new IllCharacter(new Hero()));
            characters.Add(new IllCharacter(new IllCharacter(new Monster())));
            characters.Add(new HoarseCharacter(new Monster()));
            characters.Add(new IllCharacter(new HoarseCharacter(new Hero())));

            foreach (var character in characters)
            {
                character.Intimidate();
                Console.WriteLine();
            }

        }
    }
}
