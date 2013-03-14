namespace AcademyPopcorn
{
    public class Splinter : MovingObject
    {
        public Splinter(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, new char[,] { { '*' } }, speed)
        {
        }

        public override void Update()
        {
            this.IsDestroyed = true;
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == Block.CollisionGroupString;
        }
    }
}
