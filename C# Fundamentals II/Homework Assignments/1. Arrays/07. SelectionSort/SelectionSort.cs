using Nakov.IO;
using System;

class SelectionSort
{
    private static void SelectSort(int[] value)
    {
        int n = value.Length;

        for (int i = 0; i < n - 1; i++)
        {
            int k = i;
            int min = value[k];

            for (int j = i + 1; j < n; j++)
            {
                if (value[j] < min)
                {
                    k = j;
                    min = value[k];
                }
            }

            value[k] = value[i];
            value[i] = min;
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

        int[] numbers = new int[n];

        Console.Write("Enter {0} integers separated by spaces: ", n);

        for (int i = 0; i < n; i++)
        {
            numbers[i] = Cin.NextInt();
        }

        SelectSort(numbers);

        Console.Write("The array sorted using selection sort: ");

        Console.WriteLine(String.Join(", ", numbers));
    }
}
