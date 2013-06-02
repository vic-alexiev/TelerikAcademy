using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// This implementation is based on the source code posted at:
/// http://dvanderboom.wordpress.com/2008/03/15/treet-implementing-a-non-binary-tree-in-c/
/// </summary>
/// <typeparam name="T"></typeparam>
public class TreeNode<T> : IEnumerable<TreeNode<T>>
{
    #region Private Fields

    private StringBuilder dataBuilder = new StringBuilder();

    private TreeNode<T> parent;

    #endregion

    #region Properties

    /// <summary>
    /// Gets or sets the data (or a reference to the data)
    /// kept by the node.
    /// </summary>
    public T Data { get; set; }

    /// <summary>
    /// Gets or sets the reference to the parent node.
    /// </summary>
    public TreeNode<T> Parent
    {
        get
        {
            return this.parent;
        }

        set
        {
            if (value == this.parent)
            {
                return;
            }

            if (this.parent != null)
            {
                this.parent.Nodes.Remove(this);
            }

            if (value != null && !value.Nodes.Contains(this))
            {
                value.Nodes.Add(this);
            }

            this.parent = value;
        }
    }

    /// <summary>
    /// Gets the zero-based depth of the tree node.
    /// </summary>
    public int Level
    {
        get
        {
            if (this.parent == null)
            {
                return 0;
            }

            return this.parent.Level + 1;
        }
    }

    /// <summary>
    /// Gets the depth of the node.
    /// </summary>
    public int Depth
    {
        get
        {
            int depth = 0;
            TreeNode<T> node = this;

            while (node.Parent != null)
            {
                node = node.Parent;
                depth++;
            }

            return depth;
        }
    }

    /// <summary>
    /// A list of child nodes.
    /// </summary>
    public TreeNodeCollection<T> Nodes { get; private set; }

    #endregion

    #region Constructors

    public TreeNode()
        : this(default(T), null)
    {
    }

    public TreeNode(T data)
        : this(data, null)
    {
    }

    public TreeNode(T data, TreeNode<T> parent)
    {
        this.Data = data;
        this.Parent = parent;
        this.Nodes = new TreeNodeCollection<T>(this);
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Returns a reference to the root of the tree.
    /// </summary>
    /// <returns></returns>
    public TreeNode<T> GetRoot()
    {
        TreeNode<T> node = this;

        while (node.Parent != null)
        {
            node = node.Parent;
        }

        return node;
    }

    /// <summary>
    /// Returns the height of the node. By definition,
    /// the height of a node is the length of the longest 
    /// downward path to a leaf from that node.
    /// The height of the root is the height of the tree.
    /// </summary>
    /// <returns>The height of the node.</returns>
    /// <remarks>The method uses DFS and finds the longest path of all.</remarks>
    public int GetHeight()
    {
        return this.GetHeight(this);
    }

    /// <summary>
    /// Applies the transform function <paramref name="selector"/>
    /// to each element of the tree which has this node as its root.
    /// </summary>
    /// <typeparam name="U"></typeparam>
    /// <param name="selector"></param>
    /// <returns></returns>
    public TreeNode<U> Map<U>(Func<T, U> selector)
    {
        return this.Map(selector, this);
    }

    /// <summary>
    /// Applies <paramref name="func"/> to each successive element
    /// in the tree and aggregates the result. Used to sum/multiply
    /// all the elements in the tree which has this node as its root.
    /// </summary>
    /// <typeparam name="U"></typeparam>
    /// <param name="seed"></param>
    /// <param name="func"></param>
    /// <returns></returns>
    public U Accumulate<U>(U seed, Func<U, T, U> func)
    {
        return this.Accumulate(seed, func, data => true);
    }

    /// <summary>
    /// Applies <paramref name="func"/> only to the elements
    /// for which <paramref name="predicate"/> returns true.
    /// </summary>
    /// <typeparam name="U"></typeparam>
    /// <param name="seed"></param>
    /// <param name="func"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public U Accumulate<U>(U seed, Func<U, T, U> func, Func<T, bool> predicate)
    {
        return this.Accumulate(seed, func, predicate, this);
    }

    /// <summary>
    /// Selects specific tree elements using <paramref name="predicate"/>
    /// as a filter criterion.
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public IEnumerable<TreeNode<T>> Filter(Func<T, bool> predicate)
    {
        return this.Where(node => predicate(node.Data));
    }

    /// <summary>
    /// Iterates through the nodes of the tree which has the current node
    /// as its root.
    /// </summary>
    /// <returns></returns>
    public IEnumerator<TreeNode<T>> GetEnumerator()
    {
        //return this.GetBfsEnumerator();
        return this.GetDfsEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable<TreeNode<T>>)this).GetEnumerator();
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();

        if (this.Data != null)
        {
            result.AppendFormat("Data=[{0}], ", this.Data);
        }

        result.AppendFormat("Depth={0}, Nodes={1}", this.Depth, this.Nodes.Count);

        return result.ToString();
    }

    public string ToStringUsingDfs()
    {
        this.dataBuilder.Clear();

        this.CollectDataUsingDfs(this, string.Empty);

        return dataBuilder.ToString();
    }

    #endregion

    #region Private Methods

    private int GetHeight(TreeNode<T> node)
    {
        if (node.Nodes.Count == 0)
        {
            return 0;
        }

        int maxHeight = int.MinValue;

        foreach (var childNode in node.Nodes)
        {
            int height = GetHeight(childNode);
            if (maxHeight < height)
            {
                maxHeight = height;
            }
        }

        return maxHeight + 1;
    }

    private void CollectDataUsingDfs(TreeNode<T> node, string space)
    {
        dataBuilder.AppendLine(space + node.Data);

        foreach (var childNode in node.Nodes)
        {
            this.CollectDataUsingDfs(childNode, space + "   ");
        }
    }

    private TreeNode<U> Map<U>(Func<T, U> selector, TreeNode<T> node)
    {
        TreeNode<U> newNode = new TreeNode<U>(selector(node.Data));

        foreach (var childNode in node.Nodes)
        {
            TreeNode<U> newChildNode = this.Map(selector, childNode);
            newNode.Nodes.Add(newChildNode);
        }

        return newNode;
    }

    private U Accumulate<U>(U seed, Func<U, T, U> func, Func<T, bool> predicate, TreeNode<T> node)
    {
        U accumulator = seed;

        if (predicate(node.Data))
        {
            accumulator = func(seed, node.Data);
        }

        foreach (var childNode in node.Nodes)
        {
            accumulator = this.Accumulate(accumulator, func, predicate, childNode);
        }

        return accumulator;
    }

    /// <summary>
    /// Iterates through the nodes of the tree which has the current node
    /// as its root. Uses BFS.
    /// </summary>
    /// <returns></returns>
    private IEnumerator<TreeNode<T>> GetBfsEnumerator()
    {
        Queue<TreeNode<T>> nodesQueue = new Queue<TreeNode<T>>();

        TreeNode<T> currentNode = this;
        nodesQueue.Enqueue(currentNode);

        do
        {
            TreeNode<T> returnNode = nodesQueue.Dequeue();

            foreach (var childNode in returnNode.Nodes)
            {
                nodesQueue.Enqueue(childNode);
            }

            yield return returnNode;
        }
        while (nodesQueue.Count > 0);
    }

    /// <summary>
    /// Iterates through the nodes of the tree which has the current node
    /// as its root. Uses DFS.
    /// </summary>
    /// <returns></returns>
    private IEnumerator<TreeNode<T>> GetDfsEnumerator()
    {
        Stack<TreeNode<T>> nodesStack = new Stack<TreeNode<T>>();

        TreeNode<T> currentNode = this;
        nodesStack.Push(currentNode);

        do
        {
            TreeNode<T> returnNode = nodesStack.Pop();

            foreach (var childNode in returnNode.Nodes)
            {
                nodesStack.Push(childNode);
            }

            yield return returnNode;
        }
        while (nodesStack.Count > 0);
    }

    #endregion
}
