using System;
using System.Collections.Generic;

internal class ShortestSequenceOfOperations
{

    private static Stack<int> GetSequence(int initialTerm, int finalTerm)
    {
        Queue<int> sequence = new Queue<int>();
        sequence.Enqueue(initialTerm);

        Dictionary<int, int> parentTerms = new Dictionary<int, int>();
        parentTerms[initialTerm] = initialTerm;

        Stack<int> terms = new Stack<int>();
        terms.Push(finalTerm);

        while (true)
        {
            int currentTerm = sequence.Dequeue();

            int nextTerm1 = currentTerm * 2;
            int nextTerm2 = currentTerm + 2;
            int nextTerm3 = currentTerm + 1;

            if (nextTerm1 == finalTerm ||
                nextTerm2 == finalTerm ||
                nextTerm3 == finalTerm)
            {
                while (currentTerm != initialTerm)
                {
                    terms.Push(currentTerm);
                    currentTerm = parentTerms[currentTerm];
                }

                terms.Push(initialTerm);
                return terms;
            }

            // If the key is already in the dictionary,
            // don't change its parent.
            if (!parentTerms.ContainsKey(nextTerm1))
            {
                parentTerms[nextTerm1] = currentTerm;
            }

            if (!parentTerms.ContainsKey(nextTerm2))
            {
                parentTerms[nextTerm2] = currentTerm;
            }

            if (!parentTerms.ContainsKey(nextTerm3))
            {
                parentTerms[nextTerm3] = currentTerm;
            }

            // if the term is already in the queue, 
            // no need to put it again
            if (!sequence.Contains(nextTerm1))
            {
                sequence.Enqueue(nextTerm1);
            }

            if (!sequence.Contains(nextTerm2))
            {
                sequence.Enqueue(nextTerm2);
            }

            if (!sequence.Contains(nextTerm3))
            {
                sequence.Enqueue(nextTerm3);
            }
        }
    }

    private static void Main()
    {
        int n = 5;
        int m = 16;

        Console.Write(
            "You are given the following operations:\n" +
            "N = N + 1;\n" +
            "N = N + 2;\n" +
            "N = N * 2;\n" +
            "These are the numbers between {0} and {1} obtained using\n" +
            "a minimum number of operations: ", n, m);

        Stack<int> sequence = GetSequence(n, m);

        while (sequence.Count > 0)
        {
            Console.Write("{0} ", sequence.Pop());
        }

        Console.WriteLine();
    }
}
