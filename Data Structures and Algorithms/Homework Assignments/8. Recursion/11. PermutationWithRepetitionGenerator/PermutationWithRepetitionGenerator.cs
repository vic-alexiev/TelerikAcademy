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

        GeneratePermutations(items, position - 1);
    }

    private static void Main()
    {
        //int[] items = new int[] { 1, 3, 5, 5 };
        int[] items = new int[] { 1, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 };
        GeneratePermutations(items, items.Length - 1);
    }
}
