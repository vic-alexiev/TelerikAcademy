using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// The following article is used as a source:
/// http://thinkingeek.com/2009/07/09/creating-and-testing-a-linked-list-based-queue-in-c-using-nunit/
/// </summary>
/// <typeparam name="T"></typeparam>
public class LinkedListQueue<T> : IEnumerable<T>
{
    #region Private Fields

    private int size;

    /// <summary>
    /// Points to the front of the queue.
    /// </summary>
    private Node<T> head;

    /// <summary>
    /// Points to the rear of the queue.
    /// </summary>
    private Node<T> tail;

    #endregion

    #region Properties

    public int Count
    {
        get
        {
            return this.size;
        }
    }

    #endregion

    #region Public Methods

    public void Clear()
    {
        this.size = 0;
        this.head = null;
        this.tail = null;
    }

    public bool Contains(T item)
    {
        foreach (Node<T> node in this.head)
        {
            if (EqualityComparer<T>.Default.Equals(node.Data, item))
            {
                return true;
            }
        }

        return false;
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

        foreach (Node<T> node in this.head)
        {
            array[index] = node.Data;
            index++;
        }
    }

    public T Dequeue()
    {
        if (this.head == null)
        {
            throw new InvalidOperationException("Queue empty.");
        }

        T currentItem = this.head.Data;

        if (object.ReferenceEquals(this.head, this.tail))
        {
            // the queue contains a single node, which will be removed
            this.head = null;
            this.tail = null;
        }
        else
        {
            this.head = this.head.NextNode;
        }

        this.size--;

        return currentItem;
    }

    public void Enqueue(T item)
    {
        Node<T> newNode = new Node<T>(item);

        if (this.tail != null)
        {
            this.tail.NextNode = newNode;
        }
        else
        {
            this.head = newNode;
        }

        this.tail = newNode;

        this.size++;
    }

    public IEnumerator<T> GetEnumerator()
    {
        foreach (Node<T> node in this.head)
        {
            yield return node.Data;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable<T>)this).GetEnumerator();
    }

    public T Peek()
    {
        if (this.head == null)
        {
            throw new InvalidOperationException("Queue empty.");
        }

        T currentItem = this.head.Data;
        return currentItem;
    }

    public T[] ToArray()
    {
        T[] array = new T[this.size];

        int index = 0;

        foreach (Node<T> node in this.head)
        {
            array[index] = node.Data;
            index++;
        }

        return array;
    }

    public override string ToString()
    {
        if (this.size == 0)
        {
            return string.Empty;
        }

        return string.Join(", ", this.ToArray());
    }

    #endregion
}
