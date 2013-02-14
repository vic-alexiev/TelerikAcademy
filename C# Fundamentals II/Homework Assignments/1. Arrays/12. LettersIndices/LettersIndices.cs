using System;

class LettersIndices
{
    static void Main()
    {
        Console.Write("Enter a word with capital letters: ");
        string word = Console.ReadLine();

        Console.WriteLine("Indices: ");

        foreach (char letter in word)
        {
            Console.Write("{0} ", 1 + letter - 'A');
        }

        Console.WriteLine();
    }
}
