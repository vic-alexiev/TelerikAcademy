namespace JustPacman
{
    public class MazeObject
    {
        #region Private Fields

        protected int points;
        private MazeObjectType type;

        #endregion

        #region Properties

        public MazeObjectType Type
        {
            get { return type; }
        }

        public int Points
        {
            get { return points; }
        }

        #endregion

        #region Constructors

        public MazeObject(MazeObjectType type, int points)
        {
            this.type = type;
            this.points = points;
        }

        public MazeObject(MazeObjectType type)
            : this(type, 0)
        {
        }

        #endregion
    }
}
