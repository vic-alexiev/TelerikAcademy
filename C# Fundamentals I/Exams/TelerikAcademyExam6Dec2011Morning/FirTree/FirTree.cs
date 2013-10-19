using System;

class FirTree
{
    static void Main()
    {
        string firHeight = Console.ReadLine();

        int n;
        if (!Int32.TryParse(firHeight, out n) || n < 4 || n > 100)
        {
            Console.WriteLine("Enter a valid integer in [4, 100] for the height!");
            return;
        }

        // On every line the number of asterisks is 2i+1.
        // On the last line (the trunk excluded) i is n-2,
        // so the number of asterisks is 2(n-2) + 1 = 2n - 3,
        // which is also the total number of characters per line.
        int total = 2 * n - 3;
        int asterisksCount = 0;
        string line = String.Empty;

        for (int i = 0; i < n - 1; i++)
        {
            asterisksCount = 2 * i + 1;
            line = String.Format("{0}{1}{0}", new String('.', (total - asterisksCount) / 2), new String('*', asterisksCount));
            Console.WriteLine(line);
        }

        Console.WriteLine("{0}*{0}", new String('.', (total - 1) / 2));
    }
}
