using Nakov.IO;
using System;

class MergeSort
{
    private static int[] a;
    private static int[] b;

    private static void MergeSortRecursively(int left, int right)
    {
        if (right <= left)
        {
            return;
        }

        int mid = (right + left) / 2;

        MergeSortRecursively(left, mid);
        MergeSortRecursively(mid + 1, right);

        int i, j;
        for (i = mid + 1; i > left; i--)
        {
            b[i - 1] = a[i - 1];
        }
        for (j = mid; j < right; j++)
        {
            b[right + mid - j] = a[j + 1];
        }

        for (int k = left; k <= right; k++)
        {
            a[k] = (b[i] < b[j]) ? b[i++] : b[j--];
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
        b = new int[n];

        Console.Write("Enter {0} integers separated by spaces: ", n);

        for (int i = 0; i < n; i++)
        {
            a[i] = Cin.NextInt();
        }

        MergeSortRecursively(0, a.Length - 1);

        Console.WriteLine(String.Join(" ", a));
    }
}
