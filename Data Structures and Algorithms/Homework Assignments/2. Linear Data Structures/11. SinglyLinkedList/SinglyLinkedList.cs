using System;
using System.Collections;
using System.Collections.Generic;

public sealed class SinglyLinkedList<T> : IList<T>
{
    #region Private Fields

    private int size;

    /// <summary>
    /// Points to the first node of the list.
    /// </summary>
    private SinglyLinkedNode<T> firstNode;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the number of elements contained in the <see cref="SinglyLinkedList&lt;T&gt;"/>.
    /// </summary>
    public int Count
    {
        get
        {
            return this.size;
        }
    }

    /// <summary>
    /// Gets a value indicating whether the <see cref="SinglyLinkedList&lt;T&gt;"/> is read-only.
    /// </summary>
    /// <value>true if the <see cref="SinglyLinkedList&lt;T&gt;"/> is read-only; otherwise, false.</value>
    public bool IsReadOnly
    {
        get
        {
            return false;
        }
    }

    #endregion

    #region Indexers

    /// <summary>
    /// Gets or sets the element at the specified index.
    /// </summary>
    /// <param name="index">The zero-based index of the element to get or set.</param>
    /// <returns>The element at the specified index.</returns>
    /// <exception cref="System.ArgumentOutOfRangeException">Thrown when
    /// <paramref name="index"/> is less than zero or <paramref name="index"/> is
    /// greater than or equal to <see cref="SinglyLinkedList&lt;T&gt;"/>.Count.</exception>
    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= this.size)
            {
                throw new ArgumentOutOfRangeException(
                    "index",
                    "Index was out of range. Must be non-negative and less than the size of the collection.");
            }

            SinglyLinkedNode<T> currentNode = this.firstNode;

            for (int i = 0; i < index; i++)
            {
                currentNode = currentNode.NextNode;
            }

            return currentNode.Data;
        }

        set
        {
            if (index < 0 || index >= this.size)
            {
                throw new ArgumentOutOfRangeException(
                    "index",
                    "Index was out of range. Must be non-negative and less than the size of the collection.");
            }

            SinglyLinkedNode<T> currentNode = this.firstNode;

            for (int i = 0; i < index; i++)
            {
                currentNode = currentNode.NextNode;
            }

            currentNode.Data = value;
        }
    }

    #endregion

    #region Constructors

    public SinglyLinkedList()
    {
        this.size = 0;
        this.firstNode = null;
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Adds an object to the end of the <see cref="SinglyLinkedList&lt;T&gt;"/>.
    /// </summary>
    /// <param name="item">The object to be added to the end of the <see cref="SinglyLinkedList&lt;T&gt;"/>.
    /// The value can be null for reference types.</param>
    public void Add(T item)
    {
        SinglyLinkedNode<T> newNode = new SinglyLinkedNode<T>(item);

        if (this.size == 0)
        {
            this.InsertBeginning(newNode);
            return;
        }

        // find the node which contains the item
        SinglyLinkedNode<T> currentNode = this.firstNode;

        while (currentNode.NextNode != null)
        {
            currentNode = currentNode.NextNode;
        }

        this.InsertAfter(currentNode, newNode);
    }

    /// <summary>
    /// Removes all elements from the <see cref="SinglyLinkedList&lt;T&gt;"/>.
    /// </summary>
    public void Clear()
    {
        this.size = 0;
        this.firstNode = null;
    }

    /// <summary>
    /// Determines whether an element is in the <see cref="SinglyLinkedList&lt;T&gt;"/>.
    /// </summary>
    /// <param name="item">The object to locate in the System.Collections.Generic.List<T>.
    /// The value can be null for reference types.</param>
    /// <returns>true if <paramref name="item"/> is found in the <see cref="SinglyLinkedList&lt;T&gt;"/>; 
    /// otherwise, false.</returns>
    public bool Contains(T item)
    {
        int index = this.IndexOf(item);
        bool found = (index != -1);
        return found;
    }

    /// <summary>
    /// Copies the entire <see cref="SinglyLinkedList&lt;T&gt;"/> to a compatible one-dimensional
    /// array, starting at the beginning of the target array.
    /// </summary>
    /// <param name="array">The one-dimensional <see cref="System.Array"/> that is the destination 
    /// of the elements copied from <see cref="SinglyLinkedList&lt;T&gt;"/>. The <see cref="System.Array"/>
    /// must have zero-based indexing.</param>
    /// <exception cref="System.ArgumentNullException">Thrown when array is null.</exception>
    /// <exception cref="System.ArgumentException">Thrown when
    /// the number of elements in the source <see cref="SinglyLinkedList&lt;T&gt;"/> is
    /// greater than the number of elements that the destination array can contain.</exception>
    public void CopyTo(T[] array)
    {
        this.CopyTo(array, 0);
    }

    /// <summary>
    /// Copies the entire <see cref="SinglyLinkedList&lt;T&gt;"/> to a compatible one-dimensional
    /// array, starting at the specified index of the target array.
    /// </summary>
    /// <param name="array">The one-dimensional <see cref="System.Array"/> that is the destination 
    /// of the elements copied from <see cref="SinglyLinkedList&lt;T&gt;"/>. The <see cref="System.Array"/>
    /// must have zero-based indexing.</param>
    /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
    /// <exception cref="System.ArgumentNullException">Thrown when array is null.</exception>
    /// <exception cref="System.ArgumentOutOfRangeException">Thrown when
    /// <paramref name="arrayIndex"/> is less than 0.</exception>
    /// <exception cref="System.ArgumentException">Thrown when
    /// the number of elements in the source <see cref="SinglyLinkedList&lt;T&gt;"/> is
    /// greater than the available space from <paramref name="arrayIndex"/> 
    /// to the end of the destination array.</exception>
    public void CopyTo(T[] array, int arrayIndex)
    {
        if (array == null)
        {
            throw new ArgumentNullException("array", "array cannot be null.");
        }

        if (arrayIndex < 0)
        {
            throw new ArgumentOutOfRangeException("arrayIndex", "arrayIndex cannot be less than zero.");
        }

        if (arrayIndex + this.size > array.Length)
        {
            throw new ArgumentException(
                "Destination array was not long enough. " +
                "Check arrayIndex and the array's length.");
        }

        int index = arrayIndex;

        foreach (SinglyLinkedNode<T> node in this.firstNode)
        {
            array[index] = node.Data;
            index++;
        }
    }

    /// <summary>
    /// Returns an enumerator that iterates through the <see cref="SinglyLinkedList&lt;T&gt;"/>.
    /// </summary>
    /// <returns>A <see cref="SinglyLinkedList&lt;T&gt;"/>.Enumerator for the <see cref="SinglyLinkedList&lt;T&gt;"/>.</returns>
    public IEnumerator<T> GetEnumerator()
    {
        foreach (SinglyLinkedNode<T> node in this.firstNode)
        {
            yield return node.Data;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable<T>)this).GetEnumerator();
    }

    /// <summary>
    /// Searches for the specified object and returns the zero-based index of the
    /// first occurrence within the entire <see cref="SinglyLinkedList&lt;T&gt;"/>.
    /// </summary>
    /// <param name="item">The object to locate in the <see cref="SinglyLinkedList&lt;T&gt;"/>.
    /// The value can be null for reference types.</param>
    /// <returns>The zero-based index of the first occurrence of <paramref name="item"/> 
    /// within the entire <see cref="SinglyLinkedList&lt;T&gt;"/>, if found; otherwise, –1.</returns>
    public int IndexOf(T item)
    {
        int index = 0;
        SinglyLinkedNode<T> currentNode = this.firstNode;

        while (currentNode != null)
        {
            if (EqualityComparer<T>.Default.Equals(currentNode.Data, item))
            {
                return index;
            }

            currentNode = currentNode.NextNode;
            index++;
        }

        return -1;
    }

    /// <summary>
    /// Inserts an element into the <see cref="SinglyLinkedList&lt;T&gt;"/> at the specified index.
    /// </summary>
    /// <param name="index">The zero-based index at which item should be inserted.</param>
    /// <param name="item">The object to insert. The value can be null for reference types.</param>
    /// <exception cref="System.ArgumentOutOfRangeException">Thrown when
    /// <paramref name="index"/> is less than zero or <paramref name="index"/> is
    /// greater than or equal to <see cref="SinglyLinkedList&lt;T&gt;"/>.Count.</exception>
    public void Insert(int index, T item)
    {
        if (index < 0 || index > this.size)
        {
            throw new ArgumentOutOfRangeException(
                "index",
                "Index was out of range. Must be non-negative and less than or equal to the size of the collection.");
        }

        SinglyLinkedNode<T> newNode = new SinglyLinkedNode<T>(item);

        if (index == 0)
        {
            this.InsertBeginning(newNode);
            return;
        }

        // find the item at the specified index
        int currentIndex = 0;
        SinglyLinkedNode<T> currentNode = this.firstNode;
        while (currentIndex < index - 1)
        {
            currentNode = currentNode.NextNode;
            currentIndex++;
        }

        this.InsertAfter(currentNode, newNode);
    }

    /// <summary>
    /// Removes the first occurrence of a specific object from the <see cref="SinglyLinkedList&lt;T&gt;"/>.
    /// </summary>
    /// <param name="item">The object to remove from the <see cref="SinglyLinkedList&lt;T&gt;"/>.
    /// The value can be null for reference types.</param>
    /// <returns>true if item is successfully removed; otherwise, false. This method also
    /// returns false if item was not found in the <see cref="SinglyLinkedList&lt;T&gt;"/>.</returns>
    public bool Remove(T item)
    {
        if (this.size == 0)
        {
            return false;
        }

        if (this.size == 1)
        {
            if (EqualityComparer<T>.Default.Equals(this.firstNode.Data, item))
            {
                this.RemoveBeginning();
                return true;
            }

            return false;
        }

        // find the node which contains the item
        SinglyLinkedNode<T> currentNode = this.firstNode;

        while (currentNode.NextNode != null)
        {
            if (EqualityComparer<T>.Default.Equals(currentNode.NextNode.Data, item))
            {
                break;
            }

            currentNode = currentNode.NextNode;
        }

        if (currentNode.NextNode != null)
        {
            this.RemoveAfter(currentNode);
            return true;
        }
        else
        {
            // the node was not found
            return false;
        }
    }

    /// <summary>
    /// Removes the element at the specified index of the <see cref="SinglyLinkedList&lt;T&gt;"/>.
    /// </summary>
    /// <param name="index">The zero-based index of the element to remove.</param>
    /// <exception cref="System.ArgumentOutOfRangeException">Thrown when
    /// <paramref name="index"/> is less than zero or <paramref name="index"/> is
    /// greater than or equal to <see cref="SinglyLinkedList&lt;T&gt;"/>.Count.</exception>
    public void RemoveAt(int index)
    {
        if (index < 0 || index >= this.size)
        {
            throw new ArgumentOutOfRangeException(
                "index",
                "Index was out of range. Must be non-negative and less than the size of the collection.");
        }

        if (index == 0)
        {
            this.RemoveBeginning();
            return;
        }

        // find the item at the specified index
        int currentIndex = 0;
        SinglyLinkedNode<T> currentNode = this.firstNode;
        while (currentIndex < index - 1)
        {
            currentNode = currentNode.NextNode;
            currentIndex++;
        }

        this.RemoveAfter(currentNode);
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Inserts <paramref name="newNode"/> after <paramref name="node"/>.
    /// </summary>
    /// <param name="node"></param>
    /// <param name="newNode"></param>
    private void InsertAfter(SinglyLinkedNode<T> node, SinglyLinkedNode<T> newNode)
    {
        newNode.NextNode = node.NextNode;
        node.NextNode = newNode;
        this.size++;
    }

    /// <summary>
    /// Inserts <paramref name="newNode"/> before current first node.
    /// </summary>
    /// <param name="newNode"></param>
    private void InsertBeginning(SinglyLinkedNode<T> newNode)
    {
        newNode.NextNode = this.firstNode;
        this.firstNode = newNode;
        this.size++;
    }

    /// <summary>
    /// Removes the node after <paramref name="node"/>.
    /// </summary>
    /// <param name="node"></param>
    private void RemoveAfter(SinglyLinkedNode<T> node)
    {
        node.NextNode = node.NextNode.NextNode;
        this.size--;
    }

    /// <summary>
    /// Removes the first node.
    /// </summary>
    private void RemoveBeginning()
    {
        // point past deleted node
        this.firstNode = this.firstNode.NextNode;
        this.size--;
    }

    #endregion
}
