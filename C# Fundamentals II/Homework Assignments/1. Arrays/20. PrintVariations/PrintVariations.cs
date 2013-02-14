using System;

class PrintVariations
{
    private static int[] numbers;
    private static int n;
    private static int k;

    private static void Print(int i)
    {
        for (int j = 0; j <= i - 1; j++)
        {
            Console.Write("{0} ", numbers[j] + 1);
        }

        Console.WriteLine();
    }

    /// <summary>
    /// Recursively generates the k-element variations
    /// of the numbers from 0 to (n-1) (incremented with 1
    /// when printed).
    /// </summary>
    /// <param name="i"></param>
    private static void Variate(int i)
    {
        if (i >= k)
        {
            Print(i);
            return;
        }

        for (int j = 0; j < n; j++)
        {
            numbers[i] = j;
            Variate(i + 1);
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

        Console.WriteLine("V({0}, {1}):", n, k);

        Variate(0);
    }
}
