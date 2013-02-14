using Nakov.IO;
using System;

class SortStringsByLength
{
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

        string[] words = new string[n];

        Console.Write("Enter {0} strings separated by spaces: ", n);

        for (int i = 0; i < n; i++)
        {
            words[i] = Cin.NextToken();
        }

        // I solution
        //Array.Sort(words, new StringByLengthComparer());

        // II solution
        Array.Sort(words, (w1, w2) => w1.Length.CompareTo(w2.Length));

        Console.WriteLine("The array sorted by the length of the words: {0}", String.Join(", ", words));
    }
}
