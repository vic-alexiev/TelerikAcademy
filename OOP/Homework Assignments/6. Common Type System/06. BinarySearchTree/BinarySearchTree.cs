using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class BinarySearchTree<T> : ICloneable, IEnumerable<T>
    where T : IComparable<T>
{
    #region Private Fields

    private StringBuilder itemsBuilder = new StringBuilder();
    private const int PRIME_MULTIPLIER = 83;
    private int count = 0;

    /// <summary>
    /// The root of the tree
    /// </summary>
    private BinaryTreeNode<T> root;

    #endregion

    #region Properties

    public int Count
    {
        get
        {
            return this.count;
        }
    }

    #endregion

    #region Constructors

    public BinarySearchTree()
    {
    }

    public BinarySearchTree(params T[] items)
    {
        foreach (T item in items)
        {
            this.Add(item);
        }
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Determines whether an element is in the binary search tree.
    /// </summary>
    /// <param name="item">The object to locate in the binary search tree.</param>
    /// <returns></returns>
    public bool Contains(T item)
    {
        BinaryTreeNode<T> nodeFound = this.Find(item);

        return nodeFound != null;
    }

    /// <summary>
    /// Adds an object to the binary search tree.
    /// </summary>
    /// <param name="item">The object to be added to the binary search tree.</param>
    public void Add(T item)
    {
        if (item != null)
        {
            this.root = Add(item, this.root, null);
        }
        else
        {
            throw new ArgumentException("Item cannot be null.");
        }
    }

    /// <summary>
    /// Removes a specific object from the binary search tree.
    /// </summary>
    /// <param name="item">The object to remove from the binary search tree.</param>
    public void Remove(T item)
    {
        BinaryTreeNode<T> nodeToDelete = Find(item);
        if (nodeToDelete == null)
        {
            return;
        }

        Remove(nodeToDelete);
    }

    public override string ToString()
    {
        return AsString(true);
    }

    public string AsString(bool ascending)
    {
        if (this.root == null)
        {
            return String.Empty;
        }
        else
        {
            itemsBuilder.Clear();
            if (ascending)
            {
                AsStringAscending(this.root);
            }
            else
            {
                AsStringDescending(this.root);
            }

            // remove the extra comma and space at the end
            return this.itemsBuilder.Remove(this.itemsBuilder.Length - 2, 2).ToString();
        }
    }

    public override bool Equals(object obj)
    {
        // If the cast is invalid, the result will be null
        BinarySearchTree<T> other = obj as BinarySearchTree<T>;

        // Check if we have valid not null BinarySearchTree<T> object
        if (other == null)
        {
            return false;
        }

        return AreEqual(this.root, other.root);
    }

    public static bool operator ==(BinarySearchTree<T> a, BinarySearchTree<T> b)
    {
        return BinarySearchTree<T>.Equals(a, b);
    }

    public static bool operator !=(BinarySearchTree<T> a, BinarySearchTree<T> b)
    {
        return !(BinarySearchTree<T>.Equals(a, b));
    }

    public override int GetHashCode()
    {
        int result = 1;

        if (this.root != null)
        {
            CalcHashCodePreorder(this.root, ref result);
        }

        return result;
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        if (this.root != null)
        {
            if (this.root.Left != null)
            {
                foreach (BinaryTreeNode<T> node in this.root.Left)
                {
                    yield return node.Item;
                }
            }

            yield return this.root.Item;

            if (this.root.Right != null)
            {
                foreach (BinaryTreeNode<T> node in this.root.Right)
                {
                    yield return node.Item;
                }
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable<T>)this).GetEnumerator();
    }

    /// <summary>
    /// Explicit implementation of ICloneable.Clone()
    /// </summary>
    /// <returns></returns>
    object ICloneable.Clone()
    {
        return this.Clone();
    }

    public BinarySearchTree<T> Clone()
    {
        BinarySearchTree<T> clone = new BinarySearchTree<T>();
        Copy(clone, this.root);
        return clone;
    }

    #endregion

    #region Private Methods

    private BinaryTreeNode<T> Add(T item, BinaryTreeNode<T> node, BinaryTreeNode<T> parentNode)
    {
        if (node == null)
        {
            node = new BinaryTreeNode<T>(item);
            node.Parent = parentNode;

            // update count
            this.count++;
        }
        else
        {
            int comparisonResult = node.Item.CompareTo(item);

            if (comparisonResult > 0)
            {
                node.Left = Add(item, node.Left, node);
            }
            else if (comparisonResult < 0)
            {
                node.Right = Add(item, node.Right, node);
            }
        }

        return node;
    }

    private void Copy(BinarySearchTree<T> clone, BinaryTreeNode<T> node)
    {
        if (node != null)
        {
            clone.Add(node.Item);
            Copy(clone, node.Left);
            Copy(clone, node.Right);
        }
    }

    private BinaryTreeNode<T> Find(T item)
    {
        BinaryTreeNode<T> node = this.root;

        while (node != null)
        {
            int comparisonResult = node.Item.CompareTo(item);

            if (comparisonResult > 0)
            {
                node = node.Left;
            }
            else if (comparisonResult < 0)
            {
                node = node.Right;
            }
            else
            {
                break;
            }
        }

        return node;
    }

    private void Remove(BinaryTreeNode<T> node)
    {
        // Case 3: If the node has two children
        if (node.Left != null && node.Right != null)
        {
            BinaryTreeNode<T> replacement = Min(node.Right);
            node.Item = replacement.Item;
            node = replacement;
        }

        // Case 1 and 2: If the node has at most one child
        BinaryTreeNode<T> theChild = node.Left != null ? node.Left : node.Right;

        if (theChild != null)
        {
            theChild.Parent = node.Parent;
        }

        // Handle the case when the element is the root
        if (node.Parent == null)
        {
            root = theChild;
        }
        else
        {
            // Replace the element with its child subtree
            if (node == node.Parent.Left)
            {
                // the node is the left child of its parent
                node.Parent.Left = theChild;
            }
            else
            {
                // the node is the right child of its parent
                node.Parent.Right = theChild;
            }
        }

        // update count
        this.count--;
    }

    private BinaryTreeNode<T> Min(BinaryTreeNode<T> node)
    {
        BinaryTreeNode<T> min = node;

        while (min.Left != null)
        {
            min = min.Left;
        }

        return min;
    }

    private void AsStringAscending(BinaryTreeNode<T> node)
    {
        if (node != null)
        {
            AsStringAscending(node.Left);
            this.itemsBuilder.AppendFormat("{0}, ", node.Item);
            AsStringAscending(node.Right);
        }
    }

    private void AsStringDescending(BinaryTreeNode<T> node)
    {
        if (node != null)
        {
            AsStringDescending(node.Right);
            this.itemsBuilder.AppendFormat("{0}, ", node.Item);
            AsStringDescending(node.Left);
        }
    }

    private bool AreEqual(BinaryTreeNode<T> a, BinaryTreeNode<T> b)
    {
        if (a == null && b == null)
        {
            return true;
        }
        else if (a != null && b != null)
        {
            return a == b && AreEqual(a.Left, b.Left) && AreEqual(a.Right, b.Right);
        }
        else
        {
            return false;
        }
    }

    private void CalcHashCodePreorder(BinaryTreeNode<T> node, ref int hashCode)
    {
        if (node != null)
        {
            hashCode = hashCode * PRIME_MULTIPLIER + node.GetHashCode();
            CalcHashCodePreorder(node.Left, ref hashCode);
            CalcHashCodePreorder(node.Right, ref hashCode);
        }
    }

    #endregion
}
