using System;

namespace A06_Decorator
{
    abstract class CharacterDecorator : ICharacter
    {
        protected ICharacter _original;
        public CharacterDecorator(ICharacter original)
        {
            _original = original;
        }
        public abstract void Intimidate();
    }

    class IllCharacter : CharacterDecorator
    {
        public IllCharacter(ICharacter original) : base(original)
        { }
        public override void Intimidate()
        {
            _original.Intimidate();
            Console.Write(" *hust*");
        }
    }

    class HoarseCharacter : CharacterDecorator
    {
        public HoarseCharacter(ICharacter original) : base(original)
        { }
        public override void Intimidate()
        {
            Console.Write("*räusper* ");
            _original.Intimidate();
        }
    }
}