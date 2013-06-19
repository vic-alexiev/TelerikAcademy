using System;
using System.Collections.Generic;

internal class VariationsWithRepetitionGenerator
{
    private static string[] items = new string[] { "hi", "a", "b" };

    private static void PrintSelectedItems(int[] indices)
    {
        List<string> selectedItems = new List<string>();

        foreach (int index in indices)
        {
            selectedItems.Add(items[index]);
        }

        Console.WriteLine("({0})", string.Join(" ", selectedItems));
    }

    private static void GenerateVariationsWithRepetition(int[] indices, int itemsCount, int position)
    {
        if (position == indices.Length)
        {
            PrintSelectedItems(indices);
            return;
        }

        for (int i = 0; i < itemsCount; i++)
        {
            indices[position] = i;
            GenerateVariationsWithRepetition(indices, itemsCount, position + 1);
        }
    }

    private static void Main()
    {
        int k = 2;
        int[] indices = new int[k];
        GenerateVariationsWithRepetition(indices, items.Length, 0);
    }
}
