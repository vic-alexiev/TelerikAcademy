using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class Tree<T> : IEnumerable<T>
{
    public TreeNode<T> Root { get; set; }

    public Tree()
    {
    }

    public Tree(TreeNode<T> root)
    {
        this.Root = root;
    }

    public Tree(T rootData)
    {
        this.Root = new TreeNode<T>(rootData);
    }

    /// <summary>
    /// Returns the height of the tree, i.e. the height of the root.
    /// </summary>
    /// <returns>The height of the tree.</returns>
    public int GetHeight()
    {
        return this.Root.GetHeight();
    }

    public override string ToString()
    {
        return this.Root.ToStringUsingDfs();
    }

    public U Accumulate<U>(U seed, Func<U, TreeNode<T>, U> func)
    {
        return this.Root.Accumulate(seed, func);
    }

    public IEnumerable<TreeNode<T>> Filter(Func<TreeNode<T>, bool> predicate)
    {
        return this.Root.Filter(predicate);
    }

    /// <summary>
    /// Iterates through the child nodes of the root, i.e.
    /// traverses the whole tree structure. Uses BFS.
    /// </summary>
    /// <returns></returns>
    public IEnumerator<T> GetEnumerator()
    {
        foreach (TreeNode<T> node in this.Root)
        {
            yield return node.Data;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable<T>)this).GetEnumerator();
    }
}
