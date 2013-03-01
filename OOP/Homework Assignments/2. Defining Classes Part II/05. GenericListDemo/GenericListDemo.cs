using System;

class GenericListDemo
{
    private static T Min<T>(GenericList<T> list)
        where T : IComparable<T>
    {
        if (list == null || list.Count == 0)
        {
            throw new ArgumentException("The list cannot be null or empty.");
        }

        if (list.Count == 1)
        {
            return list[0];
        }

        T min = list[0];

        for (int i = 1; i < list.Count; i++)
        {
            if (min.CompareTo(list[i]) > 0)
            {
                min = list[i];
            }
        }

        return min;
    }

    private static T Max<T>(GenericList<T> list)
        where T : IComparable<T>
    {
        if (list == null || list.Count == 0)
        {
            throw new ArgumentException("The list cannot be null or empty.");
        }

        if (list.Count == 1)
        {
            return list[0];
        }

        T max = list[0];

        for (int i = 1; i < list.Count; i++)
        {
            if (max.CompareTo(list[i]) < 0)
            {
                max = list[i];
            }
        }

        return max;
    }

    static void Main()
    {
        GenericList<double> list1 = new GenericList<double>();
        list1.Add(1);
        list1.Add(2);
        list1.Add(3);
        list1.Add(4);
        list1.Add(5);

        Console.WriteLine(list1);

        list1.RemoveAt(3);

        Console.WriteLine(list1);

        list1.Insert(0, 20);
        list1.Insert(5, 100);

        Console.WriteLine(list1);

        int value = 5;

        int pos = list1.FindIndex(i => i == value);

        Console.WriteLine("{0} is at index {1}", value, pos);

        // using the member methods
        double min1 = list1.Min();

        Console.WriteLine("Min: {0}", min1);

        double max1 = list1.Max();

        Console.WriteLine("Max: {0}", max1);

        // using the external methods
        double min2 = Min(list1);

        Console.WriteLine("Min: {0}", min2);

        double max2 = Max(list1);

        Console.WriteLine("Max: {0}", max2);

        // using the extension methods
        double min3 = list1.GetMin();

        Console.WriteLine("Min: {0}", min3);

        double max3 = list1.GetMax();

        Console.WriteLine("Max: {0}", max3);
    }
}
