using System;
using System.Collections.Generic;

public static class IEnumerableExtension
{
    public static T Sum<T>(this IEnumerable<T> source)
        where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {
        if (source == null)
        {
            throw new ArgumentNullException("source");
        }

        T sum = default(T);

        foreach (T item in source)
        {
            sum = (dynamic)sum + item;
        }

        return sum;
    }

    public static T Product<T>(this IEnumerable<T> source)
        where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {
        if (source == null)
        {
            throw new ArgumentNullException("source");
        }

        T accumulator = (dynamic)1;

        foreach (T item in source)
        {
            accumulator = (dynamic)accumulator * item;
        }

        return accumulator;
    }

    public static T Min<T>(this IEnumerable<T> source)
        where T : IComparable<T>
    {
        if (source == null)
        {
            throw new ArgumentNullException("source");
        }

        T min = default(T);
        bool flag = false;
        foreach (T item in source)
        {
            if (!flag)
            {
                min = item;
                flag = true;
            }
            else
            {
                if (item.CompareTo(min) >= 0)
                {
                    continue;
                }
                min = item;
            }
        }
        if (!flag)
        {
            throw new InvalidOperationException("Sequence contains no elements.");
        }
        else
        {
            return min;
        }
    }

    public static T Max<T>(this IEnumerable<T> source)
        where T : IComparable<T>
    {
        if (source == null)
        {
            throw new ArgumentNullException("source");
        }

        T max = default(T);
        bool flag = false;
        foreach (T item in source)
        {
            if (!flag)
            {
                max = item;
                flag = true;
            }
            else
            {
                if (item.CompareTo(max) <= 0)
                {
                    continue;
                }
                max = item;
            }
        }
        if (!flag)
        {
            throw new InvalidOperationException("Sequence contains no elements.");
        }
        else
        {
            return max;
        }
    }

    public static decimal Average<T>(this IEnumerable<T> source)
        where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {
        if (source == null)
        {
            throw new ArgumentNullException("source");
        }

        T sum = default(T);
        long count = (long)0;

        foreach (T item in source)
        {
            sum = (dynamic)sum + item;
            count = count + (long)1;
        }

        if (count == (long)0)
        {
            throw new InvalidOperationException("Sequence contains no elements.");
        }
        else
        {
            return (dynamic)sum / (decimal)count;
        }
    }
}
