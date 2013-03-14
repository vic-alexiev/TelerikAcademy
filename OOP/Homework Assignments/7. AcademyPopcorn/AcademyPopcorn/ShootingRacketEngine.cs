namespace AcademyPopcorn
{
    public class ShootingRacketEngine : Engine
    {
        public ShootingRacketEngine(IRenderer renderer, IUserInterface userInterface, int sleepTimeout)
            : base(renderer, userInterface, sleepTimeout)
        {
        }

        public void ShootWithPlayerRacket()
        {
            if (this.playerRacket is ShootingRacket)
            {
                (this.playerRacket as ShootingRacket).Shoot();
            }
        }
    }
}
