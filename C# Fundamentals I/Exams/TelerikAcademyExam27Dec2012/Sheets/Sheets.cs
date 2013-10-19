using System;
using System.Collections.Generic;

class Sheets
{
    /// <summary>
    /// Returns an array of indices of the elements 
    /// which are excluded from the smallest subset whose sum is "sum".
    /// </summary>
    /// <param name="numbers"></param>
    /// <param name="sum"></param>
    /// <returns></returns>
    private static int[] GetSubsetWhichSumsTo(int[] numbers, int sum)
    {
        int numbersCount = numbers.Length;
        int subsetsCount = (1 << numbersCount);
        int subsetSum = 0;
        int subsetElements = 0;
        int minElements = 0;
        List<int> indices = null;
        int[] excludedIndices = null;

        for (int i = 1; i < subsetsCount; i++)
        {
            subsetSum = 0;
            subsetElements = 0;
            indices = new List<int>();

            for (int j = 0; j < numbersCount; j++)
            {
                // if the i-th subset contains the j-th number,
                // then we add it to the sum
                if (((i >> j) & 1) == 1)
                {
                    subsetElements++;
                    subsetSum += numbers[j];
                }
                else // the j-th number is excluded from this subset
                {
                    indices.Add(j);
                }
            }

            if (subsetSum == sum)
            {
                if (minElements == 0 || subsetElements < minElements)
                {
                    minElements = subsetElements;
                    excludedIndices = new int[indices.Count];
                    indices.CopyTo(excludedIndices);
                }
            }
        }

        return excludedIndices;
    }

    static void Main()
    {
        #region Old Solution
        //string[] sheets = { "A10", "A9", "A8", "A7", "A6", "A5", "A4", "A3", "A2", "A1", "A0" };
        //int sheetsCount = sheets.Length;

        //string numberN = Console.ReadLine();
        //int n = Int32.Parse(numberN);

        //if (n <= 0)
        //{
        //    foreach (var sheet in sheets)
        //    {
        //        Console.WriteLine(sheet);
        //    }

        //    return;
        //}

        //// keeps how many A10 sheets each sheet types contains,
        //// e.g. A10 - 1, A9 - 2, A8 - 4, ..., A0 - 1024
        //int[] numbers = new int[sheetsCount];

        //for (int i = 0; i < sheetsCount; i++)
        //{
        //    numbers[i] = (1 << i);
        //}

        //int[] excludedIndices = GetSubsetWhichSumsTo(numbers, n);

        //for (int i = 0; i < excludedIndices.Length; i++)
        //{
        //    Console.WriteLine(sheets[excludedIndices[i]]);
        //}
        #endregion

        int n = Int32.Parse(Console.ReadLine());

        for (int i = 0; i < 11; i++)
        {
            if ((n & (1 << i)) == 0)
            {
                Console.WriteLine("A" + (10 - i));
            }
        }
    }
}