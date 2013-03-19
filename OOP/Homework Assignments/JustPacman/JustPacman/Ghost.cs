using System;
using System.Collections.Generic;

namespace JustPacman
{
    public class Ghost : Actor, IAutomotive
    {
        #region Events

        public event EventHandler EndOfRouteReached;

        #endregion

        #region Private Fields

        private IMovingStrategy strategy;
        private IEnumerable<Location> route;
        private IEnumerator<Location> enumerator;

        #endregion

        #region Constructors

        public Ghost(Location location, ConsoleColor color, IMovingStrategy strategy)
            : base(location, '&', color)
        {
            this.strategy = strategy;
            this.route = new List<Location>();
            this.enumerator = this.route.GetEnumerator();
        }

        #endregion

        #region Public Methods

        public void Move()
        {
            if (this.enumerator.MoveNext())
            {
                this.Location = this.enumerator.Current;
            }
            else
            {
                OnEndOfRouteReached();
            }
        }

        public void CalcRoute(Location destination, MazeObject[,] maze)
        {
            this.route = this.strategy.GetRoute(this.Location, destination, maze);
            this.enumerator = this.route.GetEnumerator();
        }

        public void ClearRoute()
        {
            OnEndOfRouteReached();
        }

        #endregion

        #region Protected Methods

        protected void OnEndOfRouteReached()
        {
            if (this.EndOfRouteReached != null)
            {
                this.EndOfRouteReached(this, new EventArgs());
            }
        }

        #endregion
    }
}
