using System;

public static class GenericListExtension
{
    public static T GetMin<T>(this GenericList<T> source)
        where T : IComparable<T>
    {
        if (source == null)
        {
            throw new ArgumentNullException("source");
        }

        if (source.Count == 0)
        {
            throw new InvalidOperationException("Sequence contains no elements.");
        }

        T min = source[0];

        for (int i = 1; i < source.Count; i++)
        {
            if (min.CompareTo(source[i]) > 0)
            {
                min = source[i];
            }
        }

        return min;
    }

    public static T GetMax<T>(this GenericList<T> source)
        where T : IComparable<T>
    {
        if (source == null)
        {
            throw new ArgumentNullException("source");
        }

        if (source.Count == 0)
        {
            throw new InvalidOperationException("Sequence contains no elements.");
        }

        T max = source[0];

        for (int i = 1; i < source.Count; i++)
        {
            if (max.CompareTo(source[i]) < 0)
            {
                max = source[i];
            }
        }

        return max;
    }
}
