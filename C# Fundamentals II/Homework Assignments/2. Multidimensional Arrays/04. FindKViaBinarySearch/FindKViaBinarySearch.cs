using Nakov.IO;
using System;

class FindKViaBinarySearch
{
    static void Main()
    {
        Console.Write("Enter an integer: ");
        string numberK = Console.ReadLine();
        int k = Int32.Parse(numberK);

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

        Array.Sort(numbers);

        int index = Array.BinarySearch(numbers, k);

        // the number is not found
        if (index < 0)
        {
            // all numbers in the array are greater
            if (index == -1)
            {
                Console.WriteLine("The integer to search for ({0}) is not found. All numbers in the array are greater.", k);
            }
            else
            {
                Console.WriteLine("The integer to search for ({0}) is not found. The greatest number < {0} is {1}.", k, numbers[~index - 1]);
            }
        }
        else
        {
            Console.WriteLine("The integer to search for ({0}) is in the array.", k);
        }
    }
}
