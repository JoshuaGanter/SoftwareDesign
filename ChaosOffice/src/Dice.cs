using System;

namespace ChaosOffice
{
    class Dice
    {
        private static Dice _instance;
        private Random _random;
        private Dice()
        {
            _random = new Random();
        }
        public static int Roll(int faces)
        {
            if (_instance == null)
            {
                _instance = new Dice();
            }
            return _instance._random.Next(1, faces+1);
        }
    }
}