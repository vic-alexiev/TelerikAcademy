using System;

internal class MulticombinationGenerator
{
    private static void GenerateMulticombinations(int[] array, int maxNumber, int start, int level)
    {
        if (level == array.Length)
        {
            Console.WriteLine(string.Join(" ", array));
            return;
        }

        for (int i = start; i < maxNumber; i++)
        {
            array[level] = i + 1;
            GenerateMulticombinations(array, maxNumber, i, level + 1);
        }
    }

    private static void Main()
    {
        int n = 3;
        int k = 2;
        int[] array = new int[k];
        GenerateMulticombinations(array, n, 0, 0);
    }
}
