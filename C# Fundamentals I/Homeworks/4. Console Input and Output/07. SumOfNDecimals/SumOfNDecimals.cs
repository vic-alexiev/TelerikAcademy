using Nakov.IO;
using System;

class SumOfNDecimals
{
    static void Main()
    {
        string number;
        byte count;

        do
        {
            Console.Write("Enter a positive integer number: ");
            number = Console.ReadLine();
        }
        while (!Byte.TryParse(number, out count));

        PrintSumOfDecimalsUsingNakovCin(count);
    }

    private static void PrintSumOfDecimalsUsingNakovCin(int numbersCount)
    {
        Console.Write("Enter {0} decimal numbers separated by a space: ", numbersCount);

        try
        {
            decimal[] numbers = new decimal[numbersCount];

            decimal sum = 0.0M;

            for (int i = 0; i < numbersCount; i++)
            {
                numbers[i] = Cin.NextDecimal();
                sum += numbers[i];
            }

            Console.WriteLine("The sum of the numbers equals to {0}.", sum);
        }
        catch (FormatException formatEx)
        {
            Console.WriteLine(formatEx.Message);
        }
        catch (OverflowException overflowEx)
        {
            Console.WriteLine(overflowEx);
        }
    }
}
