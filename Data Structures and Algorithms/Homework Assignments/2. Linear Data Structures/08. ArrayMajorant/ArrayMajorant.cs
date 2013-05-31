using System;

internal class ArrayMajorant
{
    private static bool TryGetMajorant<T>(T[] source, out T result)
    {
        if (source == null)
        {
            throw new ArgumentNullException("source", "source cannot be null.");
        }

        if (source.Length == 0)
        {
            throw new ArgumentException("Sequence contains no elements.", "source");
        }

        result = default(T);

        T[] sourceCopy = new T[source.Length];
        source.CopyTo(sourceCopy, 0);

        Array.Sort(sourceCopy);

        int size = sourceCopy.Length;
        int majorantMinimumOccurrences = size / 2 + 1;

        int upperLimit = size / 2;
        if (size % 2 == 0)
        {
            upperLimit--;
        }

        // No need to loop till the end of the array.
        // If we reach the middle and there is no majorant,
        // the rest won't produce a majorant too.
        for (int index = 0; index <= upperLimit; index++)
        {
            int lastIndex = Array.LastIndexOf(sourceCopy, sourceCopy[index]);
            int subsequenceSize = lastIndex - index + 1;
            if (subsequenceSize >= majorantMinimumOccurrences)
            {
                result = sourceCopy[index];
                return true;
            }
        }

        return false;
    }

    private static void Main()
    {
        //int[] numbers = { 2, 2, 3, 3, 2, 3, 4, 3, 3 };
        int[] numbers = { 7, 8, 6, 5, 9, 9, 9, 9, 9 };

        int majorant;
        if (TryGetMajorant(numbers, out majorant))
        {
            Console.WriteLine("The majorant is {0}.", majorant);
        }
        else
        {
            Console.WriteLine("The array doesn't have a majorant.");
        }
    }
}
