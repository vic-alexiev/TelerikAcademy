using System;
using System.Globalization;

class IntegersCongruentModulo5
{
    static void Main()
    {
        uint modulus = 17;
        uint congruentNumbersCount = 0;

        string firstNumber;
        string secondNumber;

        uint a;
        uint b;

        do
        {
            Console.WriteLine("First number:");
            firstNumber = Console.ReadLine();
        }
        while (!UInt32.TryParse(firstNumber, NumberStyles.Number, CultureInfo.InvariantCulture, out a) || a == 0);

        do
        {
            Console.WriteLine("Second number:");
            secondNumber = Console.ReadLine();
        }
        while (!UInt32.TryParse(secondNumber, NumberStyles.Number, CultureInfo.InvariantCulture, out b) || b == 0);

        // swap the values if necessary
        if (a > b)
        {
            b ^= a;
            a ^= b;
            b ^= a;
        }

        congruentNumbersCount = b / modulus - (a - 1) / modulus;

        // find the first number i >= a which leaves a remainder of 0 if divided by the modulus.
        //uint r = a % modulus;
        //ulong i = a;
        //if (r != 0)
        //{
        //    i += modulus - r;
        //}

        //while (i <= b)
        //{
        //    congruentNumbersCount++;
        //    i += modulus;
        //}

        Console.WriteLine("There are {0} numbers in [{1}; {2}] that leave a remainder of 0 if divided by {3}.",
            congruentNumbersCount, a, b, modulus);
    }
}
