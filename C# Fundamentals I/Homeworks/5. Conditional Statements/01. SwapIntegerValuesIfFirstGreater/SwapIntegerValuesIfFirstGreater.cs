using System;
using System.Globalization;

class SwapIntegerValuesIfFirstGreater
{
    static void Main()
    {
        string firstNumber;
        string secondNumber;
        int a;
        int b;

        do
        {
            Console.Write("First number: ");
            firstNumber = Console.ReadLine();
        }
        while (!Int32.TryParse(firstNumber, NumberStyles.Number, CultureInfo.InvariantCulture, out a));

        do
        {
            Console.Write("Second number: ");
            secondNumber = Console.ReadLine();
        }
        while (!Int32.TryParse(secondNumber, NumberStyles.Number, CultureInfo.InvariantCulture, out b));

        if (a > b)
        {
            //int buf = a;
            //a = b;
            //b = buf;

            //a ^= b;
            //b ^= a;
            //a ^= b;

            a = a + b;
            b = a - b;
            a = a - b;

            Console.WriteLine("Since the first number is greater than the second one, now it is {0} and the second {1}.", a, b);
        }
        else
        {
            Console.WriteLine("The first number is not greater than the second one, so it reamains {0} and the second {1}.", a, b);
        }
    }
}
