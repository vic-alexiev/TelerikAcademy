using System;

internal class PermutationWithRepetitionGenerator
{
    private static void GeneratePermutations(int[] items, int position)
    {
        if (position == 0)
        {
            Console.WriteLine(string.Join(" ", items));
            return;
        }

        GeneratePermutations(items, position - 1);

        for (int i = 0; i < position; i++)
        {
            if (items[i] != items[position])
            {
                int temp = items[i];
                items[i] = items[position];
                items[position] = temp;

                GeneratePermutations(items, position - 1);

                temp = items[i];
                items[i] = items[position];
                items[position] = temp;
            }
        }
    }

    private static void Main()
    {
        int[] items = new int[] { 5, 1, 3, 5, 5 };
        //int[] items = new int[] { 1, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 };

        Array.Sort(items);
        GeneratePermutations(items, items.Length - 1);
    }
}
