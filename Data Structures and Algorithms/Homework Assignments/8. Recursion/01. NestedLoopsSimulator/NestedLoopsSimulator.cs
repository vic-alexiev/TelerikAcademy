using System;

internal class NestedLoopsSimulator
{
    private static void SimulateNestedLoops(int[] array, int iterations, int nestingLevel)
    {
        if (nestingLevel == iterations)
        {
            Console.WriteLine(string.Join(" ", array));
            return;
        }

        for (int i = 0; i < iterations; i++)
        {
            array[nestingLevel] = i + 1;
            SimulateNestedLoops(array, iterations, nestingLevel + 1);
        }
    }

    private static void Main()
    {
        int n = 3;
        int[] array = new int[n];
        SimulateNestedLoops(array, n, 0);
    }
}
