using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GenericStack<T>
{
    #region Private Fields

    private T[] array;

    private int size;

    private static T[] emptyArray;

    private const int DefaultCapacity = 4;

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

    #region Constructors

    static GenericStack()
    {
        GenericStack<T>.emptyArray = new T[0];
    }

    public GenericStack()
    {
        this.array = GenericStack<T>.emptyArray;
        this.size = 0;
    }

    public GenericStack(int capacity)
    {
        if (capacity < 0)
        {
            throw new ArgumentOutOfRangeException("capacity", "Non-negative number required.");
        }

        this.array = new T[capacity];
        this.size = 0;
    }

    #endregion

    #region Public Methods

    public void Clear()
    {
        Array.Clear(this.array, 0, this.size);
        this.size = 0;
    }

    public bool Contains(T item)
    {
        if (this.size == 0)
        {
            return false;
        }

        for (int i = 0; i < this.size; i++)
        {
            if (EqualityComparer<T>.Default.Equals(this.array[i], item))
            {
                return true;
            }
        }

        return false;
    }

    public T Peek()
    {
        if (this.size == 0)
        {
            throw new InvalidOperationException("Stack empty.");
        }

        return this.array[this.size - 1];
    }

    public T Pop()
    {
        if (this.size == 0)
        {
            throw new InvalidOperationException("Stack empty.");
        }


        T top = this.array[this.size - 1];
        this.array[this.size - 1] = default(T);
        this.size--;

        return top;
    }

    public void Push(T item)
    {
        if (this.size == this.array.Length)
        {
            int capacity;
            if (this.array.Length == 0)
            {
                capacity = DefaultCapacity;
            }
            else
            {
                capacity = 2 * this.array.Length;
            }


            T[] extendedArray = new T[capacity];
            Array.Copy(this.array, 0, extendedArray, 0, this.size);
            this.array = extendedArray;
        }

        this.array[this.size] = item;
        this.size++;
    }

    public T[] ToArray()
    {
        T[] result = new T[this.size];

        for (int i = 0; i < this.size; i++)
        {
            result[i] = this.array[this.size - i - 1];
        }

        return result;
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
