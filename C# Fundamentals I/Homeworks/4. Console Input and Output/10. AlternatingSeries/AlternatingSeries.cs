using System;

class AlternatingSeries
{
    /// <summary>
    /// The program calculates the sum of the first n numbers in the alternating harmonic series 
    /// 1 - 1/2 + 1/3 - 1/4 + 1/5 - ...
    /// which converges and its sum is equal to the natural logarithm of 2.
    /// <seealso cref="http://en.wikipedia.org/wiki/Alternating_harmonic_series#Alternating_harmonic_series"/>
    /// </summary>
    static void Main()
    {

        int termsCount = 1000;

        double sum = 0.0;
        double sign = -1.0;
        int index = 1;

        while (index <= termsCount)
        {
            sign = -sign;
            sum += sign / index;
            index++;
        }

        Console.WriteLine("The sum of 1 - 1/2 + 1/3 - 1/4 + 1/5 - ... = ln2 \nis approximately equal to {0}.\n", sum);

        Console.WriteLine("The sum of 1 + 1/2 - 1/3 + 1/4 - 1/5 - ...\nis approximately equal to {0}.\n", 2 - sum);
    }
}
