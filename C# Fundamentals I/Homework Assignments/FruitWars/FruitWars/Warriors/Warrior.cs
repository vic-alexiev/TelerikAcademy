using FruitWars.Fruits;

namespace FruitWars.Warriors
{
    public abstract class Warrior : GameObject
    {
        protected Warrior(int speed, int power, int index, char character)
            : base(character)
        {
            Speed = speed;
            Power = power;
            Index = index;
            RemainingMoves = Speed;
        }

        public int Speed { get; private set; }

        public int Power { get; private set; }

        public int Index { get; private set; }

        public int RemainingMoves { get; set; }

        public bool IsWinner { get; set; }

        public void RefreshRemainingMoves()
        {
            RemainingMoves = Speed;
        }

        public void Eat(Fruit fruit)
        {
            Speed += fruit.Speed;
            Power += fruit.Power;
        }

        public int ClashWith(Warrior other)
        {
            return Power.CompareTo(other.Power);
        }
    }
}
