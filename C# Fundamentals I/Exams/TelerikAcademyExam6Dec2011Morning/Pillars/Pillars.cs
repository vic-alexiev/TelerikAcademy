using System;

class Pillars
{
    private static void Get1s(uint byteSizeInt, int separator, ref int left1s, ref int right1s)
    {
        uint mask;
        for (int i = 7; i > separator; i--)
        {
            mask = 1U << i;
            if ((byteSizeInt & mask) != 0)
            {
                left1s++;
            }
        }

        for (int j = separator - 1; j >= 0; j--)
        {
            mask = 1U << j;
            if ((byteSizeInt & mask) != 0)
            {
                right1s++;
            }
        }
    }

    static void Main()
    {
        int n = 8;

        uint[] numbers = new uint[n];

        for (int i = 0; i < n; i++)
        {
            string number = Console.ReadLine();
            numbers[i] = UInt32.Parse(number);
        }

        for (int col = 7; col >= 0; col--)
        {
            int left1s = 0;
            int right1s = 0;

            for (int j = 0; j < n; j++)
            {
                Get1s(numbers[j], col, ref left1s, ref right1s);
            }

            if (left1s == right1s)
            {
                Console.WriteLine("{0}\n{1}", col, left1s);
                return;
            }
        }

        Console.WriteLine("No");
    }
}
