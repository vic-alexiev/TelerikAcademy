namespace FruitWars
{
    public abstract class GameObject
    {
        protected GameObject(char character)
        {
            Character = character;
        }

        public char Character { get; private set; }
    }
}
