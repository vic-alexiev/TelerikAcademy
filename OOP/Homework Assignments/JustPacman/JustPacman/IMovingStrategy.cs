using System.Collections.Generic;

namespace JustPacman
{
    public interface IMovingStrategy
    {
        IEnumerable<Location> GetRoute(Location source, Location destination, MazeObject[,] maze);
    }
}
