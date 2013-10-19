using System;

class Lines
{
    static void Main()
    {
        int n = 8;

        int[] numbers = new int[n];

        for (int i = 0; i < n; i++)
        {
            string number = Console.ReadLine();
            numbers[i] = Int32.Parse(number);
        }

        int maxLength = 0;
        int maxLengthOccurrences = 0;

        // check for the longest 1's sequence column-wise
        for (int col = 0; col < n; col++)
        {
            int onesCount = 0;
            int mask = 1 << col;
            for (int i = 0; i < n; i++)
            {
                if ((numbers[i] & mask) != 0)
                {
                    onesCount++;
                }

                // a zero has broken the 1's sequence or the last number has been reached
                if (((numbers[i] & mask) == 0 || i == n - 1) && onesCount > 0)
                {
                    if (maxLength < onesCount)
                    {
                        maxLength = onesCount;
                        maxLengthOccurrences = 1;
                    }
                    else if (maxLength == onesCount)
                    {
                        maxLengthOccurrences++;
                    }

                    onesCount = 0;
                }
            }
        }

        // check for the longest 1's sequence row-wise
        for (int i = 0; i < n; i++)
        {
            int onesCount = 0;
            for (int col = 0; col < n; col++)
            {
                int mask = 1 << col;
                if ((numbers[i] & mask) != 0)
                {
                    onesCount++;
                }

                // a zero has broken the 1's sequence or the last column has been reached
                if (((numbers[i] & mask) == 0 || col == n - 1) && onesCount > 0)
                {
                    if (maxLength < onesCount)
                    {
                        maxLength = onesCount;
                        maxLengthOccurrences = 1;
                    }
                    else if (maxLength == onesCount)
                    {
                        maxLengthOccurrences++;
                    }

                    onesCount = 0;
                }
            }
        }

        if (maxLength == 1)
        {
            maxLengthOccurrences /= 2;
        }

        Console.WriteLine("{0}\n{1}", maxLength, maxLengthOccurrences);
    }
}
