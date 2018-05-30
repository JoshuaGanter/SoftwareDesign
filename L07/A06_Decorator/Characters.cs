using System;

namespace A06_Decorator
{
    interface ICharacter
    {
        void Intimidate();  
    }

    class Monster : ICharacter
    {
        public void Intimidate()
        {
            Console.Write("Grrrrr!");
        }
    } 

    class Hero : ICharacter
    {
        public void Intimidate()
        {
            Console.Write("Weiche zurück!");
        }
    }
}