using Nakov.IO;
using System;

class QuickSort
{
    private static int[] a;

    private static void QSort(int left, int right)
    {
        int i = left;
        int j = right;
        int x = a[right];
        int y;

        do
        {
            while (x > a[i])
            {
                i++;
            }
            while (x < a[j])
            {
                j--;
            }
            if (i <= j)
            {
                y = a[i];
                a[i] = a[j];
                a[j] = y;
                i++;
                j--;
            }
        }
        while (j >= i);

        if (j > left)
        {
            QSort(left, j);
        }

        if (i < right)
        {
            QSort(i, right);
        }
    }

    static void Main()
    {
        string numberN;
        int n;

        do
        {
            Console.Write("Enter the size of the array: ");
            numberN = Console.ReadLine();
        }
        while (!Int32.TryParse(numberN, out n) || n <= 0);

        a = new int[n];

        Console.Write("Enter {0} integers separated by spaces: ", n);

        for (int i = 0; i < n; i++)
        {
            a[i] = Cin.NextInt();
        }

        QSort(0, n - 1);

        Console.WriteLine(String.Join(" ", a));
    }
}
