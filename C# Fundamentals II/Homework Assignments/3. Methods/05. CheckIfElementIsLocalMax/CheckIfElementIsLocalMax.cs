using System;

public class CheckIfElementIsLocalMax
{
    public static bool IsLocalMax<T>(T[] array, int elementIndex) where T : IComparable<T>
    {
        if (array == null || array.Length == 0)
        {
            throw new ArgumentException("The array is null or empty.");
        }

        int n = array.Length;

        if (elementIndex < 0 || elementIndex >= n)
        {
            throw new IndexOutOfRangeException("Invalid element index.");
        }

        if (n == 1)
        {
            return true;
        }

        if (elementIndex == 0)
        {
            return array[0].CompareTo(array[1]) > 0;
        }

        if (elementIndex == n - 1)
        {
            return array[n - 1].CompareTo(array[n - 2]) > 0;
        }

        return array[elementIndex].CompareTo(array[elementIndex - 1]) > 0
            && array[elementIndex].CompareTo(array[elementIndex + 1]) > 0;
    }

    static void Main()
    {
        try
        {
            bool localMax = IsLocalMax(new int[] { 1, 5, 7, 6, 9, 90, 234, -346 }, 6);
            //bool localMax = IsLocalMax(new int[] { 1, 5 }, -235);
            //bool localMax = IsLocalMax(new int[] { 1, 5 }, 10);
            //bool localMax = IsLocalMax(new int[] { 1, 5 }, 1);
            //bool localMax = IsLocalMax((int[])null, 1);
            //bool localMax = IsLocalMax(new int[0], 1);

            Console.WriteLine(localMax);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
