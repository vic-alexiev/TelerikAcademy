using System;
using System.Collections.Generic;

/// <summary>
/// The algorithms used to find the majority element can be found at
/// http://www.ritambhara.in/majority-element-of-an-array-moores-algorithm/
/// </summary>
internal class ArrayMajorityElement
{
    /// <summary>
    /// Returns an element which is the only candidate for majority element, i.e.
    /// if majority element exists, the method returns it. Otherwise, it returns 
    /// some frequently occurring element.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <returns></returns>
    private static T GetMajorityCandidate<T>(T[] source)
    {
        var comparer = EqualityComparer<T>.Default;
        int size = source.Length;
        int majorityIndex = 0;
        int count = 1;

        for (int i = 1; i < size; i++)
        {
            if (comparer.Equals(source[majorityIndex], source[i]))
            {
                count++;
            }
            else
            {
                count--;
            }

            if (count == 0)
            {
                majorityIndex = i;
                count = 1;
            }
        }

        return source[majorityIndex];
    }

    /// <summary>
    /// Uses Moore's voting algorithm. Finds a candidate
    /// and then checks its number of occurrences.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    private static bool TryGetMajorityElement2<T>(T[] source, out T result)
    {
        if (source == null)
        {
            throw new ArgumentNullException("source", "source cannot be null.");
        }

        int size = source.Length;

        if (size == 0)
        {
            throw new ArgumentException("Sequence contains no elements.", "source");
        }

        result = default(T);

        T candidate = GetMajorityCandidate(source);

        int occurrences = 0;
        var comparer = EqualityComparer<T>.Default;

        for (int i = 0; i < size; i++)
        {
            if (comparer.Equals(source[i], candidate))
            {
                occurrences++;
            }
        }

        if (occurrences > size / 2)
        {
            result = candidate;
            return true;
        }

        return false;
    }

    /// <summary>
    /// Sorts the array an then checks if there is a subsequence
    /// which contains (n/2 + 1) elements. If there is such a 
    /// sequence, it either ends or starts with the middle element.
    /// If the array length is even, there are two middle elements.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    private static bool TryGetMajorityElement1<T>(T[] source, out T result)
    {
        if (source == null)
        {
            throw new ArgumentNullException("source", "source cannot be null.");
        }

        int size = source.Length;

        if (size == 0)
        {
            throw new ArgumentException("Sequence contains no elements.", "source");
        }

        result = default(T);

        T[] array = new T[size];
        source.CopyTo(array, 0);

        Array.Sort(array);

        var comparer = EqualityComparer<T>.Default;

        if (size % 2 == 0)
        {
            // the array has even number of elements
            int firstMiddle = size / 2 - 1;
            int secondMiddle = size / 2;

            if (comparer.Equals(array[secondMiddle], array[0]))
            {
                result = array[secondMiddle];
                return true;
            }

            if (comparer.Equals(array[firstMiddle], array[size - 1]))
            {
                result = array[firstMiddle];
                return true;
            }

            return false;
        }
        else
        {
            // the array has odd number of elements
            if (comparer.Equals(array[size / 2], array[0]) ||
                comparer.Equals(array[size / 2], array[size - 1]))
            {
                result = array[size / 2];
                return true;
            }

            return false;
        }
    }

    private static void Main()
    {
        //int[] numbers = { 7, 8 };
        //int[] numbers = { 2, 2, 3, 3, 2, 3, 4, 3, 3 };
        int[] numbers = { 7, 8, 6, 5, 9, 9, 9, 9, 9 };

        int majorityElement;
        bool majorityElementExists = TryGetMajorityElement2(numbers, out majorityElement);
        if (majorityElementExists)
        {
            Console.WriteLine("The majority element is {0}.", majorityElement);
        }
        else
        {
            Console.WriteLine("The array doesn't have a majority element.");
        }
    }
}
