using System.Collections.Generic;

namespace AcademyPopcorn
{
    public class Gift : MovingObject
    {
        public new const string CollisionGroupString = "gift";

        public Gift(MatrixCoords topLeft, char[,] body)
            : base(topLeft, body, new MatrixCoords(1, 0))
        {
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == Racket.CollisionGroupString;
        }

        public override string GetCollisionGroupString()
        {
            return Gift.CollisionGroupString;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
            this.ProduceObjects();
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            if (this.IsDestroyed)
            {
                List<ShootingRacket> rackets = new List<ShootingRacket>();

                // replace the ordinary racket with a shooting one
                ShootingRacket shootingRacket = new ShootingRacket(
                    new MatrixCoords(this.TopLeft.Row + 1, this.TopLeft.Col), 6);
                rackets.Add(shootingRacket);

                return rackets;
            }
            else
            {
                return base.ProduceObjects();
            }
        }
    }
}
