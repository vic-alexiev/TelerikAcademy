namespace JustPacman
{
    public struct Score
    {
        #region Private Fields

        private int points;
        private int lives;

        #endregion

        #region Properties

        public int Points
        {
            get
            {
                return points;
            }
            set
            {
                points = value;
            }
        }

        public int Lives
        {
            get
            {
                return lives;
            }
            set
            {
                lives = value;
            }
        }

        #endregion
    }
}
