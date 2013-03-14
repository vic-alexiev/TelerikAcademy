namespace AcademyPopcorn
{
    public class TrailObject : GameObject
    {
        private int lifetime;

        public TrailObject(MatrixCoords topLeft, char[,] body, int lifetime)
            : base(topLeft, body)
        {
            this.lifetime = lifetime;
        }

        public override void Update()
        {
            if (lifetime > 0)
            {
                lifetime--;
            }
            else
            {
                this.IsDestroyed = true;
            }
        }
    }
}
