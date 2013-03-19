using System;

namespace JustPacman
{
    public abstract class Actor
    {
        #region Private Fields

        private Location location;
        private char character;
        private ConsoleColor color;

        #endregion

        #region Properties

        public Location Location
        {
            get { return location; }
            set { location = value; }
        }

        public char Character
        {
            get { return character; }
            protected set { character = value; }
        }

        public ConsoleColor Color
        {
            get { return color; }
            protected set { color = value; }
        }

        #endregion

        #region Constructors

        protected Actor(Location location, char character, ConsoleColor color)
        {
            this.location = location;
            this.character = character;
            this.color = color;
        }

        #endregion
    }
}
