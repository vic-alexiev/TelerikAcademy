using System;

internal class PermutationGenerator
{
    private static void GeneratePermutations1(int[] array, bool[] used, int position)
    {
        if (position == array.Length)
        {
            Console.WriteLine(string.Join(" ", array));
            return;
        }

        for (int i = 0; i < array.Length; i++)
        {
            if (!used[i])
            {
                used[i] = true;
                array[position] = i + 1;
                GeneratePermutations1(array, used, position + 1);
                used[i] = false;
            }
        }
    }

    private static void GeneratePermutations2(int[] items, int position)
    {
        if (position == 0)
        {
            Console.WriteLine(string.Join(" ", items));
            return;
        }

        GeneratePermutations2(items, position - 1);

        for (int i = 0; i < position; i++)
        {
            int temp = items[i];
            items[i] = items[position];
            items[position] = temp;

            GeneratePermutations2(items, position - 1);

            temp = items[i];
            items[i] = items[position];
            items[position] = temp;
        }
    }

    private static void Main()
    {
        int n = 3;
        int[] array = new int[n];
        bool[] used = new bool[n];

        // I solution
        //GeneratePermutations1(array, used, 0);

        // II solution
        int[] items = new int[n];
        for (int i = 0; i < items.Length; i++)
        {
            items[i] = i + 1;
        }

        GeneratePermutations2(items, n - 1);
    }
}
