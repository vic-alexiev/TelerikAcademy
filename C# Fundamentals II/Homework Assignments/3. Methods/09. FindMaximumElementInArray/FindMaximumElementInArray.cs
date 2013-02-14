using System;

public class FindMaximumElementInArray
{
    private static int GetIndexOfMaxElement<T>(T[] array, int start, int end) where T : IComparable<T>
    {
        T max = array[start];
        int maxIndex = start;
        for (int i = start + 1; i <= end; i++)
        {
            if (array[i].CompareTo(max) > 0)
            {
                max = array[i];
                maxIndex = i;
            }
        }

        return maxIndex;
    }

    public static void SelectSortAscending<T>(T[] value) where T : IComparable<T>
    {
        if (value == null)
        {
            throw new ArgumentNullException("Value cannot be null.");
        }

        if (value.Length < 2)
        {
            return;
        }

        int n = value.Length;

        for (int i = n - 1; i > 0; i--)
        {
            int maxIndex = GetIndexOfMaxElement(value, 0, i);

            if (maxIndex != i)
            {
                T temp = value[i];
                value[i] = value[maxIndex];
                value[maxIndex] = temp;
            }
        }
    }

    public static void SelectSortDescending<T>(T[] value) where T : IComparable<T>
    {
        if (value == null)
        {
            throw new ArgumentNullException("Value cannot be null.");
        }

        if (value.Length < 2)
        {
            return;
        }

        int n = value.Length;

        for (int i = 0; i < n - 1; i++)
        {
            int maxIndex = GetIndexOfMaxElement(value, i, n - 1);

            if (maxIndex != i)
            {
                T temp = value[i];
                value[i] = value[maxIndex];
                value[maxIndex] = temp;
            }
        }
    }

    static void Main()
    {
        int[] array = new int[] { 6, 3, 9, 2, 1, 0, 8, 15, -4, -3, 11, 4, 6 };
        SelectSortDescending(array);
        Console.WriteLine(String.Join(", ", array));
    }
}
