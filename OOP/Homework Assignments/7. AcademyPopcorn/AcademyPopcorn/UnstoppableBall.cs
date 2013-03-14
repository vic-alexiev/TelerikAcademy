namespace AcademyPopcorn
{
    public class UnstoppableBall : Ball
    {
        public UnstoppableBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            //the unstoppable ball should respond (change direction) only
            //if it collides with an indestructible block or a racket
            if (collisionData.hitObjectsCollisionGroupStrings.Contains(IndestructibleBlock.CollisionGroupString) ||
                collisionData.hitObjectsCollisionGroupStrings.Contains(Racket.CollisionGroupString))
            {
                base.RespondToCollision(collisionData);
            }
        }
    }
}
