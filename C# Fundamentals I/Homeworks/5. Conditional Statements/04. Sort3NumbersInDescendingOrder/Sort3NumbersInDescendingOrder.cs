using System;
using System.Globalization;

class Sort3NumbersInDescendingOrder
{
    private static void Sort3RealNumbersInDescendingOrder()
    {
        string number1;
        string number2;
        string number3;
        double a;
        double b;
        double c;

        do
        {
            Console.Write("Enter the first number: ");
            number1 = Console.ReadLine();
        }
        while (!Double.TryParse(number1, NumberStyles.Number, CultureInfo.InvariantCulture, out a));

        do
        {
            Console.Write("Enter the second number: ");
            number2 = Console.ReadLine();
        }
        while (!Double.TryParse(number2, NumberStyles.Number, CultureInfo.InvariantCulture, out b));

        do
        {
            Console.Write("Enter the third number: ");
            number3 = Console.ReadLine();
        }
        while (!Double.TryParse(number3, NumberStyles.Number, CultureInfo.InvariantCulture, out c));

        Console.Write("The numbers in descending order:");

        if (a >= b)
        {
            if (b >= c)
            {
                Console.WriteLine(" {0} {1} {2}", a, b, c);
            }
            else if (a >= c)
            {
                Console.WriteLine(" {0} {1} {2}", a, c, b);
            }
            else
            {
                Console.WriteLine(" {0} {1} {2}", c, a, b);
            }
        }
        else if (b >= c)
        {
            if (a >= c)
            {
                Console.WriteLine(" {0} {1} {2}", b, a, c);
            }
            else
            {
                Console.WriteLine(" {0} {1} {2}", b, c, a);
            }
        }
        else
        {
            Console.WriteLine(" {0} {1} {2}", c, b, a);
        }
    }

    private static void SortRealNumbersInDescendingOrder(int numbersCount)
    {
        if (numbersCount <= 0)
        {
            return;
        }

        double[] numbers = new double[numbersCount];
        string numberAsString;
        double number;

        for (int i = 0; i < numbersCount; i++)
        {
            do
            {
                Console.Write("Enter number {0}: ", i + 1);
                numberAsString = Console.ReadLine();
            }
            while (!Double.TryParse(numberAsString, NumberStyles.Number, CultureInfo.InvariantCulture, out number));

            numbers[i] = number;
        }

        SortArray(numbers);

        Console.WriteLine("The numbers in descending order:");

        for (int j = 0; j < numbers.Length; j++)
        {
            Console.WriteLine(numbers[j]);
        }
    }
    
    /// <summary>
    /// Sorts the array of doubles in descending order.
    /// </summary>
    /// <param name="numbers"></param>
    private static void SortArray(double[] numbers)
    {
        double buffer;
        for (int i = 0; i < numbers.Length - 1; i++)
        {
            for (int j = i + 1; j < numbers.Length; j++)
            {
                if (numbers[i] < numbers[j])
                {
                    buffer = numbers[i];
                    numbers[i] = numbers[j];
                    numbers[j] = buffer;
                }
            }
        }
    }

    static void Main()
    {
        //Sort3RealNumbersInDescendingOrder();
        SortRealNumbersInDescendingOrder(10);
    }
}