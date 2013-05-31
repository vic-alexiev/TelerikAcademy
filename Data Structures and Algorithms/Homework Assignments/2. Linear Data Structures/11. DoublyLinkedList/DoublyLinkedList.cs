using System;
using System.Collections;
using System.Collections.Generic;

public class DoublyLinkedList<T> : IList<T>
{
    #region Private Fields

    private int size;

    /// <summary>
    /// Points to the first node of the list.
    /// </summary>
    private DoublyLinkedNode<T> firstNode;

    /// <summary>
    /// Points to the last node of the list.
    /// </summary>
    private DoublyLinkedNode<T> lastNode;

    #endregion

    #region Properties

    public int Count
    {
        get
        {
            return this.size;
        }
    }

    public bool IsReadOnly
    {
        get
        {
            return false;
        }
    }

    #endregion

    #region Indexers

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

            DoublyLinkedNode<T> currentNode = this.firstNode;

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

            DoublyLinkedNode<T> currentNode = this.firstNode;

            for (int i = 0; i < index; i++)
            {
                currentNode = currentNode.NextNode;
            }

            currentNode.Data = value;
        }
    }

    #endregion

    #region Constructors

    public DoublyLinkedList()
    {
        this.size = 0;
        this.firstNode = null;
        this.lastNode = null;
    }

    #endregion

    #region Public Methods

    public int IndexOf(T item)
    {
        int index = 0;
        DoublyLinkedNode<T> currentNode = this.firstNode;

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

    public void Insert(int index, T item)
    {
        if (index < 0 || index > this.size)
        {
            throw new ArgumentOutOfRangeException(
                "index",
                "Index was out of range. Must be non-negative and less than or equal to the size of the collection.");
        }

        DoublyLinkedNode<T> newNode = new DoublyLinkedNode<T>(item);

        if (index == 0)
        {
            this.InsertBeginning(newNode);
            return;
        }

        // find the item at the specified index
        int currentIndex = 0;
        DoublyLinkedNode<T> currentNode = this.firstNode;
        while (currentIndex < index - 1)
        {
            currentNode = currentNode.NextNode;
            currentIndex++;
        }

        this.InsertAfter(currentNode, newNode);
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= this.size)
        {
            throw new ArgumentOutOfRangeException(
                "index",
                "Index was out of range. Must be non-negative and less than the size of the collection.");
        }

        // find the item at the specified index
        int currentIndex = 0;
        DoublyLinkedNode<T> currentNode = this.firstNode;
        while (currentIndex < index)
        {
            currentNode = currentNode.NextNode;
            currentIndex++;
        }

        this.Remove(currentNode);
    }

    public void Add(T item)
    {
        DoublyLinkedNode<T> newNode = new DoublyLinkedNode<T>(item);
        this.InsertEnd(newNode);
    }

    public void Clear()
    {
        this.size = 0;
        this.firstNode = null;
        this.lastNode = null;
    }

    public bool Contains(T item)
    {
        int index = this.IndexOf(item);
        bool found = (index != -1);
        return found;
    }

    public void CopyTo(T[] array)
    {
        this.CopyTo(array, 0);
    }

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

        foreach (DoublyLinkedNode<T> node in this.firstNode)
        {
            array[index] = node.Data;
            index++;
        }
    }

    public bool Remove(T item)
    {
        if (this.size == 0)
        {
            return false;
        }

        // find the node which contains the item
        DoublyLinkedNode<T> currentNode = this.firstNode;

        while (currentNode != null)
        {
            if (EqualityComparer<T>.Default.Equals(currentNode.Data, item))
            {
                break;
            }

            currentNode = currentNode.NextNode;
        }

        if (currentNode != null)
        {
            this.Remove(currentNode);
            return true;
        }
        else
        {
            // the node was not found
            return false;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        foreach (DoublyLinkedNode<T> node in this.firstNode)
        {
            yield return node.Data;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable<T>)this).GetEnumerator();
    }

    #endregion

    #region Private Methods

    private void InsertAfter(DoublyLinkedNode<T> node, DoublyLinkedNode<T> newNode)
    {
        newNode.PreviousNode = node;
        newNode.NextNode = node.NextNode;
        if (node.NextNode == null)
        {
            this.lastNode = newNode;
        }
        else
        {
            node.NextNode.PreviousNode = newNode;
        }

        node.NextNode = newNode;
        this.size++;
    }

    private void InsertBefore(DoublyLinkedNode<T> node, DoublyLinkedNode<T> newNode)
    {
        newNode.PreviousNode = node.PreviousNode;
        newNode.NextNode = node;
        if (node.PreviousNode == null)
        {
            this.firstNode = newNode;
        }
        else
        {
            node.PreviousNode.NextNode = newNode;
        }

        node.PreviousNode = newNode;
        this.size++;
    }

    private void InsertBeginning(DoublyLinkedNode<T> newNode)
    {
        if (this.firstNode == null)
        {
            this.firstNode = newNode;
            this.lastNode = newNode;
            newNode.PreviousNode = null;
            newNode.NextNode = null;
            this.size++;
        }
        else
        {
            this.InsertBefore(this.firstNode, newNode);
        }
    }

    private void InsertEnd(DoublyLinkedNode<T> newNode)
    {
        if (this.lastNode == null)
        {
            this.InsertBeginning(newNode);
        }
        else
        {
            this.InsertAfter(this.lastNode, newNode);
        }
    }

    private void Remove(DoublyLinkedNode<T> node)
    {
        if (node.PreviousNode == null)
        {
            this.firstNode = node.NextNode;
        }
        else
        {
            node.PreviousNode.NextNode = node.NextNode;
        }

        if (node.NextNode == null)
        {
            this.lastNode = node.PreviousNode;
        }
        else
        {
            node.NextNode.PreviousNode = node.PreviousNode;
        }

        this.size--;
    }

    #endregion
}
