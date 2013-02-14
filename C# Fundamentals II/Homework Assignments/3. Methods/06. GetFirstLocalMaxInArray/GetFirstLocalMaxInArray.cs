using System;

public class GetFirstLocalMaxInArray
{
    public static int GetIndexOfFirstLocalMax<T>(T[] array) where T : IComparable<T>
    {
        if (array == null || array.Length == 0)
        {
            throw new ArgumentException("The array is null or empty.");
        }

        int n = array.Length;

        for (int i = 0; i < n; i++)
        {
            if (CheckIfElementIsLocalMax.IsLocalMax(array, i))
            {
                return i;
            }
        }

        return -1;
    }

    static void Main()
    {
        try
        {
            //int firstLocalMaxIndex = GetIndexOfFirstLocalMax(new int[] { 6, 6, 6, 6, 6 });
            //int firstLocalMaxIndex = GetIndexOfFirstLocalMax(new int[] { 6, 7, 9, 10, 10 });
            //int firstLocalMaxIndex = GetIndexOfFirstLocalMax(new int[] { 6, 7, 9, 0, -1 });
            //int firstLocalMaxIndex = GetIndexOfFirstLocalMax((int[])null);
            //int firstLocalMaxIndex = GetIndexOfFirstLocalMax(new int[0]);
            int firstLocalMaxIndex = GetIndexOfFirstLocalMax(new decimal[] { -245.98M, 6.79M, 5.234M, 9.0M, 0, -1 });

            Console.WriteLine(firstLocalMaxIndex);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
