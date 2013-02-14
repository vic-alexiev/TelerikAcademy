using System;

class PrintCombinations
{
    private static int[] numbers;
    private static int n;
    private static int k;

    private static void Print(int length)
    {
        for (int i = 0; i < length; i++)
        {
            Console.Write("{0} ", numbers[i] + 1);
        }

        Console.WriteLine();
    }

    private static void Combine(int i, int after)
    {
        if (i > k)
        {
            return;
        }

        for (int j = after; j < n; j++)
        {
            numbers[i - 1] = j;
            if (i == k)
            {
                Print(i);
            }

            Combine(i + 1, j + 1);
        }
    }

    static void Main()
    {
        string numberN;

        do
        {
            Console.Write("Enter N: ");
            numberN = Console.ReadLine();
        }
        while (!Int32.TryParse(numberN, out n) || n <= 0);

        string numberK;

        do
        {
            Console.Write("Enter K: ");
            numberK = Console.ReadLine();
        }
        while (!Int32.TryParse(numberK, out k) || k <= 0 || k > n);

        numbers = new int[n];

        Console.WriteLine("C({0}, {1}):", n, k);

        Combine(1, 0);
    }
}
