using System;

internal class KnapsackProblem
{
    /// <summary>
    /// Uses the algorithm described at
    /// http://www.8bitavenue.com/2011/12/dynamic-programming-integer-knapsack/
    /// </summary>
    /// <param name="V"></param>
    /// <param name="S"></param>
    /// <param name="C"></param>
    private static void SolveKnapsackProblemDuplicatesAllowed(int[] V, int[] S, int C)
    {
        // Assume the array V[i] 
        // contains the values of the items
        // Assume the array S[i] 
        // contains the sizes of the items

        int n = V.Length;
        int[] M = new int[C + 1];
        int[] b = new int[C + 1];

        // Trivial case when (j=0) 
        // the value we get is also zero
        M[0] = 0;

        // For each slot (j) in the knapsack do
        for (int j = 1; j <= C; j++)
        {
            // M[j] will be max1 (or M[j-1]) 
            // if the jth slot is empty
            int max1 = M[j - 1];

            // M[j] will be max2 if the jth 
            // slot is occupied by some item
            // Initialize max2 to some small number
            int max2 = -999999;

            // This is used to mark the previous (j) 
            // slot if the jth slot is occupied
            int mark = 0;

            // Search for an item to occupy the jth 
            // slot such that it gives us maximum value
            for (int i = 0; i < n; i++)
            {
                // For each item (i) calculate (V[i] + M[j - S[i]]) 
                // then compare it to the current max. If it is greater 
                // then update the current max. Only those items satisfying 
                // the condition (j - S[i] >= 0) are checked because capacity 
                // should not be negative
                if (j - S[i] >= 0 && V[i] + M[j - S[i]] > max2)
                {
                    // Update the max
                    max2 = V[i] + M[j - S[i]];
                    // Save the previous (j) position 
                    // that gives us the maximum value
                    mark = j - S[i];
                }
            }

            //Case1: jth slot is empty
            if (max1 > max2)
            {
                M[j] = max1;
                b[j] = j - 1;
            }
            //Case 2: jth slot is occupied
            else
            {
                M[j] = max2;
                b[j] = mark;
            }
        }

        Console.WriteLine(
            "The maximum value we can get by filling\r\n" +
            "the knapsack with capacity {0} is {1}.",
            C,
            M[C]);
    }

    /// <summary>
    /// Uses the algorithm described at
    /// http://www.8bitavenue.com/2011/12/dynamic-programming-integer-knapsack/
    /// However it is slightly changed since we are solving the "01 Knapsack Problem",
    /// where duplicate items are not allowed.
    /// </summary>
    /// <param name="V"></param>
    /// <param name="S"></param>
    /// <param name="C"></param>
    private static void SolveKnapsackProblemNoDuplicatesAllowed(int[] V, int[] S, int C)
    {
        // Assume the array V[i] 
        // contains the values of the items
        // Assume the array S[i] 
        // contains the sizes of the items

        int n = V.Length;
        bool[,] used = new bool[C + 1, n];
        int[] M = new int[C + 1];

        // Trivial case when (j=0) 
        // the value we get is also zero
        M[0] = 0;

        // For each slot (j) in the knapsack do
        for (int j = 1; j <= C; j++)
        {
            // M[j] will be max1 (or M[j-1]) 
            // if the jth slot is empty
            int max1 = M[j - 1];

            // M[j] will be max2 if the jth 
            // slot is occupied by some item
            // Initialize max2 to some small number
            int max2 = -999999;

            // This is used to mark the previous (j) 
            // slot if the jth slot is occupied
            int mark = 0;

            // This is used to keep the index
            // of the last candidate which can be put
            // in the knapsack
            int candidateUsed = 0;

            // Search for an item to occupy the jth 
            // slot such that it gives us maximum value
            for (int i = 0; i < n; i++)
            {
                // For each item (i) calculate (V[i] + M[j - S[i]]) 
                // then compare it to the current max. If it is greater 
                // then update the current max. Only those items satisfying 
                // the condition (j - S[i] >= 0) are checked because capacity 
                // should not be negative
                if (j - S[i] >= 0 && !used[j - S[i], i] && V[i] + M[j - S[i]] > max2)
                {
                    // Update the max
                    max2 = V[i] + M[j - S[i]];
                    // Save the previous (j) position 
                    // that gives us the maximum value
                    mark = j - S[i];
                    // Update the candidate item which
                    // might be put in the knapsack
                    candidateUsed = i;
                }
            }

            //Case1: jth slot is empty
            if (max1 > max2)
            {
                M[j] = max1;

                for (int k = 0; k < n; k++)
                {
                    used[j, k] = used[j - 1, k];
                }
            }
            //Case 2: jth slot is occupied
            else
            {
                M[j] = max2;

                for (int k = 0; k < n; k++)
                {
                    used[j, k] = used[mark, k];
                }

                // mark the candidate as used, which will prevent us
                // from putting it again in the knapsack
                used[j, candidateUsed] = true;
            }
        }

        Console.WriteLine(
            "The maximum value we can get by filling\r\n" +
            "the knapsack with capacity {0} is {1}.",
            C,
            M[C]);

        for (int i = 0; i < n; i++)
        {
            if (used[C, i])
            {
                Console.WriteLine("Size: {0}, Value: {1}", S[i], V[i]);
            }
        }
    }

    private static void Main()
    {
        //int[] sizes = new int[] { 2, 3, 4 };
        //int[] values = new int[] { 3, 7, 1 };
        //int capacity = 4;

        //int[] sizes = new int[] { 30, 15, 50, 10, 20, 40, 5, 65 };
        //int[] values = new int[] { 5, 3, 9, 1, 2, 7, 1, 12 };
        //int capacity = 70;

        //int[] sizes = new int[] { 1, 2, 3, 5, 6, 7 };
        //int[] values = new int[] { 1, 10, 19, 22, 25, 30 };
        //int capacity = 15;

        //int[] sizes = new int[] { 6, 3, 10, 2, 4, 8, 1, 13, 3 };
        //int[] values = new int[] { 5, 3, 9, 1, 2, 7, 1, 12, 3 };
        //int capacity = 14;

        int[] sizes = new int[] { 3, 8, 4, 1, 2, 8 };
        int[] values = new int[] { 2, 12, 5, 4, 3, 13 };
        int capacity = 10;

        SolveKnapsackProblemNoDuplicatesAllowed(values, sizes, capacity);
    }
}