using System.Collections.Generic;

namespace AcademyPopcorn
{
    public class ShootingRacket : Racket
    {
        private bool hasFired = false;

        public ShootingRacket(MatrixCoords topLeft, int width)
            : base(topLeft, width)
        {
        }

        public void Shoot()
        {
            this.hasFired = true;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            if (this.hasFired)
            {
                this.hasFired = false;

                List<Bullet> bullets = new List<Bullet>();

                // create a new bullet object
                Bullet bullet = new Bullet(
                    new MatrixCoords(this.TopLeft.Row - 2, this.TopLeft.Col + this.Width / 2));

                // add the bullet to the list of bullets produced
                bullets.Add(bullet);

                return bullets;
            }
            else
            {
                return base.ProduceObjects();
            }
        }
    }
}
