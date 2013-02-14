using System;
using System.Globalization;

class PrintNumbersMatrix
{
    static void Main()
    {
        byte n;
        string numberN;

        do
        {
            Console.Write("Enter N in [2, 20): ");
            numberN = Console.ReadLine();
        }
        while (!Byte.TryParse(numberN, NumberStyles.Number, CultureInfo.InvariantCulture, out n) || n < 2 || n >= 20);

        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < i + n + 1; j++)
            {
                Console.Write(" {0,2}", j);
            }

            Console.WriteLine();
        }
    }
}
