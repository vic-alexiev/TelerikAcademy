using Nakov.IO;
using System;

class BinarySearch
{
    /// <summary>
    /// Retruns an integer value i defined as follows:
    /// <para>-1 if x &lt; array[0]</para>
    /// <para> 0 if x = array[0]</para>
    /// <para> j if array[j-1] &lt; x &#8804; array[j]</para>
    /// <para> n if array[n-1] &lt; x.</para>
    /// </summary>
    /// <param name="x"></param>
    /// <param name="array"></param>
    /// <returns></returns>
    private static int BinSearch(int x, int[] array)
    {
        int n = array.Length;
        int mid;
        int left = 0;
        int right = n - 1;

        if (x < array[left])
        {
            return -1;
        }
        if (x == array[left])
        {
            return 0;
        }
        if (x > array[right])
        {
            return n;
        }

        while (right - left > 1)
        {
            mid = (left + right) / 2;
            if (x <= array[mid])
            {
                right = mid;
            }
            else
            {
                left = mid;
            }
        }

        return right;
    }

    static void Main()
    {
        Console.Write("Enter an integer: ");
        int number = Int32.Parse(Console.ReadLine());

        string numberN;
        int n;

        do
        {
            Console.Write("Enter the size of the sorted array: ");
            numberN = Console.ReadLine();
        }
        while (!Int32.TryParse(numberN, out n) || n <= 0);

        int[] numbers = new int[n];

        Console.Write("Enter {0} integers separated by spaces: ", n);

        for (int i = 0; i < n; i++)
        {
            numbers[i] = Cin.NextInt();
        }

        int index = BinSearch(number, numbers);

        Console.WriteLine("{0} has index {1}.", number, index);
    }
}
