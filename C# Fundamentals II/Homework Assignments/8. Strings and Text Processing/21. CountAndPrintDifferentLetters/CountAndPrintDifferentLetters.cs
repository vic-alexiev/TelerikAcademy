using System;

class CountAndPrintDifferentLetters
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();

        int[] letters = new int[65536];

        foreach (char c in input)
        {
            if (Char.IsLetter(c))
            {
                letters[c]++; 
            }
        }

        Console.WriteLine("Letters:");

        for (int i = 0; i < 65536; i++)
        {
            if (letters[i] > 0)
            {
                Console.WriteLine("'{0}': {1} occurrence(s)", (char)i, letters[i]);
            }
        }
    }
}
