using System;

namespace JustPacman
{
    public class Pacman : Actor
    {
        #region Events

        public event ScoreUpdatedEventHandler ScoreUpdated;

        #endregion

        #region Private Fields

        private Score score;

        #endregion

        #region Properties

        public int Points
        {
            get
            {
                return score.Points;
            }
            set
            {
                if (value < 0)
                {
                    throw new PacmanException("Points cannot be negative.");
                }
                score.Points = value;
                OnScoreUpdated();
            }
        }

        public int Lives
        {
            get
            {
                return score.Lives;
            }
            set
            {
                if (value < 0)
                {
                    throw new PacmanException("Lives cannot be negative.");
                }
                score.Lives = value;
                OnScoreUpdated();
            }
        }

        #endregion


        #region Constructors

        public Pacman(Location location, char character, ConsoleColor color)
            : base(location, character, color)
        {
        }

        #endregion

        #region Public Methods

        public void UpdateLocation(Location direction)
        {
            if (direction.Row == 0 && direction.Col == -1)
            {
                this.Character = '>';
            }
            else if (direction.Row == 0 && direction.Col == 1)
            {
                this.Character = '<';
            }
            else if (direction.Row == -1 && direction.Col == 0)
            {
                this.Character = 'v';
            }
            else if (direction.Row == 1 && direction.Col == 0)
            {
                this.Character = '^';
            }
            else
            {
                throw new PacmanException(
                    String.Format("Invalid direction: ({0}, {1})", direction.Row, direction.Col));
            }

            this.Location += direction;
        }

        #endregion

        #region Protected Methods

        protected void OnScoreUpdated()
        {
            if (this.ScoreUpdated != null)
            {
                this.ScoreUpdated(this, new ScoreUpdatedEventArgs(this.score));
            }
        }

        #endregion
    }
}
