using JustPacman.DataStructures;
using System.Collections.Generic;

namespace JustPacman
{
    public class BfsStrategy : IMovingStrategy
    {
        public IEnumerable<Location> GetRoute(Location source, Location destination, MazeObject[,] maze)
        {
            int rows = maze.GetLength(0);
            int cols = maze.GetLength(1);

            bool[,] visited = new bool[rows, cols];

            Queue<SimpleTreeNode<Location>> treeNodesQueue = new Queue<SimpleTreeNode<Location>>();

            SimpleTreeNode<Location> root = new SimpleTreeNode<Location>(source);

            treeNodesQueue.Enqueue(root);
            visited[source.Row, source.Col] = true;

            while (treeNodesQueue.Count > 0)
            {
                SimpleTreeNode<Location> node = treeNodesQueue.Dequeue();

                if (node.Value == destination)
                {
                    // traverse the tree bottom-up to get the shortest path
                    IEnumerable<Location> route = GetAllPredecessors(node);
                    return route;
                }

                SimpleTreeNode<Location>[] childNodes = new SimpleTreeNode<Location>[]
                {
                    new SimpleTreeNode<Location>(new Location(node.Value.Row, node.Value.Col - 1)), // left
                    new SimpleTreeNode<Location>(new Location(node.Value.Row, node.Value.Col + 1)), // right
                    new SimpleTreeNode<Location>(new Location(node.Value.Row - 1, node.Value.Col)), // up
                    new SimpleTreeNode<Location>(new Location(node.Value.Row + 1, node.Value.Col)) // down
                };

                node.Children.AddRange(childNodes);

                foreach (SimpleTreeNode<Location> child in childNodes)
                {
                    if (child.Value.Row >= 0 && child.Value.Row < rows
                        && child.Value.Col >= 0 && child.Value.Col < cols
                        && !(maze[child.Value.Row, child.Value.Col].Type == MazeObjectType.Brick)
                        && !visited[child.Value.Row, child.Value.Col])
                    {
                        node.Children.Add(child);
                        treeNodesQueue.Enqueue(child);
                        visited[child.Value.Row, child.Value.Col] = true;
                    }
                }
            }

            return new List<Location>();
        }

        private IEnumerable<Location> GetAllPredecessors(SimpleTreeNode<Location> node)
        {
            List<Location> predecessors = new List<Location>();

            while (node != null)
            {
                predecessors.Add(node.Value);
                node = node.Parent;
            }

            predecessors.Reverse();
            return predecessors;
        }
    }
}
