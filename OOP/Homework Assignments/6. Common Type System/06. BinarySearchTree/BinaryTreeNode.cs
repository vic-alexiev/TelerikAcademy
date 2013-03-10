using System;
using System.Collections;
using System.Collections.Generic;

internal class BinaryTreeNode<T> : IComparable<BinaryTreeNode<T>>, IEnumerable<BinaryTreeNode<T>>
    where T : IComparable<T>
{
    #region Properties

    // Contains the data of the node
    public T Item { get; set; }

    // Contains the parent of the node
    public BinaryTreeNode<T> Parent { get; set; }

    // Contains the left child of the node
    public BinaryTreeNode<T> Left { get; set; }

    // Contains the right child of the node
    public BinaryTreeNode<T> Right { get; set; }

    #endregion

    #region Constructors

    public BinaryTreeNode(T item)
    {
        this.Item = item;
    }

    #endregion

    #region Overrides

    public override string ToString()
    {
        return this.Item.ToString();
    }

    public override bool Equals(object obj)
    {
        // If the cast is invalid, the result will be null
        BinaryTreeNode<T> other = obj as BinaryTreeNode<T>;

        // Check if we have valid not null BinaryTreeNode object
        if (other == null)
        {
            return false;
        }

        return this.Item.CompareTo(other.Item) == 0;
    }

    public static bool operator ==(BinaryTreeNode<T> nodeA, BinaryTreeNode<T> nodeB)
    {
        return BinaryTreeNode<T>.Equals(nodeA, nodeB);
    }

    public static bool operator !=(BinaryTreeNode<T> nodeA, BinaryTreeNode<T> nodeB)
    {
        return !(BinaryTreeNode<T>.Equals(nodeA, nodeB));
    }

    public override int GetHashCode()
    {
        return this.Item.GetHashCode();
    }

    public int CompareTo(BinaryTreeNode<T> other)
    {
        return this.Item.CompareTo(other.Item);
    }

    IEnumerator<BinaryTreeNode<T>> IEnumerable<BinaryTreeNode<T>>.GetEnumerator()
    {
        if (this.Left != null)
        {
            foreach (BinaryTreeNode<T> node in this.Left)
            {
                yield return node;
            }
        }

        yield return this;

        if (this.Right != null)
        {
            foreach (BinaryTreeNode<T> node in this.Right)
            {
                yield return node;
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable<BinaryTreeNode<T>>)this).GetEnumerator();
    }

    #endregion
}
