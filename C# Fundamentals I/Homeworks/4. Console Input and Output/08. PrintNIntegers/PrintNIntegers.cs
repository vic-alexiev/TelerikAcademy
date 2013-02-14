using System;
using System.Globalization;

class PrintNIntegers
{
    static void Main()
    {
        string number;
        int count;

        do
        {
            Console.Write("Enter a positive integer number (> 1): ");
            number = Console.ReadLine();
        }
        while (!Int32.TryParse(number, NumberStyles.Number, CultureInfo.InvariantCulture, out count)
            || count <= 1);

        for (int i = 0; i < count; i++)
        {
            Console.WriteLine(i + 1);
        }
    }
}
