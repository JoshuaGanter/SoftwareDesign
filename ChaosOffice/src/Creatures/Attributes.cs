namespace ChaosOffice
{
    public struct Attributes
    {
        public Attributes(int health, int maxHealth, int baseDefense, int baseAttack)
        {
            Health = health;
            MaxHealth = maxHealth;
            BaseDefense = baseDefense;
            BaseAttack = baseAttack;
        }
        public int Health;
        public int MaxHealth;
        public int BaseDefense;
        public int BaseAttack;
    }
}