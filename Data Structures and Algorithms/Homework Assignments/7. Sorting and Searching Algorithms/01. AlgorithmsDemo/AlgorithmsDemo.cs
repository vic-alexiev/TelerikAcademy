using Algorithms;
using System;

internal class AlgorithmsDemo
{
    private static void Main()
    {
        var collection = new SortableCollection<int>(new[] { 22, 11, 101, 33, 0, 101 });
        Console.WriteLine("All items before sorting:");
        collection.PrintToTheConsole();
        Console.WriteLine();

        Console.WriteLine("SelectionSorter result:");
        collection.Sort(new SelectionSorter<int>());
        collection.PrintToTheConsole();
        Console.WriteLine();

        Console.WriteLine("Quicksorter result:");
        collection = new SortableCollection<int>(new[] { 22, 11, 101, 33, 0, 101 });
        collection.Sort(new Quicksorter<int>());
        collection.PrintToTheConsole();
        Console.WriteLine();

        Console.WriteLine("MergeSorter result:");
        collection = new SortableCollection<int>(new[] { 22, 11, 101, 33, 0, 101 });
        collection.Sort(new MergeSorter<int>());
        collection.PrintToTheConsole();
        Console.WriteLine();

        Console.WriteLine("Linear search 101:");
        Console.WriteLine(collection.LinearSearch(101));
        Console.WriteLine();

        Console.WriteLine("Binary search 101:");
        Console.WriteLine(collection.BinarySearch(101));
        Console.WriteLine();

        Console.WriteLine("Shuffle:");
        collection.Shuffle();
        collection.PrintToTheConsole();
        Console.WriteLine();

        Console.WriteLine("Shuffle again:");
        collection.Shuffle();
        collection.PrintToTheConsole();
    }
}
