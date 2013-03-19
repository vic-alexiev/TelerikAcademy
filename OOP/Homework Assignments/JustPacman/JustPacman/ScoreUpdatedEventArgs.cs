using System;

namespace JustPacman
{
    /// <summary>
    /// A delegate which processes the ScoreUpdated event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void ScoreUpdatedEventHandler(object sender, ScoreUpdatedEventArgs e);

    /// <summary>
    /// A class which inherits System.EventArgs and keeps information for the current score
    /// </summary>
    public class ScoreUpdatedEventArgs : EventArgs
    {
        private Score score;

        public Score Score
        {
            get
            {
                return this.score;
            }
        }

        public ScoreUpdatedEventArgs(Score score)
        {
            this.score = score;
        }
    }
}
