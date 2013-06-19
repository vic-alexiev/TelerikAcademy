using System;
using System.Collections.Generic;

internal class SubsetGenerator
{
    private static string[] items = new string[] { "test", "rock", "fun", "beer" };

    private static void PrintSelectedItems(int[] indices)
    {
        List<string> selectedItems = new List<string>();

        foreach (int index in indices)
        {
            selectedItems.Add(items[index]);
        }

        Console.WriteLine("({0})", string.Join(" ", selectedItems));
    }

    private static void GenerateSubsets(int[] indices, int itemsCount, int start, int position)
    {
        if (position == indices.Length)
        {
            PrintSelectedItems(indices);
            return;
        }

        for (int i = start; i < itemsCount; i++)
        {
            indices[position] = i;
            GenerateSubsets(indices, itemsCount, i + 1, position + 1);
        }
    }

    private static void Main()
    {
        int k = 2;
        int[] indices = new int[k];
        GenerateSubsets(indices, items.Length, 0, 0);
    }
}
