using System;
using System.Collections;
using System.Collections.Generic;

public class HashedSet<T> : IEnumerable<T>, ICollection<T>
{
    #region Private Fields

    private HashTable<T, bool> hashTable;

    #endregion

    #region Constructors

    public HashedSet()
    {
        this.hashTable = new HashTable<T, bool>();
    }

    public HashedSet(IEnumerable<T> collection)
    {
        this.hashTable = new HashTable<T, bool>();

        foreach (T item in collection)
        {
            // if the item has already been added, don't throw an exception
            this.Insert(item, false);
        }
    }

    public HashedSet(IEqualityComparer<T> comparer)
    {
        this.hashTable = new HashTable<T, bool>(comparer);
    }

    #endregion

    #region Properties

    public IEqualityComparer<T> Comparer
    {
        get
        {
            return this.hashTable.Comparer;
        }
    }

    public bool IsReadOnly
    {
        get
        {
            return false;
        }
    }

    public int Count
    {
        get
        {
            return this.hashTable.Count;
        }
    }

    #endregion

    #region Public Methods

    public bool Add(T item)
    {
        if (this.Contains(item))
        {
            return false;
        }

        this.Insert(item, true);
        return true;
    }

    public void Clear()
    {
        this.hashTable.Clear();
    }

    public bool Contains(T item)
    {
        return this.hashTable.ContainsKey(item);
    }

    public bool Remove(T item)
    {
        return this.hashTable.Remove(item);
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

        if (arrayIndex + this.Count > array.Length)
        {
            throw new ArgumentException(
                "Destination array was not long enough. " +
                "Check arrayIndex and the array's length.");
        }

        int index = arrayIndex;

        foreach (T item in this)
        {
            array[index++] = item;
        }
    }

    public T[] ToArray()
    {
        T[] array = new T[this.Count];

        int index = 0;

        foreach (T item in this)
        {
            array[index++] = item;
        }

        return array;
    }

    public IEnumerator<T> GetEnumerator()
    {
        foreach (KeyValuePair<T, bool> entry in this.hashTable)
        {
            yield return entry.Key;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable<T>)this).GetEnumerator();
    }

    public void ExceptWith(HashedSet<T> other)
    {
        this.CheckConsistency(other);

        if (object.ReferenceEquals(this, other))
        {
            this.Clear();
        }

        foreach (T item in other)
        {
            this.Remove(item);
        }
    }

    public void IntersectWith(HashedSet<T> other)
    {
        this.CheckConsistency(other);

        if (object.ReferenceEquals(this, other))
        {
            return;
        }

        List<T> itemsToRemove = new List<T>();

        foreach (T item in this)
        {
            if (!other.Contains(item))
            {
                itemsToRemove.Add(item);
            }
        }

        foreach (T item in itemsToRemove)
        {
            this.Remove(item);
        }
    }

    public bool IsProperSubsetOf(HashedSet<T> other)
    {
        return other.IsProperSupersetOf(this);
    }

    public bool IsProperSupersetOf(HashedSet<T> other)
    {
        this.CheckConsistency(other);

        if (object.ReferenceEquals(this, other))
        {
            return false;
        }

        if (other.Count >= this.Count)
        {
            return false;
        }

        return this.IsSupersetOf(other);
    }

    public bool IsSubsetOf(HashedSet<T> other)
    {
        return other.IsSupersetOf(this);
    }

    public bool IsSupersetOf(HashedSet<T> other)
    {
        this.CheckConsistency(other);

        if (object.ReferenceEquals(this, other))
        {
            return true;
        }

        if (other.Count > this.Count)
        {
            return false;
        }

        foreach (T item in other)
        {
            if (!this.Contains(item))
            {
                return false;
            }
        }

        return true;
    }

    public bool IsDisjointFrom(HashedSet<T> other)
    {
        return !this.Overlaps(other);
    }

    public bool Overlaps(HashedSet<T> other)
    {
        this.CheckConsistency(other);

        if (this.Count == 0)
        {
            return false;
        }

        if (object.ReferenceEquals(this, other))
        {
            return true;
        }

        foreach (T item in other)
        {
            if (this.Contains(item))
            {
                return true;
            }
        }

        return false;
    }

    public bool IsEqualTo(HashedSet<T> other)
    {
        this.CheckConsistency(other);

        if (object.ReferenceEquals(this, other))
        {
            return true;
        }

        if (other.Count != this.Count)
        {
            return false;
        }

        foreach (T item in other)
        {
            if (!this.Contains(item))
            {
                return false;
            }
        }

        return true;
    }

    public void SymmetricExceptWith(HashedSet<T> other)
    {
        this.CheckConsistency(other);

        if (object.ReferenceEquals(this, other))
        {
            this.Clear();
        }

        foreach (T item in other)
        {
            if (this.Remove(item))
            {
                // the item was present in this set 
                // and was successfully removed
                continue;
            }

            // the item was not found in this set => add it
            this.Insert(item, true);
        }
    }

    public void UnionWith(HashedSet<T> other)
    {
        this.CheckConsistency(other);

        if (object.ReferenceEquals(this, other))
        {
            return;
        }

        foreach (T item in other)
        {
            this.Insert(item, false);
        }
    }

    void ICollection<T>.Add(T item)
    {
        this.Add(item);
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Checks if both sets were created using the same
    /// equality comparer.
    /// </summary>
    /// <param name="other"></param>
    private void CheckConsistency(HashedSet<T> other)
    {
        if (other == null)
        {
            throw new ArgumentNullException("other", "Value cannot be null.");
        }

        if (!object.Equals(this.Comparer, other.Comparer))
        {
            throw new InvalidOperationException("Inconsistent comparers.");
        }
    }

    private void Insert(T item, bool add)
    {
        if (add)
        {
            // throws an exception if the item has already been added
            this.hashTable.Add(item, true);
        }
        else
        {
            // if the item has already been added, sets its value anew
            this.hashTable[item] = true;
        }
    }

    #endregion
}
