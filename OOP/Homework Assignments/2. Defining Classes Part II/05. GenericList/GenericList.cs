using System;

public class GenericList<T>
{
    #region Private Fields

    private T[] items;

    private int size;

    private readonly static T[] emptyArray;

    private const int defaultCapacity = 4;

    #endregion

    #region Properties

    public int Capacity
    {
        get
        {
            return (int)this.items.Length;
        }
        set
        {
            if (value < this.size)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (value != (int)this.items.Length)
            {
                if (value <= 0)
                {
                    this.items = GenericList<T>.emptyArray;
                }
                else
                {
                    T[] tArray = new T[value];
                    if (this.size > 0)
                    {
                        Array.Copy(this.items, 0, tArray, 0, this.size);
                    }
                    this.items = tArray;
                }
            }
        }
    }

    public int Count
    {
        get
        {
            return this.size;
        }
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= this.size)
            {
                throw new ArgumentOutOfRangeException();
            }
            return this.items[index];
        }
        set
        {
            if (index < 0 || index >= this.size)
            {
                throw new ArgumentOutOfRangeException();
            }
            this.items[index] = value;
        }
    }

    #endregion

    #region Constructors

    static GenericList()
    {
        GenericList<T>.emptyArray = new T[0];
    }

    public GenericList()
    {
        this.items = GenericList<T>.emptyArray;
    }

    public GenericList(int capacity)
    {
        if (capacity < 0)
        {
            throw new ArgumentOutOfRangeException("capacity");
        }
        if (capacity != 0)
        {
            this.items = new T[capacity];
        }
        else
        {
            this.items = GenericList<T>.emptyArray;
        }
    }

    public GenericList(T[] array)
    {
        if (array == null)
        {
            throw new ArgumentNullException("array");
        }
        else
        {
            int count = array.Length;
            if (count != 0)
            {
                this.items = new T[count];
                array.CopyTo(this.items, 0);
                this.size = count;
            }
            else
            {
                this.items = GenericList<T>.emptyArray;
            }
        }
    }

    #endregion

    #region Private Methods

    private void EnsureCapacity(int min)
    {
        int length;
        if ((int)this.items.Length < min)
        {
            if ((int)this.items.Length == 0)
            {
                length = 4;
            }
            else
            {
                length = (int)this.items.Length * 2;
            }
            int num = length;
            if (num > 2146435071)
            {
                num = 2146435071;
            }
            if (num < min)
            {
                num = min;
            }
            this.Capacity = num;
        }
    }

    #endregion

    #region Public Methods

    public void Add(T item)
    {
        if (this.size == (int)this.items.Length)
        {
            EnsureCapacity(this.size + 1);
        }

        this.items[this.size] = item;
        this.size++;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= this.size)
        {
            throw new ArgumentOutOfRangeException("index");
        }

        this.size--;

        if (index < this.size)
        {
            Array.Copy(this.items, index + 1, this.items, index, this.size - index);
        }

        T t = default(T);
        this.items[this.size] = t;
    }

    public void Insert(int index, T item)
    {
        if (index < 0 || index > this.size)
        {
            throw new ArgumentOutOfRangeException("index");
        }

        if (this.size == (int)this.items.Length)
        {
            EnsureCapacity(this.size + 1);
        }

        if (index < this.size)
        {
            Array.Copy(this.items, index, this.items, index + 1, this.size - index);
        }

        this.items[index] = item;
        this.size++;
    }

    public void Clear()
    {
        if (this.size > 0)
        {
            Array.Clear(this.items, 0, this.size);
            this.size = 0;
        }
    }

    public int FindIndex(Predicate<T> match)
    {
        if (match == null)
        {
            throw new ArgumentNullException("match");
        }

        int num = 0;
        while (num < this.size)
        {
            if (!match(this.items[num]))
            {
                num++;
            }
            else
            {
                return num;
            }
        }

        return -1;
    }

    public T Min()
    {
        if (this.size == 0)
        {
            throw new InvalidOperationException("Sequence contains no elements.");
        }

        if (this.size == 1)
        {
            return this.items[0];
        }

        if (this.items[0] is IComparable<T>)
        {
            T min = this.items[0];

            for (int i = 1; i < this.size; i++)
            {
                if ((min as IComparable<T>).CompareTo(this.items[i]) > 0)
                {
                    min = this.items[i];
                }
            }

            return min;
        }
        else
        {
            throw new ArgumentException("At least one object must implement IComparable.");
        }
    }

    public T Max()
    {
        if (this.size == 0)
        {
            throw new InvalidOperationException("Sequence contains no elements.");
        }

        if (this.size == 1)
        {
            return this.items[0];
        }

        if (this.items[0] is IComparable<T>)
        {
            T max = this.items[0];

            for (int i = 1; i < this.size; i++)
            {
                if ((max as IComparable<T>).CompareTo(this.items[i]) < 0)
                {
                    max = this.items[i];
                }
            }

            return max;
        }
        else
        {
            throw new ArgumentException("At least one object must implement IComparable.");
        }
    }

    public T[] ToArray()
    {
        T[] tArray = new T[this.size];
        Array.Copy(this.items, 0, tArray, 0, this.size);
        return tArray;
    }

    public override string ToString()
    {
        if (this.size == 0)
        {
            return String.Empty;
        }

        return String.Join(", ", this.ToArray());
    }

    #endregion
}
