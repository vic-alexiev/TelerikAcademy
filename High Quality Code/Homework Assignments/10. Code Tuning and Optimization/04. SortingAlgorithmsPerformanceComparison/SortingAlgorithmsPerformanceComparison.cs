using System;
using System.Diagnostics;

internal class SortingAlgorithmsPerformanceComparison
{
    private static Random randomNumberGenerator = new Random();
    private const string chars =
        "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789~`!@#$%^&*()-_=+[{]}\\|;:'\",<.>/?";

    private static string GetRandomString(int size)
    {
        char[] buffer = new char[size];
        int length = chars.Length;

        for (int i = 0; i < size; i++)
        {
            buffer[i] = chars[randomNumberGenerator.Next(length)];
        }

        return new string(buffer);
    }

    private static int[] GetRandomIntArray(int length)
    {
        int[] value = new int[length];

        for (int i = 0; i < value.Length; i++)
        {
            value[i] = randomNumberGenerator.Next(int.MinValue, int.MaxValue);
        }

        return value;
    }

    private static double[] GetRandomDoubleArray(int length)
    {
        double[] value = new double[length];

        for (int i = 0; i < value.Length; i++)
        {
            int sign = randomNumberGenerator.Next(0, 2);
            if (sign == 0)
            {
                value[i] = randomNumberGenerator.NextDouble() * double.MaxValue;
            }
            else
            {
                value[i] = randomNumberGenerator.NextDouble() * double.MinValue;
            }
        }

        return value;
    }

    private static string[] GetRandomStringArray(int length, int stringMaxSize)
    {
        string[] value = new string[length];

        for (int i = 0; i < value.Length; i++)
        {
            value[i] = GetRandomString(randomNumberGenerator.Next(1, stringMaxSize + 1));
        }

        return value;
    }

    private static void DisplayExecutionTime(Action action, string message = "")
    {
        Console.Write(message);
        Stopwatch stopwatch = Stopwatch.StartNew();
        stopwatch.Start();
        action();
        stopwatch.Stop();
        Console.WriteLine(stopwatch.Elapsed + "\n");
    }

    private static void DisplaySortingAlgorithmsComparison<T>(T[] array, bool sortBeforehand, Comparison<T> comparison = null)
        where T : IComparable<T>
    {
        if (sortBeforehand)
        {
            Array.Sort(array, comparison);
        }

        T[] array1 = (T[])array.Clone();
        T[] array2 = (T[])array.Clone();
        T[] array3 = (T[])array.Clone();

        string insertionSortMessage = string.Format("Insertion sort for {0}[]", typeof(T).Name).PadRight(35, '.') + ": ";

        DisplayExecutionTime(() =>
        {
            SortingAlgorithms.InsertionSort(array1);
        }, insertionSortMessage);

        string selectionSortMessage = string.Format("Selection sort for {0}[]", typeof(T).Name).PadRight(35, '.') + ": ";

        DisplayExecutionTime(() =>
        {
            SortingAlgorithms.SelectionSort(array2);
        }, selectionSortMessage);

        string quicksortMessage = string.Format("Quicksort for {0}[]", typeof(T).Name).PadRight(35, '.') + ": ";

        DisplayExecutionTime(() =>
        {
            SortingAlgorithms.Quicksort(array3, 0, array3.Length - 1);
        }, quicksortMessage);
    }

    private static void Main()
    {
        int[] intsArray = GetRandomIntArray(20000);
        double[] doublesArray = GetRandomDoubleArray(20000);
        string[] stringsArray = GetRandomStringArray(20000, 100);

        Console.WriteLine("\nArrays not sorted beforehand:\n");

        DisplaySortingAlgorithmsComparison((int[])intsArray.Clone(), false);

        DisplaySortingAlgorithmsComparison((double[])doublesArray.Clone(), false);

        DisplaySortingAlgorithmsComparison((string[])stringsArray.Clone(), false);

        Console.WriteLine("\nArrays sorted in ascending order beforehand:\n");

        DisplaySortingAlgorithmsComparison((int[])intsArray.Clone(), true, (a, b) => a.CompareTo(b));

        DisplaySortingAlgorithmsComparison((double[])doublesArray.Clone(), true, (a, b) => a.CompareTo(b));

        DisplaySortingAlgorithmsComparison((string[])stringsArray.Clone(), true, (a, b) => a.CompareTo(b));

        Console.WriteLine("\nArrays sorted in descending order beforehand:\n");

        DisplaySortingAlgorithmsComparison((int[])intsArray.Clone(), true, (a, b) => b.CompareTo(a));

        DisplaySortingAlgorithmsComparison((double[])doublesArray.Clone(), true, (a, b) => b.CompareTo(a));

        DisplaySortingAlgorithmsComparison((string[])stringsArray.Clone(), true, (a, b) => b.CompareTo(a));
    }
}
