using Nakov.IO;
using System;

class FindMostFrequentElement
{
    /// <summary>
    /// Can be used as a solution if the array is first sorted.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="start"></param>
    /// <returns></returns>
    private static int GetLengthOfLongestContiguousSubsequenceOfEqualElements(int[] value, out int start)
    {
        int size = value.Length;

        int length = 1;
        int startIndex = 0;
        int maxLength = 1;
        start = 0;

        for (int i = 1; i < size; i++)
        {
            if (value[i] == value[i - 1])
            {
                length++;
            }

            // the adjacent elements are different - 
            // check if the sequence which has just finished
            // is the longest sequence so far
            if (value[i] != value[i - 1] || i == size - 1)
            {
                if (maxLength < length)
                {
                    maxLength = length;
                    start = startIndex;
                }

                if (i < size - 1)
                {
                    startIndex = i;
                    length = 1;
                }
            }
        }

        return maxLength;
    }

    private static int GetMostFrequentElement(int[] array, out int occurrences)
    {
        int n = array.Length;
        occurrences = 1;
        int element = array[0];

        for (int i = 0; i < n; i++)
        {
            int count = 1;
            for (int j = i + 1; j < n; j++)
            {
                if (array[j] == array[i])
                {
                    count++;
                }
            }

            if (occurrences < count)
            {
                occurrences = count;
                element = array[i];
            }
        }

        return element;
    }

    static void Main()
    {
        string numberN;
        int n;

        do
        {
            Console.Write("Enter the size of the array: ");
            numberN = Console.ReadLine();
        }
        while (!Int32.TryParse(numberN, out n) || n <= 0);

        int[] numbers = new int[n];

        Console.Write("Enter {0} integers separated by spaces: ", n);

        for (int i = 0; i < n; i++)
        {
            numbers[i] = Cin.NextInt();
        }

        // I solution
        //Array.Sort(numbers);

        //int start;
        //int length = GetLengthOfLongestContiguousSubsequenceOfEqualElements(numbers, out start);

        //Console.WriteLine("The most frequent number is {0} ({1} occurrence(s)).", numbers[start], length);

        // II solution
        int occurrences;
        int element = GetMostFrequentElement(numbers, out occurrences);

        Console.WriteLine("The most frequent number is {0} ({1} occurrence(s)).", element, occurrences);
    }
}
