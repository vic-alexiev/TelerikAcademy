using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Based on the article "Priority Queues with C#" by James McCaffrey:
/// http://visualstudiomagazine.com/articles/2012/11/01/priority-queues-with-c.aspx
/// </summary>
/// <typeparam name="T"></typeparam>
public class PriorityQueue<T> : IEnumerable<T>
    where T : IComparable<T>
{
    #region Private Fields

    private List<T> data;

    #endregion

    #region Constructors

    public PriorityQueue()
    {
        this.data = new List<T>();
    }

    #endregion

    #region Properties

    public int Count
    {
        get
        {
            return this.data.Count;
        }
    }

    public bool IsEmpty
    {
        get
        {
            return this.data.Count == 0;
        }
    }

    #endregion

    #region Public Methods

    public void Enqueue(T item)
    {
        // add the new item as the last element of the list
        this.data.Add(item);

        // place the child index at the end of the list
        int childIndex = this.data.Count - 1;

        while (childIndex > 0)
        {
            // find the parent index: if [n] is the parent index,
            // then its children are at positions [2n+1] and [2n+2].
            int parentIndex = (childIndex - 1) / 2;

            if (this.data[childIndex].CompareTo(this.data[parentIndex]) >= 0)
            {
                // Lower-priority numeric values mean higher priority, so when
                // child priority value is greater than or equal to the parent priority, 
                // then the method is done. Otherwise, the child node bubbles up until 
                // it's in the correct position.
                break;
            }

            // child priority value is still less than the parent priority 
            // => swap the values
            T tmp = this.data[childIndex];
            this.data[childIndex] = this.data[parentIndex];
            this.data[parentIndex] = tmp;

            childIndex = parentIndex;
        }
    }

    public T Dequeue()
    {
        if (this.data.Count == 0)
        {
            throw new InvalidOperationException("Queue empty.");
        }

        int lastIndex = this.data.Count - 1;

        // The front item is removed by making a copy of it, 
        // then overwriting the item at location [0] with 
        // the item in the last location. 
        T frontItem = this.data[0];
        this.data[0] = this.data[lastIndex];
        this.data.RemoveAt(lastIndex);

        // update last index
        --lastIndex;

        // Now that the last item is placed first 
        // (occupying the place of the front item that was just removed),
        // it starts "trickling down" the binary heap until it finds its correct place.
        int parentIndex = 0;

        while (true)
        {
            int leftChildIndex = parentIndex * 2 + 1;

            if (leftChildIndex > lastIndex)
            {
                break;
            }

            int rightChildIndex = leftChildIndex + 1;

            // Keeps the index of the child with lower 
            // priority value, i.e. the child which is 
            // eligible for the swap (if the swap takes place).
            int swapIndex = leftChildIndex;

            if (rightChildIndex <= lastIndex &&
                this.data[rightChildIndex].CompareTo(this.data[leftChildIndex]) < 0)
            {
                // the right child is the smaller of the two children
                swapIndex = rightChildIndex;
            }

            if (this.data[parentIndex].CompareTo(this.data[swapIndex]) <= 0)
            {
                // the parent and the child are in order
                break;
            }

            // the parent and the child are out of order => swap
            T tmp = this.data[parentIndex];
            this.data[parentIndex] = this.data[swapIndex];
            this.data[swapIndex] = tmp;

            parentIndex = swapIndex;
        }

        return frontItem;
    }

    public T Peek()
    {
        if (this.data.Count == 0)
        {
            throw new InvalidOperationException("Queue empty.");
        }

        T frontItem = this.data[0];
        return frontItem;
    }

    public void Clear()
    {
        this.data.Clear();
    }

    public IEnumerator<T> GetEnumerator()
    {
        return this.data.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public T[] ToArray()
    {
        return this.data.ToArray();
    }

    public override string ToString()
    {
        return string.Join(", ", this.data);
    }

    /// <summary>
    /// Used in the unit tests.
    /// </summary>
    /// <returns></returns>
    public bool IsConsistent()
    {
        if (this.data.Count == 0)
        {
            return true;
        }

        int lastIndex = data.Count - 1;

        for (int parentIndex = 0; parentIndex < data.Count; ++parentIndex)
        {
            int leftChildIndex = 2 * parentIndex + 1;
            int rightChildIndex = 2 * parentIndex + 2;

            if (leftChildIndex <= lastIndex &&
                data[parentIndex].CompareTo(data[leftChildIndex]) > 0)
            {
                return false;
            }

            if (rightChildIndex <= lastIndex &&
                data[parentIndex].CompareTo(data[rightChildIndex]) > 0)
            {
                return false;
            }
        }

        // passed all checks
        return true;
    }

    #endregion
}

public class Node : IComparable<Node>
{
    public int Vertex { get; set; }
    public int Distance { get; set; }

    public Node(int vertex, int distance)
    {
        this.Vertex = vertex;
        this.Distance = distance;
    }

    public int CompareTo(Node other)
    {
        return this.Distance.CompareTo(other.Distance);
    }
}

internal class Hospitals
{
    private static List<List<Node>> vertices;
    private static int n, m, h;
    private static List<int> hospitals;
    private static int[] distances = new int[10000];
    private static bool[] visited = new bool[10000];

    private static void AddEdge(int startVertex, int endVertex, int distance)
    {
        Node node = new Node(endVertex, distance);

        if (vertices[startVertex] == null)
        {
            vertices[startVertex] = new List<Node>();
        }

        vertices[startVertex].Add(node);
    }

    private static void ReadInput()
    {
        string counts = Console.ReadLine();
        string[] numbers = counts.Split(new char[] { ' ' });

        n = int.Parse(numbers[0]);
        m = int.Parse(numbers[1]);

        string hospitalsAsString = Console.ReadLine();
        string[] hospitalsArray = hospitalsAsString.Split(new char[] { ' ' });
        h = hospitalsArray.Length;

        hospitals = new List<int>();

        for (int i = 0; i < h; i++)
        {
            hospitals.Add(int.Parse(hospitalsArray[i]) - 1);
        }

        vertices = new List<List<Node>>(n);
        for (int j = 0; j < n; j++)
        {
            vertices.Add(null);
        }

        for (int k = 0; k < m; k++)
        {
            string line = Console.ReadLine();
            string[] streetTokens = line.Split(new char[] { ' ' });

            int startVertex = int.Parse(streetTokens[0]);
            int endVertex = int.Parse(streetTokens[1]);
            int distance = int.Parse(streetTokens[2]);

            AddEdge(startVertex - 1, endVertex - 1, distance);
            AddEdge(endVertex - 1, startVertex - 1, distance);
        }
    }

    private static int Dijkstra(int startVertex)
    {
        for (int i = 0; i < n; i++)
        {
            distances[i] = 200000;
            visited[i] = false;
        }

        distances[startVertex] = 0;
        PriorityQueue<Node> queue = new PriorityQueue<Node>();
        Node node = new Node(startVertex, 0);
        queue.Enqueue(node);

        while (queue.Count > 0)
        {
            Node minDistanceNode = queue.Peek();
            int minDistanceVertex = minDistanceNode.Vertex;

            visited[minDistanceVertex] = true;

            int neighborsCount = vertices[minDistanceVertex].Count;

            for (int i = 0; i < neighborsCount; i++)
            {
                Node neighborNode = vertices[minDistanceVertex][i];
                int newDistance = distances[minDistanceVertex] + neighborNode.Distance;
                if (distances[neighborNode.Vertex] > newDistance)
                {
                    distances[neighborNode.Vertex] = newDistance;
                    Node newNode = new Node(neighborNode.Vertex, newDistance);
                    queue.Enqueue(newNode);
                }
            }

            while (queue.Count > 0 && visited[queue.Peek().Vertex])
            {
                queue.Dequeue();
            }
        }

        int sum = 0;

        for (int i = 0; i < h; i++)
        {
            distances[hospitals[i]] = 0;
        }

        for (int i = 0; i < n; i++)
        {
            sum += distances[i];
        }

        return sum;
    }

    private static void Main()
    {
        ReadInput();

        int minSum = int.MaxValue;
        for (int i = 0; i < h; i++)
        {
            int sum = Dijkstra(hospitals[i]);
            if (sum < minSum)
            {
                minSum = sum;
            }
        }

        Console.WriteLine(minSum);
    }
}
