namespace JustMinesweeper
{
    /// <summary>
    /// Keeps the name and score of a player.
    /// </summary>
    public class Result
    {
        #region Private Fields

        /// <summary>
        /// Represents the name of the player.
        /// </summary>
        private string name = string.Empty;

        /// <summary>
        /// Represents the score of the player.
        /// </summary>
        private int score = 0;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Result"/> class.
        /// </summary>
        public Result()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Result"/> class.
        /// </summary>
        /// <param name="name">The name of the player.</param>
        /// <param name="score">The score of the player.</param>
        public Result(string name, int score)
        {
            this.Name = name;
            this.Score = score;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the name of the player.
        /// </summary>
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        /// <summary>
        /// Gets or sets the score of the player.
        /// </summary>
        public int Score
        {
            get { return this.score; }
            set { this.score = value; }
        }

        #endregion
    }
}
