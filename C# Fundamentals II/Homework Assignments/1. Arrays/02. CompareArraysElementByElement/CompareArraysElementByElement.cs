using Nakov.IO;
using System;

class CompareArraysElementByElement
{
    static void Main()
    {
        string size1AsString;
        int size1;
        string size2AsString;
        int size2;
        do
        {
            Console.Write("Enter the size of the first array: ");
            size1AsString = Console.ReadLine();
        }
        while (!Int32.TryParse(size1AsString, out size1) || size1 <= 0);

        int[] array1 = new int[size1];

        Console.Write("Enter {0} integers separated by spaces: ", size1);

        for (int i = 0; i < size1; i++)
        {
            array1[i] = Cin.NextInt();
        }

        do
        {
            Console.Write("Enter the size of the second array: ");
            size2AsString = Console.ReadLine();
        }
        while (!Int32.TryParse(size2AsString, out size2) || size2 <= 0);

        int[] array2 = new int[size2];

        Console.Write("Enter {0} integers separated by spaces: ", size2);

        for (int i = 0; i < size2; i++)
        {
            array2[i] = Cin.NextInt();
        }

        if (size1 != size2)
        {
            Console.WriteLine("The arrays are different.");
            return;
        }

        for (int i = 0; i < size1; i++)
        {
            if (array1[i] != array2[i])
            {
                Console.WriteLine("The arrays are different.");
                return;
            }
        }

        Console.WriteLine("The arrays are identical.");
    }
}
