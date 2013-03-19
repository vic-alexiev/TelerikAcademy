namespace JustPacman
{
    public struct Location
    {
        #region Private Fields

        private int row;
        private int col;

        #endregion

        #region Properties

        public int Row
        {
            get { return row; }
            set { row = value; }
        }

        public int Col
        {
            get { return col; }
            set { col = value; }
        }

        #endregion

        #region Constructors

        public Location(int row, int col)
        {
            this.row = row;
            this.col = col;
        }

        #endregion

        #region Public Methods

        public override bool Equals(object obj)
        {
            if (obj is Location)
            {
                Location point = (Location)obj;
                if (point.Row != this.Row)
                {
                    return false;
                }
                else
                {
                    return point.Col == this.Col;
                }
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return this.Row.GetHashCode() * 7 + this.Col;
        }

        public static Location Add(Location left, Location right)
        {
            return new Location(left.Row + right.Row, left.Col + right.Col);
        }

        public static Location operator +(Location left, Location right)
        {
            return Location.Add(left, right);
        }

        public static bool operator ==(Location left, Location right)
        {
            if (left.Row != right.Row)
            {
                return false;
            }
            else
            {
                return left.Col == right.Col;
            }
        }

        public static bool operator !=(Location left, Location right)
        {
            return !(left == right);
        }

        #endregion
    }
}
