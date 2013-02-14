using System;

class SortListOfWords
{
    static void Main()
    {
        Console.WriteLine("Enter a few words separated with spaces:");
        string input = Console.ReadLine();

        string[] words = input.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

        Array.Sort(words);

        Console.WriteLine("The list of words sorted:");

        foreach (string word in words)
        {
            Console.WriteLine(word);
        }
    }
}
