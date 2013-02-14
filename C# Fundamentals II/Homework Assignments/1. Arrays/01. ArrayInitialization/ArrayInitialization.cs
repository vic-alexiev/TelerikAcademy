using System;

class ArrayInitialization
{
    static void Main()
    {
        // size of the array
        int n = 20;

        int multiplier = 5;
        int[] integersArray = new int[n];

        for (int i = 0; i < n; i++)
        {
            integersArray[i] = i * multiplier;
        }

        Console.WriteLine(String.Join(", ", integersArray));
    }
}
