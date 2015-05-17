namespace FruitWars.Fruits
{
    public abstract class Fruit : GameObject
    {
        protected Fruit(int speed, int power, char character)
            : base(character)
        {
            Speed = speed;
            Power = power;
        }

        public int Speed { get; private set; }

        public int Power { get; private set; }
    }
}
