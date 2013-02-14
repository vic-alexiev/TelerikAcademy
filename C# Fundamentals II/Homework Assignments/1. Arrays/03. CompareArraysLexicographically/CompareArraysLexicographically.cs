using System;

class CompareArraysLexicographically
{
    static void Main()
    {
        Console.Write("Enter the first word: ");
        string word1 = Console.ReadLine();

        Console.Write("Enter the second word: ");
        string word2 = Console.ReadLine();

        int size1 = word1.Length;
        int size2 = word2.Length;
        int size = Math.Min(size1, size2);

        for (int i = 0; i < size; i++)
        {
            if (word1[i] == word2[i])
            {
                continue;
            }
            else if (word1[i] < word2[i])
            {
                Console.WriteLine("\"{0}\" would appear in a dictionary before \"{1}\".", word1, word2);
                return;
            }
            else
            {
                Console.WriteLine("\"{0}\" would appear in a dictionary before \"{1}\".", word2, word1);
                return;
            }
        }

        if (size1 == size2)
        {
            Console.WriteLine("These words are one and the same.");
        }
        else if (size1 < size2)
        {
            Console.WriteLine("\"{0}\" would appear in a dictionary before \"{1}\".", word1, word2);
        }
        else
        {
            Console.WriteLine("\"{0}\" would appear in a dictionary before \"{1}\".", word2, word1);
        }
    }
}
