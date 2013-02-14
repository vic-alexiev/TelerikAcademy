using System;

class PrintPermutations
{
    private static int[] numbers;
    private static bool[] used;
    private static int n;

    private static void Print()
    {
        for (int i = 0; i < n; i++)
        {
            Console.Write("{0} ", numbers[i] + 1);
        }

        Console.WriteLine();
    }

    private static void Permute(int i)
    {
        if (i >= n)
        {
            Print();
            return;
        }

        for (int k = 0; k < n; k++)
        {
            if (!used[k])
            {
                used[k] = true;
                numbers[i] = k;
                Permute(i + 1);
                used[k] = false;
            }
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

        numbers = new int[n];
        used = new bool[n];

        Console.WriteLine("All permutations of the numbers from 1 to {0}:", n);

        Permute(0);
    }
}
