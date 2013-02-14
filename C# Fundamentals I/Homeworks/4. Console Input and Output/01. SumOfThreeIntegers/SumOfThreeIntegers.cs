using Nakov.IO;
using System;

class SumOfThreeIntegers
{
    static void Main()
    {
        //PrintTheSumOfThreeIntegers();

        PrintSumOfIntegersUsingNakovCin(3);
    }

    private static void PrintTheSumOfThreeIntegers()
    {
        string firstNumber;
        string secondNumber;
        string thirdNumber;

        int a;
        int b;
        int c;
        int sum;

        do
        {
            Console.WriteLine("First number:");
            firstNumber = Console.ReadLine();
        }
        while (!Int32.TryParse(firstNumber, out a));

        do
        {
            Console.WriteLine("Second number:");
            secondNumber = Console.ReadLine();
        }
        while (!Int32.TryParse(secondNumber, out b));

        do
        {
            Console.WriteLine("Third number:");
            thirdNumber = Console.ReadLine();
        }
        while (!Int32.TryParse(thirdNumber, out c));

        try
        {
            checked
            {
                sum = a + b + c;
            }

            Console.WriteLine("The sum of {0}, {1} and {2} equals to {3}.", a, b, c, sum);
        }
        catch (OverflowException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void PrintSumOfIntegersUsingNakovCin(int numbersCount)
    {
        Console.WriteLine("Enter {0} integers separated by a space:", numbersCount);

        try
        {
            int[] numbers = new int[numbersCount];

            int sum = 0;

            checked
            {
                for (int i = 0; i < numbersCount; i++)
                {
                    numbers[i] = Cin.NextInt();
                    sum += numbers[i];
                }
            }

            Console.WriteLine("The sum of the first {0} integers equals to {1}.", numbersCount, sum);
        }
        catch (FormatException formatEx)
        {
            Console.WriteLine(formatEx.Message);
        }
        catch (OverflowException overflowEx)
        {
            Console.WriteLine(overflowEx.Message);
        }
    }
}
