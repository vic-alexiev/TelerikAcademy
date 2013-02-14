using System;

public class CountNumberOccurrencesInArray
{
    public static int Count<T>(T[] array, T value)
    {
        if (array == null || array.Length == 0)
        {
            return 0;
        }

        int count = 0;
        foreach (var item in array)
        {
            if (value.Equals(item))
            {
                count++;
            }
        }

        return count;
    }

    static void Main()
    {
        //int count = Count(new int[] { 1, 2, 3, 6, 9, 0, 6 }, 6);
        //int count = Count(new double[] { -234, 0.0, 3.3453, 3.1415, 2.718, 1.618, 0.0, -234.000000}, -234);
        //int count = Count(null, 6);
        int count = Count(new int[100], 0);

        Console.WriteLine(count);
    }
}
