using MiscUtil;
using System;

public class GenericStatisticalMethods
{
    public static T Min<T>(params T[] args)
        where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {
        if (args == null || args.Length == 0)
        {
            throw new ArgumentException("Parameters list cannot be empty.");
        }

        T min = args[0];

        for (int i = 1; i < args.Length; i++)
        {
            if (args[i].CompareTo(min) < 0)
            {
                min = args[i];
            }
        }

        return min;
    }

    public static T Max<T>(params T[] args)
        where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {
        if (args == null || args.Length == 0)
        {
            throw new ArgumentException("Parameters list cannot be empty.");
        }

        T max = args[0];

        for (int i = 1; i < args.Length; i++)
        {
            if (args[i].CompareTo(max) > 0)
            {
                max = args[i];
            }
        }

        return max;
    }

    public static T Average<T>(params T[] args)
        where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {
        if (args == null || args.Length == 0)
        {
            throw new ArgumentException("Parameters list cannot be empty.");
        }

        T sum = Operator<T>.Zero;

        foreach (T arg in args)
        {
            sum = Operator.Add(sum, arg);
        }

        T average = Operator.Divide(sum, Operator.Convert<int, T>(args.Length));

        return average;
    }

    public static T Accumulate<T>(Func<T, T, T> operation, T seed, params T[] args)
        where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {
        if (args == null || args.Length == 0)
        {
            throw new ArgumentException("Parameters list cannot be empty.");
        }

        T accumulator = seed;

        foreach (T arg in args)
        {
            accumulator = operation(accumulator, arg);
        }

        return accumulator;
    }

    static void Main()
    {
        // find minimum
        int min = Min(7, 8, -9, 5, -5);

        Console.WriteLine(min);

        // find maximum
        long max = Max(8, 9, -34, 6, 12);

        Console.WriteLine(max);

        // find sum
        decimal sum = Accumulate(Operator.Add, 0, 20, 30, 50, 60, 7);

        Console.WriteLine("{0:N}", sum);

        // find product
        decimal product = Accumulate<decimal>(Operator.Multiply, 1, 20, 30, 50, 60, 7);

        Console.WriteLine("{0:N}", product);

        // find average
        double average = Average<double>(1, 2, 3, 4, 5, 6);

        Console.WriteLine("{0:N}", average);
    }
}
