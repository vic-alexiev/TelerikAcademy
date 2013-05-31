using System;
using System.Collections.Generic;

internal class RecurrentSequence
{
    private static int[] GetSequence(int initialTerm, int count)
    {
        Queue<int> sequence = new Queue<int>();
        sequence.Enqueue(initialTerm);

        int[] terms = new int[count];

        int index = 0;
        while (true)
        {
            int currentTerm = sequence.Dequeue();
            terms[index] = currentTerm;
            index++;

            if (index == count)
            {
                return terms;
            }

            sequence.Enqueue(currentTerm + 1);
            sequence.Enqueue(currentTerm * 2 + 1);
            sequence.Enqueue(currentTerm + 2);
        }
    }

    private static void Main()
    {
        int n = 2;
        int itemsCount = 50;

        Console.WriteLine(
            "You are given the following recurrent sequence:\n" +
            "S1 = N;\n" +
            "S2 = S1 + 1;\n" +
            "S3 = 2 * S1 + 1;\n" +
            "S4 = S1 + 2;\n" +
            "S5 = S2 + 1;\n" +
            "S6 = 2 * S2 + 1;\n" +
            "S7 = S2 + 2;\n" +
            "...\n" +
            "These are the first {0} elements if N = {1}:", itemsCount, n);
        int[] sequence = GetSequence(n, itemsCount);
        Console.WriteLine(string.Join(", ", sequence));
    }
}
