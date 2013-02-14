using System;

public class StatisticalMethods
{
    public static int Min(params int[] args)
    {
        if (args == null || args.Length == 0)
        {
            throw new ArgumentException("Parameters list cannot be empty.");
        }

        int min = Int32.MaxValue;

        foreach (int arg in args)
        {
            if (arg < min)
            {
                min = arg;
            }
        }

        return min;
    }

    public static int Max(params int[] args)
    {
        if (args == null || args.Length == 0)
        {
            throw new ArgumentException("Parameters list cannot be empty.");
        }

        int max = Int32.MinValue;

        foreach (int arg in args)
        {
            if (arg > max)
            {
                max = arg;
            }
        }

        return max;
    }

    public static double Average(params int[] args)
    {
        if (args == null || args.Length == 0)
        {
            throw new ArgumentException("Parameters list cannot be empty.");
        }

        int sum = 0;

        foreach (int arg in args)
        {
            sum += arg;
        }

        double average = (double)sum / args.Length;

        return average;
    }

    public static int Sum(params int[] args)
    {
        if (args == null || args.Length == 0)
        {
            throw new ArgumentException("Parameters list cannot be empty.");
        }

        int sum = 0;

        foreach (int arg in args)
        {
            sum += arg;
        }

        return sum;
    }

    public static int Product(params int[] args)
    {
        if (args == null || args.Length == 0)
        {
            throw new ArgumentException("Parameters list cannot be empty.");
        }

        int product = 1;

        foreach (int arg in args)
        {
            product *= arg;
        }

        return product;
    }

    static void Main()
    {
        int min = Min(8, 9);
        Console.WriteLine(min);
    }
}
