using System;

class WeAllLoveBits
{
    private static int GetIndexOfFirst1(uint v)
    {
        for (int i = 31; i >= 0; i--)
        {
            uint mask = 1U << i;

            if ((v & mask) != 0)
            {
                return i;
            }
        }

        return -1;
    }

    private static uint Reverse(uint v)
    {
        int pos = GetIndexOfFirst1(v);
        uint r = 0;
        for (int i = 0; i <= pos; i++)
        {
            r <<= 1;
            r |= (v & 1);
            v >>= 1;
        }

        return r;
    }

    static void Main()
    {
        string numbersCount = Console.ReadLine();
        int n;
        if (!Int32.TryParse(numbersCount, out n) || n < 1 || 20000 < n)
        {
            Console.WriteLine("Enter a number in [1, 20 000]!");
            return;
        }

        uint[] numbers = new uint[n];

        for (int i = 0; i < n; i++)
        {
            string numberAsString = Console.ReadLine();

            uint number;
            if (!UInt32.TryParse(numberAsString, out number) || number < 1 || Int32.MaxValue < number)
            {
                Console.WriteLine("Positive integers only!");
                return;
            }
            else
            {
                numbers[i] = number;
            }
        }

        foreach (var number in numbers)
        {
            Console.WriteLine(Reverse(number));
        }
    }
}
